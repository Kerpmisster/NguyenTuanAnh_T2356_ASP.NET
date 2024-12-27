using Lab09.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Policy;

namespace Lab09.Controllers
{
    public class ContactController : Controller
    {
        private readonly DevXuongMocContext _context;

        public ContactController(DevXuongMocContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var memberData = HttpContext.Session.GetString("Member");
            var model = new Contact();

            if (!string.IsNullOrEmpty(memberData))
            {
                var datalogin = JsonConvert.DeserializeObject<Customer>(memberData);
                if (datalogin != null)
                {
                    model.Title = datalogin.Username; // Gán Username làm tiêu đề liên hệ
                    model.Email = datalogin.Email;
                    model.Phone = datalogin.Phone;
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.CreatedDate = DateTime.Now; // Gán thời gian tạo
                contact.Status = 1; // Đặt trạng thái mặc định
                _context.Add(contact);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Liên hệ của bạn đã được gửi thành công!";
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = "Có lỗi xảy ra, vui lòng thử lại!";
            return View(contact);
        }
    }
}
