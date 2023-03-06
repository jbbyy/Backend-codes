using EntityDBDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityDBDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext db;
        public HomeController(DataContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var p = db.Products.Where(x => x.Id == id).FirstOrDefault();
            //where might give more than 1 result, it returns a collection. Hence we need to take the first record. 
            return View(p);
        }

        public IActionResult Delete(int id)
        {
            var p = db.Products.Where(x => x.Id == id).FirstOrDefault();
            return View(p);
        }

        [HttpPost]
        public IActionResult Delete(int id, Product product)
        {
            var p = db.Products.Where(x => x.Id == id).FirstOrDefault();
            db.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var p = db.Products.Where(x => x.Id == id).FirstOrDefault();
            return View(p);
        }

        [HttpPost]
        public IActionResult Edit(int id, Product product)
        {
            var p = db.Products.Where(x => x.Id == id).FirstOrDefault();
            p.Name = product.Name;
            p.Brand = product.Brand;
            p.Price = product.Price;
            p.Quantity = product.Quantity;
            db.Products.Update(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
