using Ocelot.Demo.Api2.Models;

namespace Ocelot.Demo.Api2
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        //add a singleton
        public static CitiesDataStore Instance { get; set; } = new CitiesDataStore();

        public CitiesDataStore()
        {
            // data initialization
            Cities = new List<CityDto>()
            { 
                new CityDto()
                {
                    Id = 1,
                    Name = "Toronto",
                    Description = "City known for CN Tower",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    { 
                        new PointOfInterestDto() { 
                            Id = 1,
                            Name = "Niagra Falls",
                            Description = "One of the seven wonders of the world!"
                        },
                        new PointOfInterestDto() { 
                            Id = 2,
                            Name = "CN Tower",
                            Description = "The tallest building in Canada"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Mumbai",
                    Description = "City known for Bollywood",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                            new PointOfInterestDto() {
                                Id= 3,
                                Name = "Bollywood",
                                Description= "The city where bollywood movies are made!"
                            },
                            new PointOfInterestDto() {
                                Id= 4,
                                Name = "Monuments",
                                Description= "The city is known for its architectural heritage and monuments!"
                            }
                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "New Delhi",
                    Description = "City known for rich culture and diversity",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    { 
                        new PointOfInterestDto {
                            Id= 5,
                            Name = "Cannought Place",
                            Description = "Shopping Malls and a Circular Park"
                        }
                    }                    
                },
                new CityDto()
                {
                    Id = 4,
                    Name = "New York",
                    Description = "City that doesn't sleep"
                },
                new CityDto()
                {
                    Id = 5,
                    Name = "Melbourne",
                    Description = "City known for four seasons in a day"
                },
            };
        }

    }
}
