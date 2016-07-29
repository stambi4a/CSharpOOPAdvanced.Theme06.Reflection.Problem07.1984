namespace _1984.Models
{
    using _1984.Annotations;
    using _1984.Events;
    using _1984.Interfaces;

    public abstract class Subject: Entity, ISubject
    {
        private string name;

        public event SubjectChangeEventHandler<string> ChangeName;

        protected Subject(string name, string id)
            : base(name, id)
        {
        }
       
        [IsChangeable]
        public override string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                var oldValue = this.name;
                this.name = value;
                if (oldValue == null || oldValue == this.name)
                {
                    return;
                }

                this.OnNameChange(new SubjectChangeEventArgs<string>(this.GetType(), this.name, oldValue, this.Id, "name"));
            }
        }

        public void OnNameChange(SubjectChangeEventArgs<string> args)
        {
            this.ChangeName?.Invoke(this, args);
        }

        public abstract void Print();
    }
}
