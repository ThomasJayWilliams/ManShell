using System;
using System.Collections.Generic;
using System.Linq;

using ManShell.BusinessObjects;

namespace ManShell
{
    internal static class ConsoleWrapper
    {
        internal static ConsoleColor scopeColor = ConsoleColor.Yellow;
        internal static ConsoleColor outputColor = ConsoleColor.Gray;
        internal static ConsoleColor inputColor = ConsoleColor.Gray;
        internal static ConsoleColor splitterColor = ConsoleColor.Yellow;
        internal static ConsoleColor elementNameColor = ConsoleColor.Cyan;
        internal static ConsoleColor pointerColor = ConsoleColor.Green;
        internal static ConsoleColor errorColor = ConsoleColor.Red;

        internal static void Setup()
        {
            Console.ResetColor();
            Console.Clear();
        }

        internal static void ShowError(string errorText)
        {
            if (!string.IsNullOrEmpty(errorText))
                WriteLine(errorText, errorColor);
        }

        internal static string Read()
        {
            Console.ForegroundColor = inputColor;
            string result = Console.ReadLine();
            Console.ForegroundColor = outputColor;

            if (result == null)
                result = string.Empty;

            return result;
        }

        internal static void WriteScope()
        {
            Scope currentScope = Application.ScopeManager.GetCurrentScope();
            var tempStack = new Stack<IScope>(currentScope.ActualScopes.ToArray<IScope>());
            var typeName = string.Empty;

            for (int i = 0; i < currentScope.ActualScopes.Count; i++)
            {
                IScope scope = tempStack.Pop();
                if (scope != null)
                {
                    Write(scope.Name, scopeColor);

                    if (i == currentScope.ActualScopes.Count - 1 && !string.IsNullOrEmpty(scope.TypeName))
                    {
                        typeName = "(" + scope.TypeName.ToLower() + ")";
                            Write(typeName, elementNameColor);
                    }

                    else if (i < currentScope.ActualScopes.Count - 1)
                        Write("/", splitterColor);
                }
            }

            Write(" ~", pointerColor);
            Write("\n$ ", outputColor);
        }

        internal static void Write(string arg)
        {
            if (!string.IsNullOrEmpty(arg))
                Console.Write(arg);
        }

        internal static void WriteEmptyLine()
        {
            Console.WriteLine(" ");
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
            Console.ForegroundColor = outputColor;
        }

        internal static void Write(string arg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Write(arg);
            Console.ForegroundColor = outputColor;
        }
    }
}
