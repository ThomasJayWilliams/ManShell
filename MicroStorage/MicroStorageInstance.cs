namespace MicroStorage
{
    public sealed class MicroStorageInstance : ManShell.BusinessObjects.IApplication
    {
        private static MicroStorageInstance instance = new MicroStorageInstance();

        public static MicroStorageInstance Current
        {
            get
            {
                if (instance == null)
                    instance = new MicroStorageInstance();
                return instance;
            }
        }

        private MicroStorageInstance() { }

        public void RunCommand(string command)
        {
            CommandParser.Current.RunCommand(command);
        }

        public void Load()
        {
            OnLoad.Load();
        }
    }
}
