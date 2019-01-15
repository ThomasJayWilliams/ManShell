using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ManShell.BusinessObjects;

namespace ManShell
{
    internal static class UserInterface
    {
        private static ScopeManager currentScope = ScopeManager.Current;

        internal static void Run()
        {
            IWrapper wrapper = null;

            while (true)
            {
                ConsoleWrapper.WriteScope();
                string command = ConsoleWrapper.Read();

                if (wrapper != null)
                    wrapper.RunApplication(command);

                if (wrapper == null)
                    wrapper = BaseCommandRunner.RunApp(command);

                if (!string.IsNullOrEmpty(Application.Globals.ToOutput))
                {
                    ConsoleWrapper.WriteLine(" ");
                    ConsoleWrapper.WriteLine(Application.Globals.ToOutput);
                    Application.Globals.ToOutput = string.Empty;
                }

                if (Application.Globals.ListToOutput.Count > 0)
                {
                    ConsoleWrapper.WriteLine(" ");
                    foreach (string item in Application.Globals.ListToOutput)
                        ConsoleWrapper.WriteLine(item);
                    Application.Globals.ListToOutput = new List<string>();
                }

                ConsoleWrapper.WriteLine(" ");
            }
        }
    }
}
