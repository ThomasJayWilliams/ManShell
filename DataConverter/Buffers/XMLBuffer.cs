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
		private IConverter converter;

		public string Data
		{
			get { return this.data; }
		}

		public IConverter Converter
		{
			get { return this.converter; }
		}

		public string TypeName
		{
			get { return "XML"; }
		}

		public void Convert()
		{
			this.converter = new XMLToJSONConverter(this.data);
			this.converter.Convert();
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
