using Microsoft.EntityFrameworkCore;
using WebGame.Core.Models;
using WebGame.Core.Models.Geography;

namespace WebGame.Data
{
    public class WebGameContext : DbContext
    {
        public WebGameContext(DbContextOptions options)
               : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Player> Players { get; set; }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Planet> Planets { get; set; }
    }
}
