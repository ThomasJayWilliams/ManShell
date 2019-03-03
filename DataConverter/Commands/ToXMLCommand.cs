using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConverter
{
	internal class ToXMLCommand : CommandBase
	{
		internal override void Invoke()
		{
			if (BufferManager.Current == null)
				throw new BufferIsEmptyException();
			BufferManager.Current.ConvertToXML();
			LocalScopeManager.Current.SetLocalScope("XML", ScopeType.XML);
		}
	}
}
