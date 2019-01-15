namespace ManShell
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            OnStartUp.Load();
            UserInterface.Run();
        }
    }
}
