using System;

namespace MicroStorage
{
    internal class AppCloseCommand : CommandBase
    {
        internal override void Invoke()
        {
            DataManager.ParseToJSON();
            FileManager.Save(DataManager.JSON);
            Environment.Exit(0);

            this.isSuccessfull = true;
        }
    }
}
