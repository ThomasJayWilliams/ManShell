using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManShell.BusinessObjects
{
    public class Application
    {
        private static Application _instance = new Application();
        private static ScopeManager _scopeManager = ScopeManager.Current;
        private IApplication _currentApplication;

        public static ScopeManager ScopeManager
        {
            get
            {
                if (_scopeManager == null)
                    _scopeManager = ScopeManager.Current;
                return _scopeManager;
            }
        }

        public static Application Current
        {
            get
            {
                if (_instance == null)
                    _instance = new Application();
                return _instance;
            }
        }

        private Application() { }

        public void RunCommand(string command)
        {
            this._currentApplication.RunCommand(command);
        }

        public void LoadApplication(IApplication app)
        {
            if (app != null)
                this._currentApplication = app;
            this._currentApplication.Load();
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
            private static string _toOutput = string.Empty;
            private static List<string> _listToOutput = new List<string>();

            public static string ToOutput
            {
                get
                {
                    if (_toOutput == null)
                        _toOutput = string.Empty;
                    return _toOutput;
                }
                set
                {
                    if (value != null)
                        _toOutput = value;
                }
            }

            public static List<string> ListToOutput
            {
                get
                {
                    if (_listToOutput == null)
                        _listToOutput = new List<string>();
                    return _listToOutput;
                }
                set
                {
                    if (value != null)
                        _listToOutput = value;
                }
            }
        }
    }
}
