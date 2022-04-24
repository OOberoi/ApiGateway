using Microsoft.AspNetCore.Mvc;
using Ocelot.Demo.Api2.Models;
using Ocelot.Demo.Api2.Services;
using AutoMapper;

namespace Ocelot.Demo.Api2.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointsOfInterestDto>>> GetCitiesAsync()
        {
            var cityEntities = await _cityInfoRepository.GetCitiesAsync();
            return Ok(_mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities));
            //var results = new List<CityWithoutPointsOfInterestDto>();
            //foreach (var cityEntity in cityEntities)
            //{
            //    results.Add(new CityWithoutPointsOfInterestDto
            //    {
            //        Id = cityEntity.Id,
            //        Name = cityEntity.Name,
            //        Description= cityEntity.Description
            //    });
            //}
            //return Ok(results);    
        }


        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id)
        { 
            var cities = CitiesDataStore.Instance.Cities.FirstOrDefault(c => c.Id == id);

            if (cities == null)
            {
                return NotFound();                
            }
            return Ok(cities);
        }
        #region Redundant
        //public JsonResult GetCitiesOld()
        //{
        //    return new JsonResult(
        //        new List<Object> {
        //            new { id = 1, City = "Toronto"},
        //            new { id = 2, City = "New Delhi"},
        //            new { id = 3, City = "Dallas"},
        //            new { id = 4, City = "Melbourne"},
        //            new { id = 5, City = "London" }
        //        });
        //}

        //public JsonResult GetCities()
        //{
        //    return new JsonResult(CitiesDataStore.Instance.Cities);
        //}
        #endregion
    }
}
