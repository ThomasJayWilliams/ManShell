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
