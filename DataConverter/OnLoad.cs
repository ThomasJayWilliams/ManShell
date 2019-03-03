namespace DataConverter
{
	public class OnLoad
	{
		public static void LoadApp()
		{
			LocalScopeManager.Current.SetLocalScope(Globals.AppName.ToLower(), ScopeType.Enviroment);
		}
	}
}
