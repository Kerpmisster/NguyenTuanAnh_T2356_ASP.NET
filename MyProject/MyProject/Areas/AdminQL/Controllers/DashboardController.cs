using Microsoft.AspNetCore.Mvc;

namespace MyProject.Areas.AdminQL.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
