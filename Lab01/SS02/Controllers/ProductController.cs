using Microsoft.AspNetCore.Mvc;
using SS02.Models;

namespace SS02.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllProduct()
        {
            return View("Product");
        }
        public IActionResult GetProduct() 
        {
            Product product = new Product()
            {
                Id = 1,
                Name = "Test",
                YearRelease = DateTime.Now,
                Price = 3.14,
            };
            ViewBag.Product = product;
            ViewData["ProductVD"] = product;
            return View();
        }
    }
}
