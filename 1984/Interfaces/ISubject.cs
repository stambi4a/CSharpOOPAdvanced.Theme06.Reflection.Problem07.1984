namespace _1984.Interfaces
{
    using _1984.Events;

    public interface ISubject : IEntity
    {
        event SubjectChangeEventHandler<string> ChangeName;

        void Print();
    }
}
