using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ocelot.Demo.Api2.Models;

namespace Ocelot.Demo.Api2.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
        {
            return Ok();
        }
    }
}
