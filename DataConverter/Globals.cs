using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
