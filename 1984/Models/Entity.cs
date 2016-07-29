namespace _1984.Models
{
    using _1984.Interfaces;
    public abstract class Entity : IEntity
    {
        protected Entity(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Id { get; }

        public virtual string  Name { get; protected set; }
    }
}
