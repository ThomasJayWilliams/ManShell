using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    internal class AppCloseCommand : CommandBase
    {
        internal override void Invoke()
        {
            DataManager.ParseToJSON();
            FileManager.Save(DataManager.JSON);
            Environment.Exit(0);

            this._isSuccessfull = true;
        }
    }
}
