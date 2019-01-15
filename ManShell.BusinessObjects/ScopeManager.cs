using System;
using System.Collections.Generic;
using System.Linq;

namespace ManShell.BusinessObjects
{
    public class ScopeManager
    {
        private static ScopeManager instance = new ScopeManager();
        private Scope global;
        private Scope localScope;

        public Scope Global
        {
            get
            {
                if (this.global == null)
                    this.global = new Scope(new GlobalScope());
                return this.global;
            }
        }

        public static ScopeManager Current
        {
            get
            {
                if (instance == null)
                    instance = new ScopeManager();
                return instance;
            }
        }

        private ScopeManager() { }

        public Stack<string> GetStringScopes()
        {
            if (this.localScope == null)
                return new Stack<string>(new string[1] { this.global.Name });

            var strStack = new Stack<string>();

            IScope[] temp = this.localScope.ActualScopes.ToArray<IScope>();

            for (int i = temp.Length; i > 0; i--)
                strStack.Push(temp[i].Name);

            if (strStack.Count == 0)
                throw new NullReferenceException("Scope is empty!");

            return strStack;
        }

        public Scope GetCurrentScope()
        {
            if (this.localScope != null)
                return this.localScope;
            return this.Global;
        }

        public void SetupLocalScope(Scope scope)
        {
            if (scope == null)
                throw new ArgumentNullException();

            this.localScope = scope;
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
