namespace MicroStorage
{
    internal abstract class CommandBase
    {
        protected bool isSuccessfull;
        protected string argument;

        internal bool IsSuccessfull
        {
            get { return this.isSuccessfull; }
        }

        internal string Argument
        {
            get { return this.argument; }
        }

        internal abstract void Invoke();
    }
}
