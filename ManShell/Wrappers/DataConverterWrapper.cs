using ManShell.BusinessObjects;
using DataConverter;

namespace ManShell
{
	public class DataConverterWrapper : IWrapper
	{
		public DataConverterWrapper()
		{
			Application.Current.LoadApplication(DataConverterInstance.Current);
		}

		public void RunApplication(string command)
		{
			Application.Current.RunCommand(command);
		}
	}
}
