namespace _1984.Models
{
    using System;
    using System.Collections.Generic;

    using _1984.Interfaces;
    public class Institution : Subject, IInstitution
    {
        public Institution(string name, string id)
            : base(name, id)
        {
            this.ChangeLogger = new ChangeLogger();
        }

        public IChangeLogger ChangeLogger { get; }


        public int GetChangesCount()
        {
            return this.ChangeLogger.GetChangesCount();
        }

        public void AddSubjectToWatch(ISubject subject)
        {
            this.ChangeLogger.AddSubjectToWatchProgram(subject);
        }

        public void AssignDataToWatch(string[] subjectData)
        {
            this.ChangeLogger.AddSubjectChangeData(subjectData);
        }

        public override void Print()
        {
            Console.WriteLine(this);
            this.ChangeLogger.Print();
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.GetChangesCount()} changes registered";
        }
    }
}
