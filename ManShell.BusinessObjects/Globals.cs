using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManShell.BusinessObjects
{
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
