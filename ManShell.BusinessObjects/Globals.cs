using System.Collections.Generic;

namespace ManShell.BusinessObjects
{
	public static class Globals
	{
		// Constants
		public const string GeneralAppName = "ManShell";
		public const int MaxScopesInRow = 10;

		// Static members
		private static string toOutput = string.Empty;
		private static List<string> listToOutput = new List<string>();

		public static string ToOutput
		{
			get
			{
				if (toOutput == null)
					toOutput = string.Empty;
				return toOutput;
			}
			set
			{
				if (value != null)
					toOutput = value;
			}
		}

		public static List<string> ListToOutput
		{
			get
			{
				if (listToOutput == null)
					listToOutput = new List<string>();
				return listToOutput;
			}
			set
			{
				if (value != null)
					listToOutput = value;
			}
		}
	}
}
