using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    public class AddCategoryCommand : CommandBase
    {
        public AddCategoryCommand(string arg)
        {
            if (arg == null)
                throw new ArgumentNullException("arg", "Argument cannot be null or empty!");
            this._argument = arg;
        }

        public override void Invoke()
        {
            if (LocalScopeManager.Current.Scope.Type != ScopeType.Enviroment)
                throw new InvalidScopeException();

            DataManager.AddCategory(this._argument);
            DataManager.ParseToJSON();
            FileManager.Save(DataManager.JSON);

            this._isSuccessfull = true;
        }
    }
}
