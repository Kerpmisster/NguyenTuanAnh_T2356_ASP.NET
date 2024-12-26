using Lab09.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Policy;

namespace Lab09.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            var memberData = HttpContext.Session.GetString("Member");
            if (!string.IsNullOrEmpty(memberData))
            {
                var datalogin = JsonConvert.DeserializeObject<Customer>(memberData);
                ViewBag.Customer = datalogin;
                ViewBag.UserName = datalogin?.Username; // Thay FullName bằng thuộc tính tên của user trong model của bạn
                ViewBag.Email = datalogin?.Email;
                ViewBag.Phone = datalogin?.Phone;
            }
            return View();
        }
    }
}
