namespace _1984.Interfaces
{
    public interface IInstitution
    {
        IChangeLogger ChangeLogger { get; }

        void Print();

        int GetChangesCount();

        void AddSubjectToWatch(ISubject subject);

        void AssignDataToWatch(string[] subjectData);
    }
}
