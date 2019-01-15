using System;

namespace MicroStorage
{
    public class InvalidCommandException : Exception
    {
        private const string _defaultMessage = "Invalid command!";

        public InvalidCommandException() : base(_defaultMessage) { }
        public InvalidCommandException(string message) : base(message) { }
    }
}
