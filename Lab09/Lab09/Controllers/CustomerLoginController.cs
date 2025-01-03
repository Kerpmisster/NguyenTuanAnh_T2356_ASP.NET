﻿using Lab09.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NuGet.Protocol;

namespace Lab09.Controllers
{
    public class CustomerLoginController : Controller
    {
        private readonly DevXuongMocContext _context;
        public CustomerLoginController(DevXuongMocContext context)
        {
            _context = context;
        }
        public IActionResult Index(string url)
        {
            var memberData = HttpContext.Session.GetString("Member");
            if (!string.IsNullOrEmpty(memberData))
            {
                var datalogin = JsonConvert.DeserializeObject<Customer>(memberData);
                ViewBag.Customer = datalogin;
            }

            ViewBag.UrlAction = url;
            return View();
        }
   

        [HttpPost]
        public IActionResult Registy(Customer model)
        {
            try
            {
                var pass = Utilities.Utils.GetSHA26Hash(model.Password);
                model.Password = pass;
                model.CreatedDate = DateTime.Now;
                model.UpdateDate = DateTime.Now;
                model.Isactive = 1;
                _context.Add(model);
                _context.SaveChanges();

                TempData["successRegisty"] = "Đăng ký thành công!";

                return View();
            }
            catch (Exception ex)
            {
                TempData["errorRegisty"] = "Lỗi đăng ký:" + ex.Message;
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Login(CustomerLogin model, string urlAction)
        {
            var pass = Utilities.Utils.GetSHA26Hash(model.Password);
            var data = _context.Customers
                .Where(x => x.Isactive == 1)
                .Where(x => x.Username.Equals(model.UserOrEmail) || x.Email.Equals(model.UserOrEmail))
                .FirstOrDefault(x => x.Password.Equals(pass));

            if (data != null)
            {
                var datalogin = JsonConvert.SerializeObject(data); // Serialize đối tượng Customer
                HttpContext.Session.SetString("Member", datalogin); // Lưu JSON vào session

                if (!string.IsNullOrEmpty(urlAction))
                {
                    return Redirect(urlAction);
                }
                return RedirectToAction("Index", "Home");
            }
            TempData["errorLogin"] = "Lỗi đăng nhập";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Member");

            return RedirectToAction("Index", "Home");
        }
    }
}
