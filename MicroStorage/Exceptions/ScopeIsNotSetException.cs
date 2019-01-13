using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    public class InvalidScopeException : Exception
    {
        private const string _defaultMessage = "Invalid name of object to scope!";

        public InvalidScopeException() : base(_defaultMessage) { }
        public InvalidScopeException(string message) : base(message) { }
    }
}
