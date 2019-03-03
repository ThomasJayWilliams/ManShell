using ManShell.BusinessObjects;

namespace DataConverter
{
	public static class LocalScopeManager
	{
		public static void SetLocalScope(string name, string typeName)
		{
			if (string.IsNullOrEmpty(name))
				throw new InvalidScopeException();
			ScopeManager.Current.SetupLocalScope(new Scope(new LocalScope(name, typeName)));
		}
	}

	public class LocalScope : IScope
	{
		public string Name { get; set; }

		public string TypeName { get; set; }

		public IScope Child { get; set; }

		public IScope Parent { get; set; }

		public LocalScope(string name, string typeName)
		{
			this.Name = name;
			this.TypeName = typeName;
		}
	}
}
