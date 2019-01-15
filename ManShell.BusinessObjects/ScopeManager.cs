using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManShell.BusinessObjects
{
    public class ScopeManager
    {
        private static ScopeManager _instance = new ScopeManager();
        private Scope _global;
        private Scope _localScope;

        public Scope Global
        {
            get
            {
                if (this._global == null)
                    this._global = new Scope(new GlobalScope());
                return this._global;
            }
        }

        public static ScopeManager Current
        {
            get
            {
                if (_instance == null)
                    _instance = new ScopeManager();
                return _instance;
            }
        }

        private ScopeManager() { }

        public Stack<string> GetStringScopes()
        {
            if (this._localScope == null)
                return new Stack<string>(new string[1] { this._global.Name });

            Stack<string> strStack = new Stack<string>();

            IScope[] temp = this._localScope.ActualScopes.ToArray<IScope>();

            for (int i = temp.Length; i > 0; i--)
                strStack.Push(temp[i].Name);

            if (strStack.Count == 0)
                throw new NullReferenceException("Scope is empty!");

            return strStack;
        }

        public Scope GetCurrentScope()
        {
            if (this._localScope != null)
                return this._localScope;
            return this.Global;
        }

        public void SetupLocalScope(Scope scope)
        {
            if (scope == null)
                throw new ArgumentNullException();

            this._localScope = scope;
        }
    }

    public class GlobalScope : IScope
    {
        public string Name
        {
            get { return Application.Globals.GeneralAppName.ToLower(); }
            set { }
        }
        public IScope Parent { get { return null; } set { } }
        public IScope Child { get { return null; } set { } }
        public string TypeName { get { return Application.Globals.GeneralAppName; } }
    }
}
