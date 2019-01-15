using System;

namespace MicroStorage
{
    public class InvalidScopeException : Exception
    {
        private const string _defaultMessage = "Invalid name of object to scope!";

        public InvalidScopeException() : base(_defaultMessage) { }
        public InvalidScopeException(string message) : base(message) { }
    }
}
