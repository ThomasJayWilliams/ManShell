using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ManShell.BusinessObjects;
using MicroStorage;

namespace ManShell
{
    public class MicroStorageWrapper : IWrapper
    {
        public MicroStorageWrapper()
        {
            Application.Current.LoadApplication(MicroStorageInstance.Current);
        }

        public void RunApplication(string command)
        {
            try
            {
                Application.Current.RunCommand(command);
            }
            catch (Exception ex)
            {
                ConsoleWrapper.ShowError(ex.Message);
            }
        }
    }
}
