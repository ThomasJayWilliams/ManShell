using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    public class AppCloseCommand : CommandBase
    {
        public AppCloseCommand(string arg)
        {
            if (arg == null)
                throw new ArgumentNullException("arg", "Argument cannot be null or empty!");
            this._argument = arg;
        }

        public override void Invoke()
        {
            DataManager.ParseToJSON();
            FileManager.Save(DataManager.JSON);
            Environment.Exit(0);

            this._isSuccessfull = true;
        }
    }
}
