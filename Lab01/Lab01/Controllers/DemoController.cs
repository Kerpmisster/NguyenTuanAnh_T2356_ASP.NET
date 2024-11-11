using Microsoft.AspNetCore.Mvc;

namespace Lab01.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
