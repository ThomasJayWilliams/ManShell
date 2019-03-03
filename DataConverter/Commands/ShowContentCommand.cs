using MBO = ManShell.BusinessObjects;

namespace DataConverter
{
	internal class ShowContentCommand : CommandBase
	{
		internal override void Invoke()
		{
			if (BufferManager.Current.Buffer == null)
				throw new BufferIsEmptyException();

			if (LocalScopeManager.Current.Scope.Type == ScopeType.Enviroment)
				throw new BufferIsEmptyException();

			else if (LocalScopeManager.Current.Scope.Type == ScopeType.Source)
				MBO.Globals.ToOutput = BufferManager.Current.Buffer.Data;

			else
				MBO.Globals.ToOutput = BufferManager.Current.Buffer.Converter.OuterString;
		}
	}
}
