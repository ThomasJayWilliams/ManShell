using System.IO;
using Newtonsoft.Json;

namespace DataConverter
{
	internal class SaveCommand : CommandBase
	{
		internal SaveCommand(string argument)
		{
			if (string.IsNullOrEmpty(argument))
				throw new ManShell.BusinessObjects.NoCommandArgumentException();
			this.argument = argument;
		}

		internal override void Invoke()
		{
			string data = BufferManager.Current.Buffer.Converter.OuterString;

			if (LocalScopeManager.Current.Scope.Type == ScopeType.Enviroment || LocalScopeManager.Current.Scope.Type == ScopeType.Source)
				throw new ManShell.BusinessObjects.InvalidScopeException("You cannot save file in this scope!");

			File.AppendAllText(this.argument, data);
		}
	}
}
