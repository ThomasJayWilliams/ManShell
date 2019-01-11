using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MicroStorage;

namespace ManShell
{
    public static class OnStartUp
    {
        public static void Load()
        {
            MicroStorage.OnLoad.Load();

            ConsoleWrapper.Setup();
        }
    }
}
