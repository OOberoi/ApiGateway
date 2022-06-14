using AutoMapper;
using Ocelot.Demo.Api2.Models;
using Ocelot.Demo.Api2.Entities;

namespace Ocelot.Demo.Api2.Profiles
{
    /// <summary>
    /// A CityProfile class
    public class CityProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public CityProfile()
        {
            CreateMap<City, CityWithoutPointsOfInterestDto>();
            CreateMap<City, CityDto>();
        }
    }
}
