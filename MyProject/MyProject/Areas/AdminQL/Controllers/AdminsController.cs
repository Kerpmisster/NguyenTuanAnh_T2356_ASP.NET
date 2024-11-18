using Microsoft.AspNetCore.Mvc;

namespace MyProject.Areas.AdminQL.Controllers
{
    public class AdminsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
