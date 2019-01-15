using System;
using System.Collections.Generic;

namespace ManShell.BusinessObjects
{
    public interface IScope
    {
        string Name { get; set; }
        string TypeName { get; }
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
            get
            {
                if (this._actualScopes == null)
                    this._actualScopes = new Stack<IScope>();
                return this._actualScopes;
            }
        }

        public void AddScope(IScope scope)
        {
            if (scope == null)
                throw new ArgumentNullException();

            if (this._actualScopes.Count > 0)
                this._actualScopes.Peek().Child = scope;
            this._actualScopes.Push(scope);

            this._name = scope.Name;
        }

        public void RemoveScope()
        {
            if (this._actualScopes.Count > 1)
            {
                IScope current = this._actualScopes.Pop();
                if (current != null && current.Parent != null)
                    this._name = current.Parent.Name;
            }
        }

        public Scope(IScope actual)
        {
            if (actual == null)
                throw new ArgumentNullException();

            this._name = actual.Name;

            if (this._actualScopes == null)
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

        public void AddScope(IScope scope, T type)
        {
            this._type = type;
            base.AddScope(scope);
        }

        public void RemoveScope(T type)
        {
            this._type = type;
            base.RemoveScope();
        }
    }
}
