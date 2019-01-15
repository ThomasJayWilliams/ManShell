namespace ManShell.BusinessObjects
{
    public interface IApplication
    {
        void RunCommand(string command);
        void Load();
    }
}
