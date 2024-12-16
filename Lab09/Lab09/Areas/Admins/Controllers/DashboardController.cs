using Lab09.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab09.Areas.Admins.Controllers
{
    //[Area("Admins")]
    public class DashboardController : BaseController
    {
        private readonly DevXuongMocContext _context;
        public DashboardController(DevXuongMocContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            // Sử dụng context của DbContext để lấy số lượng
            var productCount = _context.Products.Count();
            var newsCount = _context.News.Count();
            var userCount = _context.Customers.Count();
            var contactCount = _context.Contacts.Count();

            // Truyền dữ liệu qua ViewData
            ViewData["ProductCount"] = productCount;
            ViewData["NewsCount"] = newsCount;
            ViewData["UserCount"] = userCount;
            ViewData["ContactCount"] = contactCount;

            return View();
        }
    }
}
