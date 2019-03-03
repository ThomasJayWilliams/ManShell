namespace DataConverter
{
	internal class JSONToXMLCommand : CommandBase
	{
		internal override void Invoke()
		{
			if (BufferManager.Current == null)
				throw new BufferIsEmptyException();
			BufferManager.Current.Buffer.Convert();
		}
	}
}
