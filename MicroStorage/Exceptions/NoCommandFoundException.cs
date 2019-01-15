using System;

namespace MicroStorage
{
    public class NoCommandException : Exception
    {
        private const string _defaultMessage = "No command to run has been found!";

        public NoCommandException() : base(_defaultMessage) { }
        public NoCommandException(string message) : base(message) { }
    }
}
