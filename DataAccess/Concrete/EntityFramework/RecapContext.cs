using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework {
    public class RecapContext : DbContext {
        private const String sqlDataDBName = @"Server=(localdb)\MSSQLLocalDB;Database=ReCap;Trusted_Connection=true";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(sqlDataDBName);
        public DbSet<Car>? Cars { get; set; }
        public DbSet<Brand>? Brands { get; set; }
        public DbSet<Color>? Colors { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Rental>? Rentals { get; set; }
    }
}
