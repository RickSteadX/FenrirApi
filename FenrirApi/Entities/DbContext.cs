using Microsoft.EntityFrameworkCore;

namespace FenrirApi.Entities
{
    public class FenrirDbContext : DbContext
    {
        public FenrirDbContext(DbContextOptions<FenrirDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        //Seed the database with test data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed test Persons
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe" },
                new Person { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Doe" },
                new Person { Id = Guid.NewGuid(), FirstName = "Alice", LastName = "Smith" }
            );
        }
    }
}
