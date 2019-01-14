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
        internal static ConsoleColor ScopeColor = ConsoleColor.Yellow;
        internal static ConsoleColor OutputColor = ConsoleColor.Gray;
        internal static ConsoleColor InputColor = ConsoleColor.Gray;
        internal static ConsoleColor SplitterColor = ConsoleColor.Yellow;
        internal static ConsoleColor ElementNameColor = ConsoleColor.Cyan;
        internal static ConsoleColor PointerColor = ConsoleColor.Green;
        internal static ConsoleColor ErrorColor = ConsoleColor.Red;

        internal static void Setup()
        {
            Console.ResetColor();
            Console.Clear();
        }

        internal static void ShowError(string errorText)
        {
            if (!string.IsNullOrEmpty(errorText))
                WriteLine(errorText, ErrorColor);
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
            Stack<IScope> tempStack = new Stack<IScope>(currentScope.ActualScopes.ToArray<IScope>());
            string typeName = string.Empty;

            for (int i = 0; i < currentScope.ActualScopes.Count; i++)
            {
                IScope scope = tempStack.Pop();
                if (scope != null)
                {
                    Write(scope.Name, ScopeColor);

                    if (i == currentScope.ActualScopes.Count - 1 && !string.IsNullOrEmpty(scope.TypeName))
                    {
                        typeName = "(" + scope.TypeName.ToLower() + ")";
                            Write(typeName, ElementNameColor);
                    }

                    else if (i < currentScope.ActualScopes.Count - 1)
                        Write("/", SplitterColor);
                }
            }

            Write(" ~", PointerColor);
            Write("\n$ ", OutputColor);
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
