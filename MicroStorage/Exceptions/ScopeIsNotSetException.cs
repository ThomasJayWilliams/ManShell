using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    public class InvalidScopeException : Exception
    {
        private const string _defaultMessage = "Target has been not set! To execute targeted commands target must be set!";

        public InvalidScopeException() : base(_defaultMessage) { }
        public InvalidScopeException(string message) : base(message) { }
    }
}
