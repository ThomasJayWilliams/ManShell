using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConverter.Converters
{
	internal interface IConverter<T, U> : IConverter
	{
		T InnerData { get; set; }
		U OuterData { get; set; }
	}

	internal interface IConverter
	{
		string InnerString { get; set; }
		string OuterString { get; set; }
		void Convert();
	}
}
