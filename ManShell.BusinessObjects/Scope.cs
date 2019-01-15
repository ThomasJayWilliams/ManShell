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
        protected string name;
        protected Stack<IScope> actualScopes;

        public string Name
        {
            get { return this.name; }
        }

        public Stack<IScope> ActualScopes
        {
            get
            {
                if (this.actualScopes == null)
                    this.actualScopes = new Stack<IScope>();
                return this.actualScopes;
            }
        }

        public void AddScope(IScope scope)
        {
            if (scope == null)
                throw new ArgumentNullException();

            if (this.actualScopes.Count > 0)
                this.actualScopes.Peek().Child = scope;
            this.actualScopes.Push(scope);

            this.name = scope.Name;
        }

        public void RemoveScope()
        {
            if (this.actualScopes.Count > 1)
            {
                IScope current = this.actualScopes.Pop();
                if (current != null && current.Parent != null)
                    this.name = current.Parent.Name;
            }
        }

        public Scope(IScope actual)
        {
            if (actual == null)
                throw new ArgumentNullException();

            this.name = actual.Name;

            if (this.actualScopes == null)
                this.actualScopes = new Stack<IScope>();
            this.actualScopes.Push(actual);
        }
    }

    public class Scope<T> : Scope where T : struct
    {
        protected T type;

        public T Type
        {
            get { return this.type; }
        }

        public Scope(IScope actual, T type) : base(actual)
        {
            this.type = type;
        }

        public void AddScope(IScope scope, T type)
        {
            this.type = type;
            base.AddScope(scope);
        }

        public void RemoveScope(T type)
        {
            this.type = type;
            base.RemoveScope();
        }
    }
}
