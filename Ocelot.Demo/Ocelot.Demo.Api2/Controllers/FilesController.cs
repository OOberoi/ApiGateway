﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Ocelot.Demo.Api2.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/files")]
    //[Authorize]
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileExtensionContentTypeProvider"></param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider
                ?? throw new System.ArgumentNullException(nameof(fileExtensionContentTypeProvider));
        }

        //todo: to supply the absolute path
        private static readonly string appPath = Directory.GetCurrentDirectory();

        /// <summary>
        /// Returns a file content
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {  
            var fileName = "Sterling.pdf";
            var filePath = Path.Combine(appPath + "\\" + "files" + "\\" + fileName);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }
            // Is used for any file extension
            if (!_fileExtensionContentTypeProvider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, contentType, Path.GetFileName(filePath));
        }
    }
}
