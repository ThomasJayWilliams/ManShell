using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    public class NoCommandArgumentException : Exception
    {
        private const string _defaultMessage = "The command reuires argument, but no arguments been found!";

        public NoCommandArgumentException() : base(_defaultMessage) { }
        public NoCommandArgumentException(string message) : base(message) { }
    }
}
