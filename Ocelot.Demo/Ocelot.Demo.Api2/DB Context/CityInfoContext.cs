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
    }
}
