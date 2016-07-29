namespace _1984.Models
{
    using _1984.Annotations;
    using _1984.Events;
    using _1984.Interfaces;
    public class Company : Subject, ICompany
    {
        private int turnover;

        private int revenue;

        public event SubjectChangeEventHandler<int> ChangeRevenue;

        public event SubjectChangeEventHandler<int> ChangeTurnover;
        public Company(string name, string id, int turnover, int revenue)
            : base(name, id)
        {
            this.Turnover = turnover;
            this.Revenue = revenue;
        }

        [IsChangeable]
        public int Turnover
        {
            get
            {
                return this.turnover;
            }

            set
            {
                var oldValue = this.turnover;
                this.turnover = value;
                if (oldValue == value)
                {
                    return;
                }

                this.OnTurnoverChange(new SubjectChangeEventArgs<int>(this.GetType(), this.turnover, oldValue, this.Id, "turnover"));
            }
        }

        [IsChangeable]
        public int Revenue
        {
            get
            {
                return this.revenue;
            }

            set
            {
                var oldValue = this.revenue;
                this.revenue = value;
                if (oldValue == value)
                {
                    return;
                }

                this.OnRevenueChange(new SubjectChangeEventArgs<int>(this.GetType(), this.revenue, oldValue, this.Id, "revenue"));
            }
        }

        public void OnTurnoverChange(SubjectChangeEventArgs<int> args)
        {
            this.ChangeTurnover?.Invoke(this, args);
        }

        public void OnRevenueChange(SubjectChangeEventArgs<int> args)
        {
            this.ChangeRevenue?.Invoke(this, args);
        }

        public override void Print()
        {
            
        }
    }
}
