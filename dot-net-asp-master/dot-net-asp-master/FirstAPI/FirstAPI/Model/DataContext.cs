using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Model
{
    public class DataContext :DbContext 
        //DataContext inheirt DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
            //need to resolve after injecting dependency -> at program
        {
            Database.EnsureCreated();
        }

        public DbSet<Products> Products { get; set; }
    }
}
