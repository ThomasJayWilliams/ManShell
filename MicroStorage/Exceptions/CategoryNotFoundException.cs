using System;

namespace MicroStorage
{
    public class CategoryNotFoundException : Exception
    {
        private const string _defaultMessage = "Category has been not found!";

        public CategoryNotFoundException() : base(_defaultMessage) { }
        public CategoryNotFoundException(string message) : base(message) { }
    }
}
