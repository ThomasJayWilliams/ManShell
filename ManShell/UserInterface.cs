using System.Collections.Generic;

using ManShell.BusinessObjects;

namespace ManShell
{
    internal static class UserInterface
    {
        private static ScopeManager currentScope = ScopeManager.Current;

        private static IWrapper TryGetAppByName(string name)
        {
            IWrapper wrapper = null;

            switch (name)
            {
                case "microstorage":
                    wrapper = new MicroStorageWrapper();
                    break;
                default:
                    return null;
            }

            return wrapper;
        }

        internal static void Run(string[] args)
        {
            IWrapper wrapper = null;

            if (args.Length > 0)
                wrapper = TryGetAppByName(args[0]);

            while (true)
            {
                try
                {
                    ConsoleWrapper.WriteScope();
                    string command = ConsoleWrapper.Read();

                    if (wrapper != null)
                        wrapper.RunApplication(command);

                    if (wrapper == null)
                        wrapper = BaseCommandRunner.RunApp(command);

                    if (!string.IsNullOrEmpty(Application.Globals.ToOutput))
                    {
                        ConsoleWrapper.WriteEmptyLine();
                        ConsoleWrapper.WriteLine(Application.Globals.ToOutput);
                        Application.Globals.ToOutput = string.Empty;
                    }

                    if (Application.Globals.ListToOutput.Count > 0)
                    {
                        ConsoleWrapper.WriteEmptyLine();
                        foreach (string item in Application.Globals.ListToOutput)
                            ConsoleWrapper.WriteLine(item);
                        Application.Globals.ListToOutput = new List<string>();
                    }
                }

                catch (System.Exception ex)
                {
                    ConsoleWrapper.ShowError(ex.Message);
                }

                ConsoleWrapper.WriteEmptyLine();
            }
        }
    }
}
