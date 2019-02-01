using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    public class FileIsEmptyException : Exception
    {
        private const string defaultMessage = "Requested file is empty!";

        public FileIsEmptyException() : base(defaultMessage) { }
        public FileIsEmptyException(string message) : base(message) { }
    }
}
