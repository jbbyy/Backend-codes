using Microsoft.AspNetCore.Mvc;

namespace WebApp2.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
