using System;

namespace MicroStorage
{
    internal class ScopeInCommand : CommandBase
    {
        internal ScopeInCommand(string arg)
        {
            if (arg == null)
                throw new ArgumentNullException("arg", "Argument is required for this command!");
            this.argument = arg;
        }

        internal override void Invoke()
        {
            var type = ScopeType.Enviroment;

            if (!DataManager.GetTypeByName(this.argument, ref type))
                throw new InvalidScopeException("Object to scope is not found!");

            LocalScopeManager.Current.SetScope(this.argument, type);

            this.isSuccessfull = true;
        }
    }
}
