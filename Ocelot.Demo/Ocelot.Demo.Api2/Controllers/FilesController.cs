using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.IO;

namespace Ocelot.Demo.Api2.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider fileExtensionContentTypeProvider;

        public FilesController()
        {

        }

        //todo: to supply the absolute path
        private static readonly string appPath = Directory.GetCurrentDirectory();

        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {  
            var fileName = "Sterling.pdf";
            var filePath = Path.Combine(appPath, fileName);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "text/plan", Path.GetFileName(filePath));
        }
    }
}
