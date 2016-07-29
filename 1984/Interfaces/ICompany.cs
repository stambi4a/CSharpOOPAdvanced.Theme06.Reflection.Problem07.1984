namespace _1984.Interfaces
{
    using _1984.Events;

    public interface ICompany
    {
        int Turnover { get; }

        int Revenue { get; }

        event SubjectChangeEventHandler<int> ChangeRevenue;

        event SubjectChangeEventHandler<int> ChangeTurnover;
    }
}
