using System;

namespace MicroStorage
{
    internal class ScopeInCommand : CommandBase
    {
        internal ScopeInCommand(string arg)
        {
            if (arg == null)
                throw new ArgumentNullException("arg", "Argument is required for this command!");
            this._argument = arg;
        }

        internal override void Invoke()
        {
            ScopeType type = ScopeType.Enviroment;

            if (!DataManager.GetTypeByName(this._argument, ref type))
                throw new InvalidScopeException("Object to scope is not found!");

            LocalScopeManager.Current.SetScope(this._argument, type);

            this._isSuccessfull = true;
        }
    }
}
