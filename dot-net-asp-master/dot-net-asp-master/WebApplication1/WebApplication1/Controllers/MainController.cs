using Microsoft.AspNetCore.Mvc;
using WebApplication1.Views.ProductController1;
using WebApplication1.Models;



namespace WebApplication1.Controllers
{
    public class MainController : Controller
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
            ViewBag.Products = productlist;
            return View();
            //return a webpage 
        }

        public IActionResult About()
        {
            Products p = new Products() { id = 1, name = "bag", brand = "lenvo", quantity=1, price=50}
            return View(p);
        }





        private readonly List<Products> productlist;
        public MainController()
        {

            productlist = new List<Products>()
            {
                new Products{id = 1, name = "laptop", brand = "dell", quantity=7, price =2000 },
                 new Products() {id = 2, name = "desktop", brand = "dell", quantity=2, price =4000 },
                 new Products() {id = 3, name = "mouse", brand = "dell", quantity=8, price =400 },
        };
        }

            public IActionResult List()
            {

            ViewBag.Products = productlist;
            return View();
            return View(productlist);

        }

        public IActionResult Create()
        {
            return View();
            //by default, will be a get
        }
        [HttpPost] //this will make it a post
        public IActionResult Create(Products product)
        {
            productlist.Add(product);
            return RedirectToAction("index");
        }

        public IActionResult Delete()
        {
            return View();
            //add razor view , template delete, model class product
        }

        [HttpPost]
        public IActionResult Delete(int id, Products p)
        {
            //p is just added to overload the method. Not being used 
            productlist.Remove(productlist.Find(x => x.id == id));
            return RedirectToAction("index");
        }
    }
    }

