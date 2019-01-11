using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroStorage
{
    public class ScopeInCommand : ICommand
    {
        private bool _isSuccessfull;
        private string _argument;

        public bool IsSuccessfull
        {
            get { return this._isSuccessfull; }
        }

        public string Argument
        {
            get { return this._argument; }
        }

        public ScopeInCommand(string arg)
        {
            if (arg == null)
                throw new ArgumentNullException("arg", "Argument cannot be null or empty!");
            this._argument = arg;
        }

        public void Invoke()
        {
            LocalScopeManager current = LocalScopeManager.Current;
            string data = FileManager.GetData();

            ScopeType type = DataManager.Data.Categories
                .ToList<Category>().Find(c => c.CategoryName == this._argument).GetType() == typeof(Entry) ? ScopeType.Entry
                    : ScopeType.Category;

            current.SetScope(this._argument, type);

            this._isSuccessfull = true;
        }
    }
}
