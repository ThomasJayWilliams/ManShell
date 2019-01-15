namespace MicroStorage
{
    internal class UnscopeCommand : CommandBase
    {
        internal override void Invoke()
        {
            LocalScopeManager current = LocalScopeManager.Current;

            current.Unscope();

            this._isSuccessfull = true;
        }
    }
}
