using ManShell.BusinessObjects;

namespace DataConverter
{
	public class LocalScopeManager
	{
		private static LocalScopeManager instance = new LocalScopeManager();
		private static object syncToken = new object();
		private Scope<ScopeType> localScope;

		public static LocalScopeManager Current
		{
			get
			{
				lock (syncToken)
				{
					if (instance == null)
						instance = new LocalScopeManager();
					return instance;
				}
			}
		}

		public Scope<ScopeType> Scope
		{
			get
			{
				if (this.localScope == null)
					this.localScope = new Scope<ScopeType>(
						new LocalScope(Globals.AppName, ScopeType.Enviroment), ScopeType.Enviroment);
				return this.localScope;
			}
		}

		private LocalScopeManager() { }

		public void SetLocalScope(string name, ScopeType type)
		{
			if (string.IsNullOrEmpty(name))
				throw new InvalidScopeException();

			if (type == ScopeType.Enviroment)
				this.localScope = new Scope<ScopeType>(new LocalScope(name, type), type);

			else
				this.localScope.AddScope(new LocalScope(name, type, parent: (LocalScope)this.localScope.ActualScopes.Peek()), type);

			PostScope();
		}

		public void Unscope()
		{
			if (this.localScope.Type == ScopeType.Enviroment)
				throw new InvalidScopeException();

			ScopeType type = ScopeType.Enviroment;

			if (this.localScope.Type == ScopeType.Source)
				BufferManager.Current.ClearBuffer();

			else
				type = ScopeType.Source;

			this.localScope.RemoveScope(type);

			PostScope();
		}

		private void PostScope()
		{
			if (this.localScope != null)
				Application.Current.ScopeManager.SetupLocalScope(this.localScope);
		}
	}

	public class LocalScope : IScope
	{
		public string Name { get; set; }
		public string TypeName
		{
			get { return this.ScopeType.ToString(); }
		}
		public IScope Child { get; set; }
		public IScope Parent { get; set; }
		public ScopeType ScopeType { get; set; }

		public LocalScope(string name, ScopeType type, LocalScope parent = null, LocalScope child = null)
		{
			this.Name = name;
			if (parent != null)
				this.Parent = parent;
			if (child != null)
				this.Child = child;
			this.ScopeType = type;
		}
	}
}
