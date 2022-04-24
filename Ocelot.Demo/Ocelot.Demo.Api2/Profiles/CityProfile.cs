using AutoMapper;
using Ocelot.Demo.Api2.Models;
using Ocelot.Demo.Api2.Entities;

namespace Ocelot.Demo.Api2.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityWithoutPointsOfInterestDto>();
        }
    }
}
