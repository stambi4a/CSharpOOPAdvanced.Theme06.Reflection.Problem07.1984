namespace _1984.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using _1984.Annotations;
    using _1984.Events;
    using _1984.Interfaces;
    public class ChangeLogger : IChangeLogger
    {
        private readonly List<string> logs;
        public ChangeLogger()
        {
            this.WatchedSubjectData = new List<PropertyInfo>();
            this.logs = new List<string>();
        }
    
        public List<PropertyInfo> WatchedSubjectData { get; }

        public void LogChange<T>(object sender, SubjectChangeEventArgs<T> args) 
        {
            var change = new Change<T>(args.Type, args.NewValue, args.OldValue, args.Id, args.Name);
            this.logs.Add(change.ToString());
        }

        public void AddSubjectChangeData(string[] subjectData)
        {
            this.WatchedSubjectData.AddRange(
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .SelectMany(type => type.GetProperties())
                    .Where(prop => prop.IsDefined(typeof(IsChangeableAttribute)) && subjectData.Any(dataEntry=>dataEntry.Equals(prop.Name, StringComparison.CurrentCultureIgnoreCase))).Distinct());
        }

        public void AddSubjectToWatchProgram(ISubject subject)
        {
            var type = subject.GetType();
            var subjectProps = type
                    .GetProperties()
                    .Where(prop => this.WatchedSubjectData.Any(propData => propData == prop)).Select(prop=>prop.Name);

            foreach (var propName in subjectProps)
            {
                switch (propName)
                {
                    case "Name":
                        {
                            ISubject typ = null;
                            var employee = subject as Employee;
                            if (employee != null)
                            {
                                 typ = employee;
                            }
                            else
                            {
                                typ = (Company)subject;
                            }

                            typ.ChangeName += this.LogChange;
                        }

                        break;

                    case "Income":
                        {
                            var typ = (Employee)subject;
                            typ.ChangeIncome += this.LogChange;
                        }

                        break;

                    case "Turnover":
                        {
                            var typ = (Company)subject;
                            typ.ChangeTurnover += this.LogChange;
                        }

                        break;

                    case "Revenue":
                        {
                            var typ = (Company)subject;
                            typ.ChangeRevenue += this.LogChange;
                        }

                        break;
                }
            }
        }

        public void Print()
        {
            if (this.logs.Count == 0)
            {
                return;
            }
            Console.WriteLine(this);
        }

        public int GetChangesCount()
        {
            return this.logs.Count;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.logs);
        }
    }
}
