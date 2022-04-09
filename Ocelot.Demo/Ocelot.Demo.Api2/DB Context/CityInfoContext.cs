using Microsoft.EntityFrameworkCore;
using Ocelot.Demo.Api2.Entities;

namespace Ocelot.Demo.Api2.DB_Context
{
    public class CityInfoContext : DbContext
    {
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<PointOfInterest> PointOfInterests { get; set;} = null!;

        public CityInfoContext(DbContextOptions<CityInfoContext> options)
            : base(options) 
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-9AB4882;Database=Ocelot.Demo.CityInfoDB;Trusted_Connection=true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasData(new City("Toronto")
                {
                    Description = "City known for CN Tower"
                },
                new City("Mumbai")
                {
                    Description = "City known for Bollywood"
                },
                new City("Delhi")
                {
                    Description = "City known for rich culture and diversity"
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
