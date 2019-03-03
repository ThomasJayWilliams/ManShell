using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataConverter
{
	internal class XMLBuffer : IBuffer
	{
		private string data;

		public string Data
		{
			get { return this.data; }
		}

		public string TypeName
		{
			get { return "XML"; }
		}

		public void LoadFromFile(FileInfo file)
		{
			if (file.Extension != ".xml")
				throw new InvalidDataException();
			StreamReader reader = new StreamReader(file.FullName);
			this.data = reader.ReadToEnd();
			reader.Close();
		}
	}
}
