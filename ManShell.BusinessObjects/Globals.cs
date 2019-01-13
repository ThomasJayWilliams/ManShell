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
    }
}
