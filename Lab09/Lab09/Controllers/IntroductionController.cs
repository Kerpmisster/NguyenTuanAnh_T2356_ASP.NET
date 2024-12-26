using Microsoft.AspNetCore.Mvc;

namespace Lab09.Controllers
{
    public class IntroductionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
