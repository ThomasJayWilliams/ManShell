using System;

namespace MicroStorage
{
    public class CategoryNotFoundException : Exception
    {
        private const string defaultMessage = "Category has been not found!";

        public CategoryNotFoundException() : base(defaultMessage) { }
        public CategoryNotFoundException(string message) : base(message) { }
    }
}
