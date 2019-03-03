using System;

namespace ManShell.BusinessObjects
{
	public class FileIsEmptyException : Exception
    {
        private const string defaultMessage = "Requested file is empty!";

        public FileIsEmptyException() : base(defaultMessage) { }
        public FileIsEmptyException(string message) : base(message) { }
    }
}
