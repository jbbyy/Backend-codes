using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using UserAPI.Model;
using UserAPI.Repo;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo ur;
        private readonly ITokenGeneratorService s;

        public UsersController(IUserRepo ur, ITokenGeneratorService s)
        {
            this.ur = ur;
            this.s = s;
        }
        

        [HttpPost("register")]
        public IActionResult add(Users user)
        {
           int res =  ur.Addusers(user);
            if (res == 1)
            {
                return Ok("User registered successfully");
            }
            return StatusCode(500, "Something went wrong");
        }

        [HttpPost("login")]
        public IActionResult login(Cred user)
        {
            if (ur.Login(user.Username, user.Password))
            {
                return Ok(s.GenerateToken(user));
            }
            else
            {
                return StatusCode(401, "Invalid username or password");
            }
        }
        //[HttpGet]
        //public IActionResult get()
        //{
        //    return Ok(ur.GetUsers());
        //}

        //[HttpGet]
        //[Route("{id}")]
        //public IActionResult getting(int id)
        //{
        //    var p = ur.GetUser(id);
        //    if (p == null)
        //    {
        //        return NotFound($"User with id:{id} not found");
        //    }
        //    return Ok(p);
        //}

        //[HttpDelete]
        //[Route("{id}")]
        //public IActionResult delete(int id)
        //{
        //    int res = ur.Deleteusers(id);
        //    if(res == 0)
        //    {
        //        return NotFound($"User with id:{id} not found");
        //    }
        //    return Ok("User deleted successfully");
        //}

        //[HttpPut]
        //[Route("{id}")]
        //public IActionResult update(int id, Users x)
        //{
        //    int res = ur.Updateusers(id, x);
        //    if (res == 0)
        //    {
        //        return NotFound($"User with id:{id} not found");
        //    }
        //    return Ok("User Updated successfully");
        //}
    }
}
