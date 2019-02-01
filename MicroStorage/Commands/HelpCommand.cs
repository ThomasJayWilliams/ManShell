using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    internal class HelpCommand : CommandBase
    {
        internal override void Invoke()
        {
            var helpInfo = FileManager.GetHelpInfo();

            if (!string.IsNullOrEmpty(helpInfo))
                ManShell.BusinessObjects.Application.Globals.ToOutput = helpInfo;

            else
                throw new FileIsEmptyException("help.txt is empty!");
        }
    }
}
