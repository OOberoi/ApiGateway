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
                    Description = "City known for CN Tower"                
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Mumbai",
                    Description = "City known for Bollywood"
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "New Delhi",
                    Description = "City known for rich culture and vibrancy"
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
