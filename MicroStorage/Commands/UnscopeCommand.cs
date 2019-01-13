using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    internal class UnscopeCommand : CommandBase
    {
        internal override void Invoke()
        {
            LocalScopeManager current = LocalScopeManager.Current;

            current.Unscope();

            this._isSuccessfull = true;
        }
    }
}
