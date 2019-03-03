namespace DataConverter
{
	internal class ClearCommand : CommandBase
	{
		internal override void Invoke()
		{
			BufferManager.Current.ClearBuffer();
		}
	}
}
