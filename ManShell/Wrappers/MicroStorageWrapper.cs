using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MicroStorage;

namespace ManShell
{
    public class MicroStorageWrapper : IWrapper
    {
        public void RunApplication()
        {
            MicroStorage.OnLoad.Load();

            UserInterface.ToExecute += CommandParser.Current.ParseCommand;

            CommandParser.Current.RunCommand();
        }
    }
}
