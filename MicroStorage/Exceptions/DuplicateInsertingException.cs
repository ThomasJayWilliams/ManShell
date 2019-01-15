using System;

namespace MicroStorage
{
    public class DuplicateInsertingException : Exception
    {
        private const string _defaultMessage = "Duplicating of categories and entries is not allowed! Names should be unique.";

        public DuplicateInsertingException() : base(_defaultMessage) { }
        public DuplicateInsertingException(string message) : base(message) { }
    }
}
