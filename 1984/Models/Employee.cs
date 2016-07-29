namespace _1984.Models
{
    using _1984.Annotations;
    using _1984.Events;
    using _1984.Interfaces;
    public class Employee : Subject, IEmployee
    {
        private int income;

        public event SubjectChangeEventHandler<int> ChangeIncome;
        public Employee(string name, string id, int income)
            : base(name, id)
        {
            this.Income = income;
        }

        [IsChangeable]
        public int Income
        {
            get
            {
                return this.income;
            }

            set
            {
                var oldValue = this.income;
                this.income = value;
                if (oldValue == value)
                {
                    return;
                }

                this.OnIncomeChange(new SubjectChangeEventArgs<int>(this.GetType(), this.income, oldValue, this.Id, "income"));
            }
        }

        public void OnIncomeChange(SubjectChangeEventArgs<int> args)
        {
            this.ChangeIncome?.Invoke(this, args);
        }

        public override void Print()
        {
            
        }
    }
}
