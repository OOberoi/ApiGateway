﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ocelot.Demo.Api2.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public class AuthenticationRequestBody
        {
            public string? UserName { get; set; }

        }


        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate()
        { 
        
        }
    }
}
