using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Ocelot.Demo.Api2.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        //todo: to supply the absolute path
        private static readonly string appPath = Directory.GetCurrentDirectory();


        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            var fileName = "Sterling.pdf";
            if (!System.IO.File.Exists( fileName))
            { 
                return NotFound();
            }
            var bytes = System.IO.File.ReadAllBytes(fileName);
            return File(bytes, "text/plan", Path.GetFileName(fileName));
        }
    }
}
