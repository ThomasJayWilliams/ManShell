using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    public class InvalidCommandException : Exception
    {
        private const string _defaultMessage = "Invalid command!";

        public InvalidCommandException() : base(_defaultMessage) { }
        public InvalidCommandException(string message) : base(message) { }
    }
}
