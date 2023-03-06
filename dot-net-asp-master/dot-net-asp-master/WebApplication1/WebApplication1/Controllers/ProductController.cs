using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
       

        public string Hello()
        {
            return "hello world";
        }

        public IActionResult Index()
        {
            //IActionresult is an interface 
            //return type is IActionResult
            //right click on Index() , able to add view -> rasor view empty 

            ViewBag.Usernme = "Abby";
            //use ViewBag to pass value from controller to view 
            ViewBag.Email = "Abby@gmail.com";
            return View();
            //return a webpage 
        }

        public IActionResult About()
        {
           
            return View();
        }

        //public IActionResult List()
        //{

        //    return View();
        //    //create a model (??)
        //}

        //public readonly List<products> productlist;
        //public ProductController1()
        //{
        //    productlist = new List<products>()
        //    {

        //    }
        //}



    }
}
