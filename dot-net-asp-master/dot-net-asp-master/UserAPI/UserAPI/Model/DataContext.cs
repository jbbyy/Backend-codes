using Microsoft.EntityFrameworkCore;

namespace UserAPI.Model
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Users> Cust { get; set; }
    }
}