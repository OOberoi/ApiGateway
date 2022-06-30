using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace Ocelot.Demo.Api2.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        IConfiguration _configuration;
        /// <summary>
        /// Added a dependency injection
        /// </summary>
        /// <param name="configuration"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// A nested class
        /// </summary>
        public class AuthenticationRequestBody
        {
            /// <summary>
            /// Name of a user
            /// </summary>
            public string? UserName { get; set; }
            /// <summary>
            /// User password
            /// </summary>
            public string? Password { get; set; }
        }

        /// <summary>
        /// returns CityInfoUser object
        /// </summary>
        public class CityInfoUser
        {
            /// <summary>
            /// User Id
            /// </summary>
            public int UserId { get; set; }

            /// <summary>
            /// Name of a user
            /// </summary>
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string City { get; set; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="userId"></param>
            /// <param name="userName"></param>
            /// <param name="firstName"></param>
            /// <param name="lastName"></param>
            /// <param name="city"></param>
            public CityInfoUser(int userId, string userName, string firstName, string lastName, string city)
            {
                UserId = userId;
                UserName = userName;
                FirstName = firstName;
                LastName = lastName;
                City = city;
            }
        }
      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authenticationRequestBody"></param>
        /// <returns></returns>
        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(AuthenticationRequestBody authenticationRequestBody)
        {
            // validate user credentials
            var user = ValidateUserCredentials(authenticationRequestBody.UserName, authenticationRequestBody.Password);
            
            if (user == null)
            { 
                return Unauthorized();
            }

            //create a token
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:Secret"]));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // add a list of claims
            var claimsForToken = new List<Claim>();            
            claimsForToken.Add(new Claim("sub", user.UserId.ToString()));
            claimsForToken.Add(new Claim("given_name", user.FirstName));
            claimsForToken.Add(new Claim("family_name", user.LastName));
            claimsForToken.Add(new Claim("city", user.City));
             
            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow,
                signingCredentials);

            var tokenRetVal = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            
            return Ok(tokenRetVal);
        }

        private CityInfoUser ValidateUserCredentials(string? userName, string? password)
        {
            return new CityInfoUser(
                7, 
                userName ?? "ooberoi", 
                "Obi", 
                "Oberoi", 
                "Toronto");
        }
    }
    
}
