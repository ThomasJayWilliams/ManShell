using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConverter
{
	public class DataConverterInstance : ManShell.BusinessObjects.IApplication
	{
		private static DataConverterInstance instance = new DataConverterInstance();

		public static DataConverterInstance Current
		{
			get
			{
				if (instance == null)
					instance = new DataConverterInstance();
				return instance;
			}
		}

		private DataConverterInstance() { }

		public void Load()
		{
			OnLoad.LoadApp();
		}

		public void RunCommand(string command)
		{
			CommandParser.Current.RunCommand(command);
		}
	}
}
