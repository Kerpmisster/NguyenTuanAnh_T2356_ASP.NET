using Lab09.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Lab09.Controllers
{
    public class ProfileController : Controller
    {
        private readonly DevXuongMocContext _context;

        public ProfileController(DevXuongMocContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var memberData = HttpContext.Session.GetString("Member");
            var model = new Customer(); // Tạo model Customer để hiển thị thông tin

            if (!string.IsNullOrEmpty(memberData))
            {
                // Deserialize đối tượng Customer từ session
                var datalogin = JsonConvert.DeserializeObject<Customer>(memberData);

                if (datalogin != null)
                {
                    // Gán thông tin từ session vào model
                    model.Name = datalogin.Name;
                    model.Username = datalogin.Username;
                    model.Email = datalogin.Email;
                    model.Phone = datalogin.Phone;
                    model.Address = datalogin.Address;
                    model.CreatedDate = datalogin.CreatedDate;
                    model.Isactive = datalogin.Isactive;
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customer model)
        {
            if (ModelState.IsValid)
            {
                // Lấy thông tin khách hàng từ session
                var memberData = HttpContext.Session.GetString("Member");
                if (!string.IsNullOrEmpty(memberData))
                {
                    var datalogin = JsonConvert.DeserializeObject<Customer>(memberData);
                    if (datalogin != null)
                    {
                        // Cập nhật thông tin của khách hàng
                        datalogin.Name = model.Name;
                        datalogin.Email = model.Email;
                        datalogin.Phone = model.Phone;
                        datalogin.Address = model.Address;

                        // Cập nhật lại thông tin trong session
                        var updatedData = JsonConvert.SerializeObject(datalogin);
                        HttpContext.Session.SetString("Member", updatedData);

                        // Cập nhật vào cơ sở dữ liệu
                        var customerInDb = await _context.Customers.FirstOrDefaultAsync(c => c.Id == datalogin.Id);
                        if (customerInDb != null)
                        {
                            customerInDb.Name = datalogin.Name;
                            customerInDb.Email = datalogin.Email;
                            customerInDb.Phone = datalogin.Phone;
                            customerInDb.Address = datalogin.Address;
                            _context.Update(customerInDb);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            return View("Index", model); // Trả lại view Index nếu có lỗi trong model
        }
    }
}
