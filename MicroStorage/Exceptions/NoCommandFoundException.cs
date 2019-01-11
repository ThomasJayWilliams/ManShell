using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    public class NoCommandException : Exception
    {
        private const string _defaultMessage = "No command to run has been found!";

        public NoCommandException() : base(_defaultMessage) { }
        public NoCommandException(string message) : base(message) { }
    }
}
