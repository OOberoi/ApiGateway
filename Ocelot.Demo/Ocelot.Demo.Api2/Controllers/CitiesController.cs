using Microsoft.AspNetCore.Mvc;
using Ocelot.Demo.Api2.Models;
using Ocelot.Demo.Api2.Services;

namespace Ocelot.Demo.Api2.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;

        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
            try
            {
                return Ok(CitiesDataStore.Instance.Cities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
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
