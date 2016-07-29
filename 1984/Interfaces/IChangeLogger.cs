namespace _1984.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using _1984.Events;

    public interface IChangeLogger
    {
        List<PropertyInfo> WatchedSubjectData { get; }

        void LogChange<T>(object sender, SubjectChangeEventArgs<T> args);

        void AddSubjectChangeData(string[] subjectData);

        void AddSubjectToWatchProgram(ISubject subject);

        void Print();

        int GetChangesCount();
    }
}
