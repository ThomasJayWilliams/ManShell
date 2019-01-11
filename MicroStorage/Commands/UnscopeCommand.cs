using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    public class UnscopeCommand : ICommand
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

        public UnscopeCommand(string arg)
        {
            if (arg == null)
                throw new ArgumentNullException("arg", "Argument cannot be null or empty!");
            this._argument = arg;
        }

        public void Invoke()
        {
            CurrentScope current = CurrentScope.Current;

            if (((ScopeType)current.ScopeType - 1) == ScopeType.Enviroment)
                this._argument = Globals.AppName.ToLower();

            if (DataManager.GetEntryByName(current.Name) != null)
                this._argument = DataManager.GetCategoryByEntryName(current.Name).CategoryName;

            current.SetScope(this._argument, (ScopeType)current.ScopeType - 1);

            this._isSuccessfull = true;
        }
    }
}
