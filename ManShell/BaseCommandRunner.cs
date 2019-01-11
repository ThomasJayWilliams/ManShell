using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManShell
{
    internal static class BaseCommandRunner
    {
        internal static void RunApp(string arg)
        {
            if (!string.IsNullOrEmpty(arg))
            {
                IWrapper wrapper;

                switch (arg.ToLower())
                {
                    case "quit":
                    case "exit":
                        EndSession();
                        break;
                    case "microstorage":
                        wrapper = new MicroStorageWrapper();
                        wrapper.RunApplication();
                        break;
                    default:
                        throw new InvalidCommandException();
                }                
            }
        }

        private static void EndSession()
        {
            SaveAll();
            Environment.Exit(0);
        }

        private static void SaveAll()
        {

        }
    }
}
