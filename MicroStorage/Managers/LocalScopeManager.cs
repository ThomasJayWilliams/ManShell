using System;

using ManShell.BusinessObjects;

namespace MicroStorage
{
    public class LocalScopeManager
    {
        private static LocalScopeManager instance = new LocalScopeManager();
        private Scope<ScopeType> localScope;

        public static LocalScopeManager Current
        {
            get
            {
                if (instance == null)
                    instance = new LocalScopeManager();
                return instance;
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

        public void SetScope(string name, ScopeType type)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException();

            if (type != ScopeType.Enviroment && !DataManager.IsElementExist(name))
                throw new InvalidScopeException();

            if (type == ScopeType.Enviroment)
                this.localScope = new Scope<ScopeType>(new LocalScope(name, type), type);
            else if (this.localScope.Type == ScopeType.Enviroment && type == ScopeType.Category)
            {
                this.localScope.AddScope(new LocalScope(name, type, parent: (LocalScope)this.localScope.ActualScopes.Peek()), type);
            }
            else if (this.localScope.Type == ScopeType.Enviroment && type == ScopeType.Entry)
            {
                Category category = DataManager.GetCategoryByEntryName(name);
                if (category == null)
                    throw new InvalidScopeException();

                this.localScope.AddScope(new LocalScope(type: (ScopeType)type - 1, name: category.CategoryName, parent: (LocalScope)this.localScope.ActualScopes.Peek()), (ScopeType)type - 1);
                this.localScope.AddScope(new LocalScope(type: type, name: name, parent: (LocalScope)this.localScope.ActualScopes.Peek()), type);
            }
            else if (this.localScope.Type == ScopeType.Category && type == ScopeType.Entry)
            {
                this.localScope.AddScope(new LocalScope(type: type, name: name, parent: (LocalScope)this.localScope.ActualScopes.Peek()), type);
            }

            PostScope();
        }

        public void Unscope()
        {
            if (this.localScope == null)
                throw new InvalidScopeException("Critical error occured! Scope is not set!");

            var type = ScopeType.Enviroment;
            if (this.localScope.Type > ScopeType.Enviroment)
                type = (ScopeType)this.localScope.Type - 1;

            this.localScope.RemoveScope(type);

            PostScope();
        }

        private void PostScope()
        {
            if (this.localScope != null)
                Application.ScopeManager.SetupLocalScope(this.localScope);
        }
    }

    public class LocalScope : IScope
    {
        private string name;
        private IScope child;
        private IScope parent;
        private ScopeType type;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public IScope Parent
        {
            get { return this.parent; }
            set { this.parent = value; }
        }
        public IScope Child
        {
            get { return this.child; }
            set { this.child = value; }
        }
        public ScopeType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public string TypeName
        {
            get { return this.type.ToString(); }
        }

        public LocalScope(string name, ScopeType type, LocalScope parent = null, LocalScope child = null)
        {
            this.name = name;
            if (parent != null)
                this.parent = parent;
            if (child != null)
                this.child = child;
            this.type = type;
        }
    }
}
