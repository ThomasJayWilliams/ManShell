﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManShell
{
    public static class OnStartUp
    {
        public static void Load()
        {
            UserInterface.ToInvoke = BaseCommandRunner.RunApp;

            ConsoleWrapper.Setup();
        }
    }
}
