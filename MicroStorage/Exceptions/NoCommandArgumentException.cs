using System;

namespace MicroStorage
{
    public class NoCommandArgumentException : Exception
    {
        private const string _defaultMessage = "The command reuires argument, but no arguments been found!";

        public NoCommandArgumentException() : base(_defaultMessage) { }
        public NoCommandArgumentException(string message) : base(message) { }
    }
}
