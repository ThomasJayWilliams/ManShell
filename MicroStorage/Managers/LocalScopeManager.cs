using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ManShell.BusinessObjects;

namespace MicroStorage
{
    public class LocalScopeManager
    {
        private static LocalScopeManager _instance = new LocalScopeManager();
        private Scope<ScopeType> _localScope;

        public static LocalScopeManager Current
        {
            get
            {
                if (_instance == null)
                    _instance = new LocalScopeManager();
                return _instance;
            }
        }

        public Scope<ScopeType> Scope
        {
            get { return this._localScope; }
        }

        private LocalScopeManager() { }

        public void SetScope(string name, ScopeType type)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException();

            if (type != ScopeType.Enviroment && !DataManager.IsElementExist(name))
                throw new InvalidScopeException();

            if (type == ScopeType.Enviroment)
                this._localScope = new Scope<ScopeType>(new LocalScope(name, type), type);
            else if (this._localScope.Type == ScopeType.Enviroment && type == ScopeType.Category)
            {
                this._localScope.AddScope(new LocalScope(name, type, parent: (LocalScope)this._localScope.ActualScopes.Peek()));
            }
            else if (this._localScope.Type == ScopeType.Enviroment && type == ScopeType.Entry)
            {
                Category category = DataManager.GetCategoryByEntryName(name);
                if (category == null)
                    throw new InvalidScopeException();

                this._localScope.AddScope(new LocalScope(type: type, name: category.CategoryName, parent: (LocalScope)this._localScope.ActualScopes.Peek()));
                this._localScope.AddScope(new LocalScope(type: type, name: name, parent: (LocalScope)this._localScope.ActualScopes.Peek()));
            }

            PostScope();
        }

        public void Unscope()
        {
            if (this._localScope == null)
                throw new InvalidScopeException();

            ScopeType type = ScopeType.Enviroment;
            if (this._localScope.Type > ScopeType.Enviroment)
                type = (ScopeType)this._localScope.Type + 1;

            this._localScope.RemoveScope(type);

            PostScope();
        }

        private void PostScope()
        {
            if (this._localScope != null)
                ScopeManager.Current.SetupLocalScope(this._localScope);
        }
    }

    public class LocalScope : IScope
    {
        private string _name;
        private IScope _child;
        private IScope _parent;
        private ScopeType _type;

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        public IScope Parent
        {
            get { return this._parent; }
            set { this._parent = value; }
        }
        public IScope Child
        {
            get { return this._child; }
            set { this._child = value; }
        }
        public ScopeType Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        public LocalScope(string name, ScopeType type, LocalScope parent = null, LocalScope child = null)
        {
            this._name = name;
            if (parent != null)
                this._parent = parent;
            if (child != null)
                this._child = child;
            this._type = type;
        }
    }
}
