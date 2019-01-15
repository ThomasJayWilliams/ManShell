namespace MicroStorage
{
    public class MicroStorageInstance : ManShell.BusinessObjects.IApplication
    {
        private static MicroStorageInstance _instance = new MicroStorageInstance();

        public static MicroStorageInstance Current
        {
            get
            {
                if (_instance == null)
                    _instance = new MicroStorageInstance();
                return _instance;
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
