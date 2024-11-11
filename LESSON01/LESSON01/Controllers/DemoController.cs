using Microsoft.AspNetCore.Mvc;

namespace LESSON01.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
