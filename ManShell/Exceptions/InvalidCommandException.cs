using System;

namespace ManShell
{
    public class InvalidCommandException : Exception
    {
        private const string _defaultMessage = "Command passed to parser has invalid format!";

        public InvalidCommandException() : base(_defaultMessage) { }
        public InvalidCommandException(string message) : base(message) { }
    }
}
