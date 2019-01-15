using System;

namespace MicroStorage
{
    public class InvalidScopeException : Exception
    {
        private const string defaultMessage = "Invalid name of object to scope!";

        public InvalidScopeException() : base(defaultMessage) { }
        public InvalidScopeException(string message) : base(message) { }
    }
}
