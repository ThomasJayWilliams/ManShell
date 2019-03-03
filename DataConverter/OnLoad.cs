using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConverter
{
	public class OnLoad
	{
		public static void LoadApp()
		{
			LocalScopeManager.SetLocalScope(Globals.AppName.ToLower(), Globals.AppName.ToLower());
		}
	}
}
