using System;

namespace MicroStorage
{
    internal class AddCommand : CommandBase
    {
        internal AddCommand(string argument)
        {
            if (string.IsNullOrEmpty(argument))
                throw new ArgumentNullException("argument", "Argument required for this command!");

            this.argument = argument;
        }

        internal override void Invoke()
        {
            ScopeType type = LocalScopeManager.Current.Scope.Type;

            if (type != ScopeType.Entry)
                this.argument = this.argument.ToLower();

            switch (type)
            {
                case ScopeType.Enviroment:
                    DataManager.AddCategory(this.argument);
                    break;
                case ScopeType.Category:
                    string category = LocalScopeManager.Current.Scope.Name,
                        entryName = this.argument;
                    DataManager.AddEntry(category, entryName);
                    break;
                case ScopeType.Entry:
                    string entry = LocalScopeManager.Current.Scope.Name;
                    DataManager.AddContent(entry, argument);
                    break;
                default:
                    throw new InvalidScopeException();
            }

            this.isSuccessfull = true;
            
            DataManager.ParseToJSON();
            FileManager.Save(DataManager.JSON);
        }
    }
}
