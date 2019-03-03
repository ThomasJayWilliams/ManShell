using ManShell.BusinessObjects;
using System;

namespace MicroStorage
{
	internal class BackupCommand : CommandBase
    {
        internal BackupCommand(string arg)
        {
            if (string.IsNullOrEmpty(arg))
                throw new ArgumentNullException();

            this.argument = arg;
        }

        internal override void Invoke()
        {
            if (this.argument == "update")
                FileManager.SaveBackup();

            else if (this.argument == "load")
                FileManager.LoadBackup();

            else
                throw new NoCommandArgumentException("Invalid command argument!");
        }
    }
}
