namespace DataConverter
{
	internal class GoBackCommand : CommandBase
	{
		internal override void Invoke()
		{
			LocalScopeManager.Current.Unscope();
		}
	}
}
