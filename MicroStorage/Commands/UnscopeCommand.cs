namespace MicroStorage
{
    internal class UnscopeCommand : CommandBase
    {
        internal override void Invoke()
        {
            LocalScopeManager.Current.Unscope();

            this.isSuccessfull = true;
        }
    }
}
