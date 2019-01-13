using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    public class AddEntryCommand : CommandBase
    {
        public AddEntryCommand(string arg)
        {
            if (arg == null)
                throw new ArgumentNullException("arg", "Argument cannot be null or empty!");
            this._argument = arg;
        }

        public override void Invoke()
        {
            if (LocalScopeManager.Current.Scope.Type != ScopeType.Category)
                throw new InvalidScopeException();

            string category = LocalScopeManager.Current.Scope.Name,
                entryName = this._argument;

            DataManager.AddEntry(category, entryName);
            DataManager.ParseToJSON();
            FileManager.Save(DataManager.JSON);

            this._isSuccessfull = true;
        }
    }
}
