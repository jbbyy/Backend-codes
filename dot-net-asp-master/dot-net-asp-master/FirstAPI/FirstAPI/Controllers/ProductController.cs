using FirstAPI.Model;
using FirstAPI.Respo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")] //every resource will have a different URL, this is specified by this route 
    //to access this controller needs to /api/product (aka controller name) 

    [ApiController] //this attributes makes this class a controller 
    public class ProductController : ControllerBase
        //ProductCOntroller is a simple class that is inherited from the ControllerBase class
    {
        //[HttpGet] //need to specify the HTTP request above method
        //public string Get() //name of method doesnt matter
        //{
        //    return "hello";
        //}
        ////https://localhost:7121/api/product will call the get request and display "hello" on page 
      
        //[HttpGet("show")] //need to specify another route either by placing inside the HTTP request  
        ///*HTTPGet]
        //[Route("show")] */
        //public string Getagain() 
        //{
        //    return "hello again";
        //}

        //[HttpGet]
        //[Route("{id}")]
        //public string GetProduct(int id )
        //{
        //    return $"Hello {id}";
        //}

        private readonly IProductRepo repo;
        public ProductController(IProductRepo repo)
        {
            this.repo = repo;
        }
        //inject dependency so that we can use the methods inside iproductrepo
        // need to rememember to resolve this iproductrepo inside program cs
        [HttpGet]
        public IActionResult Getprod()
        {
            return Ok(repo.GetProducts());
            //will get data and return with ok status code : 200 status code 
            //able to return specific status code 
            //return StatusCode(201, repo.GetProducts());
        }

        [HttpPost]
        public IActionResult Post(Products product)
        {
            repo.AddProduct(product);
            return StatusCode(201, "Product Added Successfully");
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult gett(int id)
        {
            var product = repo.GetProduct(id);
            if (product== null){
                return NotFound($"Product with id:{id} does not exiist");
            }
            return Ok(product);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult delete(int id)
        {
            int res = repo.Deleteproduct(id);
            if(res == 0)
            {
                return NotFound($"product with id:{id} does not exist");
            }
            return Ok("Product deleted Successfully");
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult put(int id, Products product)
        {
            int res = repo.Updateproduct(id, product);
            if (res == 0)
            {
                return NotFound($"product with id:{id} does not exist");
            }
            return Ok("Product Updated Successfully");
        }
    }
}
