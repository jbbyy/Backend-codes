using Microsoft.EntityFrameworkCore;
namespace EntityDBDemo.Models
    
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options): base(options)
        {
            //passing options to the base class which is DBContext
            Database.EnsureCreated();
        }

            public DbSet<Product>Products { get; set; }
    }
}
