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

    //a comment
    public class TestDbContext : ChetchDbContext
    {
        public DbSet<Test> tests { get; set; }

        public TestDbContext() : base("test"){}
    }   

    static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false);

        var settings = builder.Build();

        ChetchDbContext.Config = settings;

        using(var tdbc = new TestDbContext()){

            foreach(var t in tdbc.tests){
                Console.WriteLine("ID {0}, test: {1}", t.ID, t.SomeField);
            }
        }

        
        Console.Write("Press any key to end...");
        Console.ReadKey(true);
    }
}
