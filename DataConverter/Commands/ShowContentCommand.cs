namespace DataConverter
{
	internal class ShowContentCommand : CommandBase
	{
		internal override void Invoke()
		{
			if (BufferManager.Current.Buffer == null)
				throw new BufferIsEmptyException();
			ManShell.BusinessObjects.Globals.ToOutput = BufferManager.Current.Buffer.Data;
		}
	}
}
