﻿using System;
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

        public static Execution ToInvoke;

        internal static void Run()
        {
            while (true)
            {
                string command = ConsoleWrapper.Read();
                if (ToInvoke != null)
                    ToInvoke.Invoke(command);

                if (!string.IsNullOrEmpty(Globals.ToOutput))
                {
                    ConsoleWrapper.WriteLine(" ");
                    ConsoleWrapper.WriteLine(Globals.ToOutput);
                    Globals.ToOutput = string.Empty;
                }

                if (Globals.ListToOutput.Count > 0)
                {
                    ConsoleWrapper.WriteLine(" ");
                    foreach (string item in Globals.ListToOutput)
                        ConsoleWrapper.WriteLine(item);
                    Globals.ListToOutput = new List<string>();
                }

                ConsoleWrapper.WriteLine(" ");
            }
        }
    }
}
