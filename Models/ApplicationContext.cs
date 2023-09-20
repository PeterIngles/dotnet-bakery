using Microsoft.EntityFrameworkCore;
namespace DotnetBakery.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

        //Here is where we tell EF which of our models we'd like to have db tables for
        public DbSet<Baker> Bakers {get; set;}
        //             👆      👆
        //    name of class   name of the db table
    }
}

