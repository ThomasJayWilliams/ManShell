using System;

namespace ManShell
{
    public class InvalidCommandException : Exception
    {
        private const string defaultMessage = "Command passed to parser has invalid format!";

        public InvalidCommandException() : base(defaultMessage) { }
        public InvalidCommandException(string message) : base(message) { }
    }
}
