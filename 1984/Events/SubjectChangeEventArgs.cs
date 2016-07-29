namespace _1984.Events
{
    using System;
    public class SubjectChangeEventArgs<T> : EventArgs
    {
        public SubjectChangeEventArgs(Type type, T newValue, T oldValue, string id, string name)
        {
            this.Type = type;
            this.NewValue = newValue;
            this.OldValue = oldValue;
            this.Id = id;
            this.Name = name;
        }

        public string Name { get; }
        public Type Type { get; }
        public string Id { get; }
        public T OldValue { get; }

        public T NewValue { get; }
    }
}
