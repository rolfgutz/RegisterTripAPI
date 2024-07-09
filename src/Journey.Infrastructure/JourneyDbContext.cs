using Journey.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Journey.Infrastructure
{
    public  class JourneyDbContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Batteries.Init();

            optionsBuilder.UseSqlite("Data Source=C:\\Estudo\\WorkSpace\\JourneyDatabase.db");

        }

    }
}
