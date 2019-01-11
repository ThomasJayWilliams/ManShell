using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    public class EntryNotFoundException : Exception
    {
        private const string _defaultMessage = "Entry has been not found!";

        public EntryNotFoundException() : base(_defaultMessage) { }
        public EntryNotFoundException(string message) : base(message) { }
    }
}
