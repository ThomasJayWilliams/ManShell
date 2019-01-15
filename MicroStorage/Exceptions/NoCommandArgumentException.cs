using System;

namespace MicroStorage
{
    public class NoCommandArgumentException : Exception
    {
        private const string defaultMessage = "The command reuires argument, but no arguments been found!";

        public NoCommandArgumentException() : base(defaultMessage) { }
        public NoCommandArgumentException(string message) : base(message) { }
    }
}
