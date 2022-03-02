using CustomerApi.Models;

using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Data
{
    public class ApiCustomerDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder opttionsBuilder)
        {
            opttionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CustomerApiDb;");
        }
    }
}
