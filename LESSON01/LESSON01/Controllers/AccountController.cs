using LESSON01.Models;
using Microsoft.AspNetCore.Mvc;

namespace LESSON01.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<Account> accounts = new List<Account>
            {
                new Account()
                {
                    Id = 1,
                    Name = "Hoàng Anh",
                    Email = "anh@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/images/avatar/avatar1.png"),
                    Gender = 1,
                    Bio = "My profile",
                    Birthday = new DateTime(2003,7,15)
                },

                new Account()
                {
                    Id = 2,
                    Name = "Hoàng Anh",
                    Email = "anh@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/images/avatar/avatar1.png"),
                    Gender = 1,
                    Bio = "My profile",
                    Birthday = new DateTime(2003,7,15)
                },

                new Account()
                {
                    Id = 3,
                    Name = "Hoàng Anh",
                    Email = "anh@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/images/avatar/avatar1.png"),
                    Gender = 1,
                    Bio = "My profile",
                    Birthday = new DateTime(2003,7,15)
                }
            };
            ViewBag.Accounts = accounts;
            return View();
        }
        [Route("ho-so-cua-toi", Name ="profile")]
        public IActionResult Profile(int id)
        {
            List<Account> accounts = new List<Account>
            {
                new Account()
                {
                    Id = 1,
                    Name = "Hoàng Anh",
                    Email = "anh@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/images/avatar/avatar1.png"),
                    Gender = 1,
                    Bio = "My profile",
                    Birthday = new DateTime(2003,7,15)
                },

                new Account()
                {
                    Id = 2,
                    Name = "Hoàng Anh",
                    Email = "anh@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/images/avatar/avatar1.png"),
                    Gender = 1,
                    Bio = "My profile",
                    Birthday = new DateTime(2003,7,15)
                },

                new Account()
                {
                    Id = 3,
                    Name = "Hoàng Anh",
                    Email = "anh@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/images/avatar/avatar1.png"),
                    Gender = 1,
                    Bio = "My profile",
                    Birthday = new DateTime(2003,7,15)
                }
            };
            Account account = accounts.FirstOrDefault()
            ViewBag.Account = account;
            return View();
        }
    }
}
