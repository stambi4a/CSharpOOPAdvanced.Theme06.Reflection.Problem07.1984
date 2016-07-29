namespace _1984
{
    using _1984.Core;
    using _1984.Data;

    public class Program
    {
        private static void Main(string[] args)
        {
            var repository = new Repository();
            var engine = new Engine(repository);
            engine.Run();
        }
    }
}
