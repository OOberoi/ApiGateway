﻿using Microsoft.EntityFrameworkCore;
using Ocelot.Demo.Api2.Entities;

namespace Ocelot.Demo.Api2.DB_Context
{
    /// <summary>
    /// DbContext class used for EF Core ORM
    /// </summary>
    public class CityInfoContext : DbContext
    {
        /// <summary>
        /// A repsresentation of city in the db
        /// </summary>
        public DbSet<City> Cities { get; set; } = null!;

        /// <summary>
        /// Represents PointOfInterst table in the db
        /// </summary>
        public DbSet<PointOfInterest> PointOfInterests { get; set;} = null!;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public CityInfoContext(DbContextOptions<CityInfoContext> options)
            : base(options) 
        {
            
        }

        /// <summary>
        /// Typically used for connections etc., but it's now being defined in appsettings
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=DESKTOP-9AB4882;Database=Ocelot.Demo.CityInfoDB;Trusted_Connection=true;");
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Used for seeding data
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasData(new City("Toronto")
                {
                    Id = 1,
                    Description = "City known for CN Tower"
                },
                new City("Mumbai")
                {
                    Id = 2,
                    Description = "City known for Bollywood"
                },
                new City("Delhi")
                {
                    Id = 3,
                    Description = "City known for rich culture and diversity"
                },
                new City("New York")
                { 
                    Id = 4,
                    Description = "Fashion and Financial capital"
                },
                new City("Paris")
                {
                    Id = 5,
                    Description = "Fashion capital"
                }
                );
            modelBuilder.Entity<PointOfInterest>()
                .HasData(new PointOfInterest("CN Tower")
                {
                    Id = 1,
                    CityId = 1,
                    Description = "An incredible tower"
                },
                new PointOfInterest("Lake Ontario")
                {
                    Id = 2,
                    CityId = 1,
                    Description = "A city surrounded by the lake"
                },
                new PointOfInterest("Taj Hotel")
                {
                    Id = 3,
                    CityId = 2,
                    Description = "An iconic hotel and pride of India"
                },
                new PointOfInterest("Qutub Minar")
                {
                    Id=4,
                    CityId=3,
                    Description ="A historic monument"
                },
                new PointOfInterest("One World")
                {
                    Id=5,
                    CityId=4,
                    Description ="Iconic towers to replace twin towers"
                },
                new PointOfInterest("Guggenheim Museum")
                { 
                    Id=6,
                    CityId= 4,
                    Description= "An extraordinary Art Museum"
                },
                new PointOfInterest("Eifel Tower")
                { 
                    Id=7,
                    CityId=5,
                    Description="An iconic French tower"
                },
                new PointOfInterest("The Louvre")
                {
                    Id = 8,
                    CityId = 5,
                    Description = "Attest the greatness of many civilizations"
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
