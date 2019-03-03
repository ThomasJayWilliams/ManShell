using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DataConverter.Converters;

namespace DataConverter
{
	internal class XMLBuffer : IBuffer
	{
		private string data;

		public string Data
		{
			get { return this.data; }
		}

		public IConverter Converter { get; set; }

		public string TypeName
		{
			get { return "XML"; }
		}

		public void Convert()
		{
			this.Converter = new XMLToJSONConverter(this.data);
			this.Converter.Convert();
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
