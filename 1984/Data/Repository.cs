namespace _1984.Data
{
    using System;
    using System.Collections.Generic;

    using _1984.Interfaces;

    public class Repository : IRepository
    {

        private readonly IDictionary<string, IInstitution> institutions;

        private readonly IDictionary<string, ISubject> subjects;
        public Repository()
        {
            this.institutions = new Dictionary<string, IInstitution>();
            this.subjects = new Dictionary<string, ISubject>();
        }

        public IInstitution GetInstitution(string name)
        {
            return this.institutions[name];
        }

        public ISubject GetSubject(string id)
        {
            return this.subjects[id];
        }

        public void AddSubject(string id, ISubject subject)
        {
            this.subjects.Add(id, subject);
        }

        public void AddInstitution(string name, IInstitution institution)
        {
            if (this.institutions.ContainsKey(name))
            {
                return;
            }

            this.institutions.Add(name, institution);
        }

        public void PrintInstitutions()
        {
            foreach (var institution in this.institutions.Values)
            {
                institution.Print();
            }
        }

        public ICollection<string> GetSubjectIds()
        {
            var keys =  this.subjects.Keys;

            return keys;
        }
    }
}
