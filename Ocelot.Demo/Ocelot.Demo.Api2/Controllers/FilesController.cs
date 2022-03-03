using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ocelot.Demo.Api2.Controllers
{
    [Route("api/[files]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpGet("{fieldId}")]
        public ActionResult GetFile(string fileId)
        { 
         
        }
    }
}
