namespace _1984.Interfaces
{
    using System.Collections.Generic;

    public interface IRepository
    {
        ISubject GetSubject(string id);

        IInstitution GetInstitution(string name);

        void AddSubject(string id, ISubject entity);

        void AddInstitution(string id, IInstitution institution);

        void PrintInstitutions();

        ICollection<string> GetSubjectIds();
    }
}
