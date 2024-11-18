using Microsoft.AspNetCore.Mvc;

namespace MyProject.Areas.CustomerUser.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
