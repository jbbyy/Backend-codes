using LayeredApp.REPO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LayeredApp.Services;
using LayeredApp.Model;
using LayeredApp.Exceptions;
using LayeredApp.FIlter;
using Microsoft.AspNetCore.Authorization;

namespace LayeredApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[MyException] //apply attribute to handle exception
    //[Authorize] //apply attribute to check token on controller level. Able to apply attribute onto methods as well 
    public class CustomerController : ControllerBase
    {
        private readonly ICustService s;

        public CustomerController(ICustService s)
        {
            this.s = s;
        }


        [HttpPost]
        public IActionResult Post(Customer c)
        {
          
                return Ok(s.AddCustomers(c));
          //able to remove all the try catch blocks from all the methods
        }
        //[Authorize] //apply on method level 
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
              return Ok(s.GetCustomer(id));
           

        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
           
                return Ok(s.DeleteCustomer(id));
           
        }

        [HttpPut("{id}")]
        public IActionResult update(int id, Customer c)
        {
           
                return Ok(s.UpdateCustomer(id, c));
           
        }
    }
}
