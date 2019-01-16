using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
