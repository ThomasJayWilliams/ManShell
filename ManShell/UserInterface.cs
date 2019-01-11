using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MicroStorage;
using ManShell.BusinessObjects;

namespace ManShell
{
    internal static class UserInterface
    {
        private static ScopeManager currentScope = ScopeManager.Current;

        public static event Execution ToExecute;

        internal static void Run()
        {
            while (true)
            {
                string command = ConsoleWrapper.Read();
                if (ToExecute != null)
                    ToExecute.Invoke(command);
            }
        }
    }
}
