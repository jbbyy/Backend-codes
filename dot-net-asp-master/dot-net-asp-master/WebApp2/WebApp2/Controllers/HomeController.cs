using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Xml.Linq;
using WebApp2.Models;
using WebApp2.Repo;

namespace WebApp2.Controllers
{
    public class HomeController : Controller
    {
        public static List<Product> productList = new List<Product>()
        {
          new Product{Id=1, Name="Laptop", Brand="Dell", quantity=5, price=2000},
          new Product {Id=2, Name="MacBook", Brand="Apple", quantity=10, price=4000}
        };

        //Generator g = new Generator();
        //this will result in tight coupling, do not do this

        private readonly Igenerator gen;
        //create a reference variable of gen

        public HomeController(Igenerator gen)
        {
            this.gen = gen;
        }
        public IActionResult Index()
        {
            ViewBag.Id = gen.GetID();
            return View("Homepage",productList);
        }

        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product prod)
        {
            if (ModelState.IsValid)
            {
                productList.Add(prod);
                RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {

            return View(productList.Find(x => x.Id == id));

        }

        [HttpPost]
        public IActionResult Delete( int id, Product prod)
        {
            productList.Remove(productList.Find(x => x.Id == id));
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            return View(productList.Find(x => x.Id == id));
        }

        [HttpPost]
    public IActionResult Edit(int id, Product prod)
        {
            var p = productList.Find(x => x.Id == id);
            p.Name = prod.Name;
            p.price = prod.price;
            p.Brand = prod.Brand;
            p.quantity = prod.quantity;

            return RedirectToAction("index");
           
        }

       

      



    }
}