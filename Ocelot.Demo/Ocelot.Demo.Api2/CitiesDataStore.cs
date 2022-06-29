using Ocelot.Demo.Api2.Models;

namespace Ocelot.Demo.Api2
{
    /// <summary>
    /// Class used to initialize data
    /// </summary>
    public class CitiesDataStore
    {
        /// <summary>
        /// A list of cities
        /// </summary>
        public List<CityDto> Cities { get; set; }


        /// <summary>
        ///add a singleton
        /// </summary>
        public static CitiesDataStore Instance { get; set; } = new CitiesDataStore();

        /// <summary>
        /// Constructor - Initializor
        /// </summary>
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
                        },
                        new PointOfInterestDto() {
                            Id = 6,
                            Name = "IGI Airport",
                            Description = "World's six largest airport"
                        }
                    }                    
                },
                new CityDto()
                {
                    Id = 4,
                    Name = "New York",
                    Description = "City that doesn't sleep",
                    PointsOfInterest = new List <PointOfInterestDto>()
                    { 
                        new PointOfInterestDto { 
                            Id = 6,
                            Name = "Guganham museum",
                            Description = "Amazing museum"
                        },
                        new PointOfInterestDto {
                            Id = 7,
                            Name = "Broadway",
                            Description = "Musicals and Plays"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 5,
                    Name = "Melbourne",
                    Description = "City known for four seasons in a day",
                    PointsOfInterest = new List <PointOfInterestDto>()
                    { 
                        new PointOfInterestDto { 
                            Id = 8,
                            Name = "Myers",
                            Description= "A big mall on Bourke Street"
                        },
                        new PointOfInterestDto {
                            Id = 9,
                            Name = "St. Kilda Road",
                            Description= "Known for its gardens, beaches and culture"
                        },

                    }
                },
            };
        }

    }
}
