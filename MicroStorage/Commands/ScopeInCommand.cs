using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    public class ScopeInCommand : CommandBase
    {
        public ScopeInCommand(string arg)
        {
            if (arg == null)
                throw new ArgumentNullException("arg", "Argument cannot be null or empty!");
            this._argument = arg;
        }

        public override void Invoke()
        {
            ScopeType type = ScopeType.Enviroment;

            if (!DataManager.GetTypeByName(this._argument, ref type))
                throw new InvalidScopeException();

            LocalScopeManager.Current.SetScope(this._argument, type);

            this._isSuccessfull = true;
        }
    }
}
