using Microsoft.EntityFrameworkCore;

namespace LayeredApp.Model
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Customer> Cust { get; set; }
    }
    
}
