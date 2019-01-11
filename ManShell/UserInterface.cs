using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MicroStorage;

namespace ManShell
{
    internal static class UserInterface
    {
        private static CurrentScope currentScope = CurrentScope.Current;

        internal static void Input(string input)
        {
            CommandParser parser = CommandParser.Current;
            parser.ParseCommand(input);
            parser.OnInvoke += OnInvokeHandler;
            parser.RunCommand();
        }

        internal static void Run()
        {
            while (true)
            {
                string command = ConsoleWrapper.Read();
                Input(command);
            }
        }

        private static void OnInvokeHandler(object sernder, CommandInvokeEventArgs e)
        {

        }
    }
}
