using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Ocelot.Demo.Api2.Controllers
{
    [Route("api/[files]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpGet("{fieldId}")]
        public ActionResult GetFile(string fileId)
        {
            var filePath = "Sterling.pdf";
            if (!System.IO.File.Exists(filePath))
            { 
                return NotFound();
            }
            var bytes = System.IO.File.ReadAllBytes(filePath);

        }
    }
}
