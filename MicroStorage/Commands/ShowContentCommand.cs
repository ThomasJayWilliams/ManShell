using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    public class ShowContentCommand : CommandBase
    {
        public override void Invoke()
        {
            if (LocalScopeManager.Current.Scope.Type != ScopeType.Entry)
                throw new InvalidScopeException();

            string entryName = LocalScopeManager.Current.Scope.Name;
            Entry entry = DataManager.GetEntryByName(entryName);

            if (entry != null)
                ManShell.BusinessObjects.Globals.ToOutput = entry.EntryData;

            this._isSuccessfull = true;
        }
    }
}
