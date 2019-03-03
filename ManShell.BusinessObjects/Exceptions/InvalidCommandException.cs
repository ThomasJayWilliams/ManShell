using System;

namespace ManShell.BusinessObjects
{
    public class InvalidCommandException : Exception
    {
        private const string defaultMessage = "Invalid command!";

        public InvalidCommandException() : base(defaultMessage) { }
        public InvalidCommandException(string message) : base(message) { }
    }
}
