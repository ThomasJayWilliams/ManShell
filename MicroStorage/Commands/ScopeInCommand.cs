using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    public class ScopeInCommand : ICommand
    {
        private bool _isSuccessfull;
        private string _argument;

        public bool IsSuccessfull
        {
            get { return this._isSuccessfull; }
        }

        public string Argument
        {
            get { return this._argument; }
        }

        public ScopeInCommand(string arg)
        {
            if (arg == null)
                throw new ArgumentNullException("arg", "Argument cannot be null or empty!");
            this._argument = arg;
        }

        public void Invoke()
        {
            ScopeType type = ScopeType.Enviroment;

            if (!DataManager.GetTypeByName(this._argument, ref type))
                throw new InvalidScopeException();

            LocalScopeManager.Current.SetScope(this._argument, type);

            this._isSuccessfull = true;
        }
    }
}
