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
            return new JsonResult(
                new List<Object> {
                    new { id = 1, Name = "Toronto"},
                    new { id = 2, Name = "New Delhi"},
                    new { id = 3, Name = "Dallas"},
                    new { id = 4, Name = "Melbourne"}
                });
        }
    }
}
