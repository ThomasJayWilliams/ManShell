using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ManShell.BusinessObjects;

namespace MicroStorage
{
    public class OnLoad
    {
        public static void Load()
        {
            DataManager.Load(FileManager.GetData());

            if (DataManager.Data == null)
                Environment.Exit(1);

            LocalScopeManager.Current.SetScope(Globals.AppName.ToLower(), ScopeType.Enviroment);
        }
    }
}
