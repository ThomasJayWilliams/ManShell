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
            get { return this._global; }
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

        private ScopeManager()
        {
            GlobalScope global = new GlobalScope();
            this._global = new Scope(global);
        }

        public Scope GetCurrentScope()
        {
            if (this._localScope != null)
                return this._localScope;
            return this._global;
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
            get { return Globals.GeneralAppName.ToLower(); }
            set { }
        }
        public IScope Parent { get { return null; } set { } }
        public IScope Child { get { return null; } set { } }
    }
}
