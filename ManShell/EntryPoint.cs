namespace ManShell
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0)
                ConsoleWrapper.WriteLine(args[0]);

            string appGuid = System.Runtime.InteropServices.Marshal
                .GetTypeLibGuidForAssembly(System.Reflection.Assembly.GetExecutingAssembly()).ToString();
            var nonExisted = false;

            var mtx = new System.Threading.Mutex(true, appGuid, out nonExisted);

            if (!nonExisted)
            {
                ConsoleWrapper.ShowError("Application already runs!");
                System.Threading.Thread.Sleep(3000);
                return;
            }

            OnStartUp.Load();
            UserInterface.Run(args);
        }
    }
}
