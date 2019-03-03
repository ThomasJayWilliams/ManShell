using System;

namespace ManShell.BusinessObjects
{
    public class NoCommandException : Exception
    {
        private const string defaultMessage = "No command to run has been found!";

        public NoCommandException() : base(defaultMessage) { }
        public NoCommandException(string message) : base(message) { }
    }
}
