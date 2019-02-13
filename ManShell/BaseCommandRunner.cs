using System;

namespace ManShell
{
    internal static class BaseCommandRunner
    {
        internal static IWrapper RunApp(string arg)
        {
            if (!string.IsNullOrEmpty(arg))
            {
                switch (arg.ToLower())
                {
                    case "quit":
                    case "exit":
                        EndSession();
                        break;
                    case "microstorage":
                        return new MicroStorageWrapper();
					case "dataconverter":
						return new DataConverterWrapper();
                    default:
                        throw new InvalidCommandException();
                }                
            }

            return null;
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
