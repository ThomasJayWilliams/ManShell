using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    public class CurrentScope
    {
        private static CurrentScope _instance = new CurrentScope();
        private string _scopeName;
        private ScopeType _type;
        private bool _isScoped = false;

        public bool IsScoped
        {
            get { return this._isScoped; }
        }

        public ScopeType ScopeType
        {
            get { return this._type; }
        }

        public string Name
        {
            get { return this._scopeName; }
        }

        public static CurrentScope Current
        {
            get
            {
                if (_instance == null)
                    _instance = new CurrentScope();
                return _instance;
            }
        }

        private CurrentScope()
        {
            this._scopeName = string.Empty;
        }

        public void SetScope(string name, ScopeType type)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException();

            if (type != ScopeType.Enviroment && !DataManager.IsElementExist(name))
                throw new InvalidScopeException();

            this._isScoped = true;
            this._scopeName = name;
            this._type = type;
        }
    }
}
