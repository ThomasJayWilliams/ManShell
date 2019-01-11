using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MicroStorage;
using ManShell.BusinessObjects;

namespace ManShell
{
    internal static class ConsoleWrapper
    {
        internal static ConsoleColor ScopeColor = ConsoleColor.DarkYellow;
        internal static ConsoleColor OutputColor = ConsoleColor.Gray;
        internal static ConsoleColor InputColor = ConsoleColor.DarkGreen;
        internal static ConsoleColor IndexColor = ConsoleColor.DarkCyan;

        internal static void Setup()
        {
            Console.ResetColor();
            Console.Clear();
        }

        internal static string Read()
        {
            string result = string.Empty;

            WriteScope();

            Console.ForegroundColor = InputColor;
            object temp = Console.ReadLine();
            Console.ForegroundColor = OutputColor;

            result = temp as string;

            if (result == null)
                result = string.Empty;

            return result;
        }

        private static void WriteScope()
        {
            Scope currentScope = ScopeManager.Current.GetCurrentScope();

            foreach (IScope item in currentScope.ActualScopes)
            {
                Write(item.Name, ScopeColor);
                Write("@", IndexColor);
            }
            Write(": ", OutputColor);
        }

        internal static void Write(string arg)
        {
            if (!string.IsNullOrEmpty(arg))
                Console.Write(arg);
        }

        internal static void WriteLine(string arg)
        {
            if (!string.IsNullOrEmpty(arg))
                Console.WriteLine(arg);
        }

        internal static void WriteLine(string arg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            WriteLine(arg);
            Console.ForegroundColor = OutputColor;
        }

        internal static void Write(string arg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Write(arg);
            Console.ForegroundColor = OutputColor;
        }
    }
}
