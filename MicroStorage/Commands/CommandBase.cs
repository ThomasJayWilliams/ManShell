using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    public abstract class CommandBase
    {
        protected bool _isSuccessfull;
        protected string _argument;

        public bool IsSuccessfull
        {
            get { return this._isSuccessfull; }
        }

        public string Argument
        {
            get { return this._argument; }
        }

        public abstract void Invoke();
    }
}
