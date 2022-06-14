using AutoMapper;
using Ocelot.Demo.Api2.Entities;
using Ocelot.Demo.Api2.Models;

namespace Ocelot.Demo.Api2.Profiles
{
    /// <summary>
    /// A PointOfInterestProfile class that defines mappings between DTOs and entities
    /// </summary>
    public class PointOfInterestProfile : Profile
    {
        public PointOfInterestProfile()
        {
            CreateMap<PointOfInterest, PointOfInterestDto>();
            CreateMap<PointOfInterestForCreationDto, PointOfInterest>();
            CreateMap<PointOfInterestForUpdateDto, PointOfInterest>();
            CreateMap<PointOfInterest, PointOfInterestForUpdateDto>();
        }
    }
}
