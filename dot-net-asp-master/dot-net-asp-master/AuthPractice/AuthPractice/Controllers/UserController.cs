using AuthPractice.Filter;
using AuthPractice.Model;
using AuthPractice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Exception]
    public class UserController : ControllerBase
    {
        private readonly ITokenGenerator itg;
        private readonly IUserService ius;

        public UserController(ITokenGenerator itg, IUserService ius)
        {
            this.itg = itg;
            this.ius = ius;
        }
        [HttpPost("register")]
        public IActionResult register(Users u)
        {
            if (ius.registerUser(u) == 1) {
                return Ok("User registered successfully");
            } 
            return BadRequest();
        }
        [HttpPost("login")]
        public IActionResult login(Cred c)
        {
            if (ius.loginUser(c))
            {
                return Ok(itg.GenerateToken(c));
            }
            return StatusCode(400, "Invalid username or password");
        }
    }
}
