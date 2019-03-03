using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataConverter
{
	internal class JSONBuffer : IBuffer
	{
		private string data;

		public string Data
		{
			get { return this.data; }
		}

		public string TypeName
		{
			get { return "JSON"; }
		}

		public void LoadFromFile(FileInfo file)
		{
			if (file.Extension != ".json")
				throw new InvalidDataException();
			StreamReader reader = new StreamReader(file.FullName);
			this.data = reader.ReadToEnd();
			reader.Close();
		}
	}
}
