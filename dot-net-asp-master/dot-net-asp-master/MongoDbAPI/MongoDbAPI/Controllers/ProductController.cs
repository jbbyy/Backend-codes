using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDbAPI.Models;
using MongoDbAPI.Repo;

namespace MongoDbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo repo;
        public ProductController(IProductRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repo.GetProducts());
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            repo.AddProduct(product);
            return StatusCode(201, "product added successfully");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(repo.GetProduct(id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repo.DeleteProduct(id);
            return Ok("product deleted successfully");
        }

        [HttpPut("{id}")]
        public IActionResult update(int id , Product product)
        {
            repo.UpdateProduct(id, product);
            return Ok("product updated successfully");
        }


    }
}
