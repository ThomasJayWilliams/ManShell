using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    public class AddContentCommand : ICommand
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

        public AddContentCommand(string arg)
        {
            if (arg == null)
                throw new ArgumentNullException("arg", "Argument cannot be null or empty!");
            this._argument = arg;
        }

        public void Invoke()
        {
            if (LocalScopeManager.Current.Scope.Type != ScopeType.Entry)
                throw new InvalidScopeException();

            string entry = LocalScopeManager.Current.Scope.Name,
                content = this._argument;

            DataManager.AddContent(entry, content);
            DataManager.ParseToJSON();
            FileManager.Save(DataManager.JSON);

            this._isSuccessfull = true;
        }
    }
}
