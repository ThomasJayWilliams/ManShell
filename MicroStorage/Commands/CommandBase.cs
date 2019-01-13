using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    internal abstract class CommandBase
    {
        protected bool _isSuccessfull;
        protected string _argument;

        internal bool IsSuccessfull
        {
            get { return this._isSuccessfull; }
        }

        internal string Argument
        {
            get { return this._argument; }
        }

        internal abstract void Invoke();
    }
}
