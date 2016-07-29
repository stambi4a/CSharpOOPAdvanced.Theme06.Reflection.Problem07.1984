namespace _1984.Interfaces
{
    using System;

    public interface IChange<out T>
    {
        Type Type { get; }
        string Id { get; }
        T NewValue { get; }

        T OldValue { get; }
    }
}
