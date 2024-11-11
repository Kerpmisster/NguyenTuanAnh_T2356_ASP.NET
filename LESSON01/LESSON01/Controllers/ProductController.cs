using Microsoft.AspNetCore.Mvc;

namespace LESSON01.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
