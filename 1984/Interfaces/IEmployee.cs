namespace _1984.Interfaces
{
    using _1984.Events;

    public interface IEmployee
    {
        int Income { get; }

        event SubjectChangeEventHandler<int> ChangeIncome;
    }
}
