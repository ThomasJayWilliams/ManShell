namespace DataConverter
{
	internal class ToJSONCommand : CommandBase
	{
		internal override void Invoke()
		{
			if (BufferManager.Current == null)
				throw new BufferIsEmptyException();
			BufferManager.Current.ConvertToJSON();
			LocalScopeManager.Current.SetLocalScope("JSON", ScopeType.JSON);
		}
	}
}
