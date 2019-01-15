using System.Collections.Generic;

namespace ManShell.BusinessObjects
{
    public class Application
    {
        private static Application instance = new Application();
        private static ScopeManager scopeManager = ScopeManager.Current;
        private IApplication currentApplication;

        public static ScopeManager ScopeManager
        {
            get
            {
                if (scopeManager == null)
                    scopeManager = ScopeManager.Current;
                return scopeManager;
            }
        }

        public static Application Current
        {
            get
            {
                if (instance == null)
                    instance = new Application();
                return instance;
            }
        }

        private Application() { }

        public void RunCommand(string command)
        {
            this.currentApplication.RunCommand(command);
        }

        public void LoadApplication(IApplication app)
        {
            if (app != null)
                this.currentApplication = app;
            this.currentApplication.Load();
        }

        public static void UnloadApplication()
        {

        }

        public static class Globals
        {
            // Constants
            public const string GeneralAppName = "ManShell";
            public const int MaxScopesInRow = 10;

            // Static members
            private static string toOutput = string.Empty;
            private static List<string> listToOutput = new List<string>();

            public static string ToOutput
            {
                get
                {
                    if (toOutput == null)
                        toOutput = string.Empty;
                    return toOutput;
                }
                set
                {
                    if (value != null)
                        toOutput = value;
                }
            }

            public static List<string> ListToOutput
            {
                get
                {
                    if (listToOutput == null)
                        listToOutput = new List<string>();
                    return listToOutput;
                }
                set
                {
                    if (value != null)
                        listToOutput = value;
                }
            }
        }
    }
}
