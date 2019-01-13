using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    public class AddContentCommand : CommandBase
    {
        public AddContentCommand(string arg)
        {
            if (arg == null)
                throw new ArgumentNullException("arg", "Argument cannot be null or empty!");
            this._argument = arg;
        }

        public override void Invoke()
        {
            if (LocalScopeManager.Current.Scope.Type != ScopeType.Entry)
                throw new InvalidScopeException();

            string entry = LocalScopeManager.Current.Scope.Name;

            DataManager.AddContent(entry, _argument);
            DataManager.ParseToJSON();
            FileManager.Save(DataManager.JSON);

            this._isSuccessfull = true;
        }
    }
}
