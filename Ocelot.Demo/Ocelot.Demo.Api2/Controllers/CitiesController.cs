using Microsoft.AspNetCore.Mvc;

namespace Ocelot.Demo.Api2.Controllers
{
    [ApiController]
    public class CitiesController : ControllerBase
    {
        public JsonResult GetCities()
        {
            return new JsonResult(
                new List<Object> {
                    new { id = 1, Name = "Toronto"},
                    new { id = 2, Name = "New Delhi"},
                    new { id = 3, Name = "Dallas"}
                });
        }
    }
}
