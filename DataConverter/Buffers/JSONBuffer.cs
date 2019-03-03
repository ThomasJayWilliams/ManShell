using DataConverter.Converters;
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

		public IConverter Converter { get; set; }

		public string TypeName
		{
			get { return "JSON"; }
		}

		public void Convert()
		{
			this.Converter = new JSONToXMLConverter(this.data);
			this.Converter.Convert();
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
