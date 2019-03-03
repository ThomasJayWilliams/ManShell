using ManShell.BusinessObjects;
using System.IO;

namespace DataConverter
{
	internal class LoadDataCommand : CommandBase
	{
		internal LoadDataCommand(string filePath)
		{
			if (string.IsNullOrEmpty(filePath))
				throw new NoCommandArgumentException();
			this.argument = filePath;
		}

		internal override void Invoke()
		{
			if (!File.Exists(this.argument))
				throw new FileNotFoundException();
			FileInfo file = new FileInfo(this.argument);
			BufferManager.Current.CreateBuffer(file);
			LocalScopeManager.Current.SetLocalScope(file.Name, ScopeType.Source);
		}
	}
}
