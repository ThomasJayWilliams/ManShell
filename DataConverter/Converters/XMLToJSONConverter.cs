using System.Xml.Linq;
using Newtonsoft.Json;

namespace DataConverter.Converters
{
	internal class XMLToJSONConverter : IConverter<XDocument, string>
	{
		public string InnerString { get; set; }
		public string OuterString { get; set; }
		public XDocument InnerData { get; set; }
		public string OuterData { get; set; }

		internal XMLToJSONConverter(string data)
		{
			if (string.IsNullOrEmpty(data))
				throw new System.NullReferenceException();
			this.InnerData = XDocument.Parse(data);
		}

		public void Convert()
		{
			if (this.InnerData == null)
				throw new System.NullReferenceException();
			this.OuterData = JsonConvert.SerializeXNode(this.InnerData);
			this.OuterString = JsonConvert.SerializeXNode(this.InnerData);
		}
	}
}
