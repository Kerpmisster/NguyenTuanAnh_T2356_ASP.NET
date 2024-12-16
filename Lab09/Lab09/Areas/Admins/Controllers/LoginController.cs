using Lab09.Areas.Admins.Models;
using Lab09.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace Lab09.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class LoginController : Controller
    {
        private readonly DevXuongMocContext _context;

        public LoginController(DevXuongMocContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Login model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Thông tin đăng nhập không hợp lệ.");
                return View(model);
            }
            var pass = model.Password;
            var dataLogin = _context.AdminUsers.
                FirstOrDefault(x => x.Email.Equals(model.Email) && x.Password.Equals(pass));

            if (dataLogin != null)
            {
                HttpContext.Session.SetString("AdminLogin", model.Email);

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Thông tin đăng nhập không chính xác.");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AdminLogin");

            return RedirectToAction("Index");
        }
        static string GetSHA256Hash(string input)
        {
            string hash = "";
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                hash = BitConverter.ToString(hashedBytes).Replace("-","").ToLower();
            }
            return hash;
        }
    }
}
