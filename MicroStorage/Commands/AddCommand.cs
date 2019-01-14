using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    internal class AddCommand : CommandBase
    {
        internal AddCommand(string argument)
        {
            if (string.IsNullOrEmpty(argument))
                throw new ArgumentNullException("argument", "Argument required for this command!");

            this._argument = argument;
        }

        internal override void Invoke()
        {
            ScopeType type = LocalScopeManager.Current.Scope.Type;

            switch (type)
            {
                case ScopeType.Enviroment:
                    DataManager.AddCategory(this._argument);
                    break;
                case ScopeType.Category:
                    string category = LocalScopeManager.Current.Scope.Name,
                        entryName = this._argument;
                    DataManager.AddEntry(category, entryName);
                    break;
                case ScopeType.Entry:
                    string entry = LocalScopeManager.Current.Scope.Name;
                    DataManager.AddContent(entry, _argument);
                    break;
                default:
                    throw new InvalidScopeException();
            }

            this._isSuccessfull = true;
            
            DataManager.ParseToJSON();
            FileManager.Save(DataManager.JSON);
        }
    }
}
