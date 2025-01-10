namespace HelloWorld;

using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Chetch.Database;

class Program
{
    public class Test
    {
        public int ID { get; set; }
        public string SomeField { get; set; } = String.Empty;
    }

    public class TestDbContext : ChetchDbContext
    {
        
        public DbSet<Test> Tests { get; set; }

        public TestDbContext() : base("test"){}
    }   

    static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false);

        var settings = builder.Build();

        ChetchDbContext.Config = settings;

        using(var tdbc = new TestDbContext()){
            var test = tdbc.Tests;
            foreach(var t in tdbc.Tests){
                Console.WriteLine("ID {0}, test: {1}", t.ID, t.SomeField);
            }
        }
        
        Console.Write("Hello, World!  Press a key to continue");
        var ki = Console.ReadKey(true);
        Console.WriteLine("\nok so you've pressed: {0}", ki.KeyChar);
        Console.Write("Press any key to end...");
        Console.ReadKey(true);
    }
}
