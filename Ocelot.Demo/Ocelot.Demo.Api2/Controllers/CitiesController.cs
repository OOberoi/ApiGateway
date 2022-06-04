using Microsoft.AspNetCore.Mvc;
using Ocelot.Demo.Api2.Models;
using Ocelot.Demo.Api2.Services;
using AutoMapper;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace Ocelot.Demo.Api2.Controllers
{
    [ApiController]
    //[Authorize]
     [ApiVersion("1.0")]
     [ApiVersion("2.0")]    
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;
        private const int maxPageSize = 20;

        public CitiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            _cityInfoRepository = cityInfoRepository ?? 
                throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }
        
        [HttpGet]
        //[FromQuery] is optional and is typically used for reading purposes. It's not a required a!
        public async Task<ActionResult<IEnumerable<CityWithoutPointsOfInterestDto>>> GetCitiesAsync(
            [FromQuery] string? name, string? searchQuery, int pageNum = 1, int pageSize=10)
        {
            pageSize = pageSize > maxPageSize ? maxPageSize : pageSize;
            var (cityEntities, paginationMetadata) = await _cityInfoRepository.GetCitiesAsync(name, searchQuery, pageNum, pageSize);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));
            return Ok(_mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities)); 
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityAsync(int id, bool includePointsOfInterest = false)
        { 
            var city = await _cityInfoRepository.GetCityAsync(id, includePointsOfInterest);

            if (city == null)
            { 
                return NotFound();                
            }

            // If PointsOfInterest have to be included, then map to CityDto, else map to 
            // CityWithoutPointsOfInterestDto
            if (includePointsOfInterest)
            { 
                return Ok(_mapper.Map<CityDto>(city));
            }
            return Ok(_mapper.Map<CityWithoutPointsOfInterestDto>(city ));
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
