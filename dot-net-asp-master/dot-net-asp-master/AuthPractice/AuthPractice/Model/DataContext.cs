using Microsoft.EntityFrameworkCore;

namespace AuthPractice.Model
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Users> user { get; set; }
    }
}

