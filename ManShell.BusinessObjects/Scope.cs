using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ManShell.BusinessObjects
{
    public interface IScope
    {
        string Name { get; set; }
        IScope Parent { get; set; }
        IScope Child { get; set; }
    }

    public class Scope
    {
        protected string _name;
        protected Stack<IScope> _actualScopes;

        public string Name
        {
            get { return this._name; }
        }

        public Stack<IScope> ActualScopes
        {
            get { return this._actualScopes; }
        }

        public Scope(IScope actual)
        {
            if (actual == null)
                throw new ArgumentNullException();

            this._name = actual.Name;
            this._actualScopes = new Stack<IScope>();
            this._actualScopes.Push(actual);
        }
    }

    public class Scope<T> : Scope where T : struct
    {
        protected T _type;

        public T Type
        {
            get { return this._type; }
        }

        public Scope(IScope actual, T type) : base(actual)
        {
            this._type = type;
        }
    }
}
