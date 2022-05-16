using Microsoft.AspNetCore.Http;
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
            public string? Password { get; set; }
        }

        public class CityInfoUser
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string City { get; set; }

            public CityInfoUser()
            {

            }
        }


        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(AuthenticationRequestBody authenticationRequestBody)
        {
            // validate user credentials
            var user = ValidateUserCredentials(authenticationRequestBody.UserName, authenticationRequestBody.Password);


        
        }

        private object ValidateUserCredentials(string? userName, string? password)
        {
            throw new NotImplementedException();
        }
    }
    
}
