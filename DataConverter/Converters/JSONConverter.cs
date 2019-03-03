using Newtonsoft.Json;
using System.Xml.Linq;

namespace DataConverter.Converters
{
	internal class JSONToXMLConverter : IConverter<string, XDocument>
	{
		public string InnerString { get; set; }
		public string OuterString { get; set; }
		public string InnerData { get; set; }
		public XDocument OuterData { get; set; }

		internal JSONToXMLConverter(string data)
		{
			if (string.IsNullOrEmpty(data))
				throw new System.NullReferenceException();
			this.InnerData = data;
		}

		public void Convert()
		{
			if (this.InnerData == null)
				throw new System.NullReferenceException();
			this.OuterData = JsonConvert.DeserializeXNode(this.InnerData.ToString());
		}
	}
}
