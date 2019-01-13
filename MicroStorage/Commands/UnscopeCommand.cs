using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    public class UnscopeCommand : CommandBase
    {
        public override void Invoke()
        {
            LocalScopeManager current = LocalScopeManager.Current;

            current.Unscope();

            this._isSuccessfull = true;
        }
    }
}
