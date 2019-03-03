namespace DataConverter
{
	internal class ClearCommand : CommandBase
	{
		internal override void Invoke()
		{
			BufferManager.Current.ClearBuffer();
			LocalScopeManager.Current.SetLocalScope(Globals.AppName.ToLower(), ScopeType.Enviroment);
		}
	}
}
