using System.Collections.Generic;
using ManShell.BusinessObjects;

namespace ManShell
{
    internal static class UserInterface
    {
        private static IWrapper TryGetAppByName(string name)
        {
            IWrapper wrapper = null;

            switch (name)
            {
                case "microstorage":
                    wrapper = new MicroStorageWrapper();
                    break;
				case "dataconverter":
					wrapper = new DataConverterWrapper();
					break;
                default:
                    return null;
            }

            return wrapper;
        }

		internal static bool ReadConfirmation(string text)
		{
			ConsoleWrapper.WriteConfirmation(text);
			string response = ConsoleWrapper.Read();
			if (response == "y" || response == "yes")
				return true;
			else
			{
				ConsoleWrapper.WriteLine("Command execution cancelled.");
				return false;
			}
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

                    if (!string.IsNullOrEmpty(Globals.ToOutput))
                    {
                        ConsoleWrapper.WriteEmptyLine();
                        ConsoleWrapper.WriteLine(Globals.ToOutput);
                        Globals.ToOutput = string.Empty;
                    }

                    if (Globals.ListToOutput.Count > 0)
                    {
                        ConsoleWrapper.WriteEmptyLine();
                        foreach (string item in Globals.ListToOutput)
                            ConsoleWrapper.WriteLine(item);
                        Globals.ListToOutput = new List<string>();
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
