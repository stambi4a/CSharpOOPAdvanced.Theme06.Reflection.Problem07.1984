namespace _1984.Models
{
    using System;
    using System.Text;

    using _1984.Interfaces;
    using _1984.Utilities;

    public class Change<T> : IChange<T> 
    {
        public Change(Type type, T newValue, T oldValue, string id, string name)
        {
            this.Type = type;
            this.OldValue = oldValue;
            this.NewValue = newValue;
            this.Id = id;
            this.Name = name;
        }

        public string Name { get; }
        public Type Type { get; }

        public string Id { get; }

        public T NewValue { get; }

        public T OldValue { get; }

        public override string ToString()
        {
            var valueType = typeof(T);
            var changeBuilder = new StringBuilder();
 
            changeBuilder.Append($"--{this.Type.Name}(ID:{this.Id}) changed {this.Name}");
            changeBuilder.Append($"({AliasUtility.Aliases[valueType]}) from {this.OldValue} to {this.NewValue}");

            return changeBuilder.ToString();
        }
    }
}
