using Microsoft.AspNetCore.Mvc;

namespace Ocelot.Demo.Api2.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        //HttpGet("api/cities")]   

        public JsonResult GetCities()
        {
            return new JsonResult(CitiesDataStore.Instance.Cities);
                
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
        #endregion
    }
}
