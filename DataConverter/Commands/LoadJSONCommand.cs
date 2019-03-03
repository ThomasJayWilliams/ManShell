using ManShell.BusinessObjects;
using System.IO;

namespace DataConverter
{
	internal class LoadJSONCommand : CommandBase
	{
		internal LoadJSONCommand(string argument)
		{
			if (string.IsNullOrEmpty(argument))
				throw new NoCommandArgumentException();
			this.argument = argument;
		}

		internal override void Invoke()
		{
			if (!File.Exists(this.argument))
				throw new FileNotFoundException();
			FileInfo info = new FileInfo(this.argument);
			BufferManager.Current.CreateJSONBuffer(info);
		}
	}
}
