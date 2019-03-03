using System.Collections.Generic;

namespace DataConverter
{
	public static class Globals
	{
		public const string AppName = "DataConverter";

		public static readonly List<string> SupportedExtensions = new List<string>()
		{
			".json",
			".xml"
		};
	}
}
