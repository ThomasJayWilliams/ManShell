namespace ManShell
{
    public static class OnStartUp
    {
        public static void Load()
        {
            ConsoleWrapper.Setup();
			BusinessObjects.Application.Current.Confirmation += UserInterface.ReadConfirmation;
        }
    }
}
