using System;

namespace MicroStorage
{
    public class EntryNotFoundException : Exception
    {
        private const string defaultMessage = "Entry has been not found!";

        public EntryNotFoundException() : base(defaultMessage) { }
        public EntryNotFoundException(string message) : base(message) { }
    }
}
