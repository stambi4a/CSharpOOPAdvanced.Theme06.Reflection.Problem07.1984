namespace _1984.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using _1984.Interfaces;
    using _1984.Models;

    public class Engine : IEngine
    {
        private readonly IRepository repository;

        public Engine(IRepository repository)
        {
            this.repository = repository;
        }
        public void Run()
        {
            var countIterations = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var countSubjects = countIterations[0];
            for (var i = 0; i < countSubjects; i++)
            {
                var inputParams = Console.ReadLine().Split();
                var type = inputParams[0];
                var id = inputParams[1];
                var name = inputParams[2];
                if (type == "Employee")
                {
                    var income = int.Parse(inputParams[3]);
                    var employee = new Employee(name, id, income);
                    this.repository.AddSubject(id, employee);
                }
                else
                {
                    var turnover = int.Parse(inputParams[3]);
                    var revenue = int.Parse(inputParams[4]);
                    var company = new Company(name, id, turnover, revenue);
                    this.repository.AddSubject(id, company);
                }
            }

            var countInstitutions = countIterations[1];
            for (var i = 0; i < countInstitutions; i++)
            {
                var inputParams = Console.ReadLine().Split();
                var id = inputParams[1];
                var name = inputParams[2];
                var institution = new Institution(name, id);
                this.repository.AddInstitution(name, institution);
                var listWatchedData = new List<string>();
                for (var j = 3; j < inputParams.Length; j ++)
                {
                    var watchedData = inputParams[j];
                    listWatchedData.Add(watchedData);
                }

                institution.AssignDataToWatch(listWatchedData.ToArray());

                foreach (var key in this.repository.GetSubjectIds())
                {
                    var subject = this.repository.GetSubject(key);
                    institution.AddSubjectToWatch(subject);
                }
            }

            var countChanges = countIterations[2];
            for (var i = 0; i < countChanges; i++)
            {
                var inputParams = Console.ReadLine().Split();
                var id = inputParams[0];
                var name = inputParams[1];
                var value = inputParams[2];
                var subject = this.repository.GetSubject(id);
                var propertyInfo =
                    subject.GetType()
                        .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                        .FirstOrDefault(prop => prop.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));

                if (propertyInfo == null)
                {
                    continue;
                }

                if (propertyInfo.PropertyType.Name == "Int32")
                {
                    var intValue = int.Parse(value);
                    propertyInfo.SetValue(subject, intValue);
                }
                else
                {
                    propertyInfo.SetValue(subject, value);
                }
            }

            this.repository.PrintInstitutions();
        }
    }
}
