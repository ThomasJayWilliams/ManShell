using ManShell.BusinessObjects;

namespace MicroStorage
{
	internal class HelpCommand : CommandBase
    {
        internal override void Invoke()
        {
            var helpInfo = FileManager.GetHelpInfo();

            if (!string.IsNullOrEmpty(helpInfo))
                ManShell.BusinessObjects.Globals.ToOutput = helpInfo;

            else
                throw new FileIsEmptyException("help.txt is empty!");
        }
    }
}
