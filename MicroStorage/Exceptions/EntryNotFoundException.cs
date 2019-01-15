using System;

namespace MicroStorage
{
    public class EntryNotFoundException : Exception
    {
        private const string _defaultMessage = "Entry has been not found!";

        public EntryNotFoundException() : base(_defaultMessage) { }
        public EntryNotFoundException(string message) : base(message) { }
    }
}
