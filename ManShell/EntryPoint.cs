using System;

namespace ManShell
{
    public class EntryPoint
    {
        /*
         * TODO:
         *      Write wrapper for exceptions
         *      Write help and other commands
         *      Add Scope class with Scope ParentScope field
         *      Add reference on parent scope to CurrentScope
        */

        public static void Main(string[] args)
        {
            OnStartUp.Load();
            UserInterface.Run();
        }
    }
}
