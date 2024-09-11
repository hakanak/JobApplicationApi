using JobApplicationApi.Model;
using JobApplicationApi.Reporsitory;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // GET: api/<AuthController>
        //[HttpPost]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        SystemRepository sys=new SystemRepository();
        TokenRepository tkn = new TokenRepository("90b3b0b3743dde3acf7abf101f544540b1033d7075e121e12330c60c110d8662ca101da07136c4112", 60); 

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(logindto userForLogin)
        {
            UserDto userToLogin = sys.Login(userForLogin);
            if (!userToLogin.issuccesfull)
            {
                return Ok(new AccessToken { Successful = false, accessToken = "" });
            }           

            bool isAuthenticated = false;
            isAuthenticated = true;
            if (!isAuthenticated)
            {
                return Ok(new AccessToken { Successful = false, accessToken = "" });
            }

            var result = tkn.CreateAccessToken(userToLogin);
            UserDto data = sys.Login(userForLogin);
            TokenData dataresult = new TokenData
            {
                token = result,
                user = data,
                successful= true
            };
            return Ok(dataresult);
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult register(registerdto userForRegister)
        {
            logindto userForLogin = new logindto
            {
                email = userForRegister.email,
                password = userForRegister.password
            };
            UserDto userToLogin = sys.Register(userForRegister);
            if (!userToLogin.issuccesfull)
            {
                return Ok(new AccessToken { Successful = false, accessToken = "" });
            }

            bool isAuthenticated = false;
            isAuthenticated = true;
            if (!isAuthenticated)
            {
                return Ok(new AccessToken { Successful = false, accessToken = "" });
            }

            var result = tkn.CreateAccessToken(userToLogin);
            UserDto data = sys.Login(userForLogin);
            TokenData dataresult = new TokenData
            {
                token = result,
                user = data,
                successful = true
            };
            return Ok(dataresult);
        }



        //[AllowAnonymous]
        //[HttpPost("isAuthenticated")]
        //public IActionResult isAuthenticated(GetTokenValue options)
        //{
        //    ClaimsPrincipal data = tkn.DecodeToken(options.token);
        //    if(data!=null)
        //    {
        //        return Ok(new AccessToken { Successful = true, accessToken = "" });
        //    }
        //    else
        //    {
        //        return Ok(new AccessToken { Successful = false, accessToken = "" });

        //    }
        //}





        //// GET api/<AuthController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<AuthController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<AuthController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<AuthController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
