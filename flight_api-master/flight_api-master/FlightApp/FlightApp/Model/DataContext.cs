using Microsoft.EntityFrameworkCore;

namespace FlightApp.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Flight> Flights { get; set; }
    }
}
