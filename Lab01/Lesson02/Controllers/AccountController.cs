using Lesson02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson02.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<Account> accounts = new List<Account>
            {
                new Account
                {
                    Id = 1,
                    Name = "Test",
                    Email = "Test@gmail.com",
                    Phone = "0985823471",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Image/Avatar/myAvatar-1.png"),
                    Gender = 1,
                    Birthday = new DateTime(2003,09,29)
                },
                new Account
                {
                    Id = 2,
                    Name = "Test",
                    Email = "Test@gmail.com",
                    Phone = "0985823471",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Image/Avatar/myAvatar-1.png"),
                    Gender = 0,
                    Birthday = new DateTime(2004,09,29)
                },
                new Account
                {
                    Id = 3,
                    Name = "Test",
                    Email = "Test@gmail.com",
                    Phone = "0985823471",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Image/Avatar/myAvatar-1.png"),
                    Gender = 1,
                    Birthday = new DateTime(2005,09,29)
                },
            };
            ViewBag.Accounts = accounts;
            return View();
        }
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
                    Avatar = Url.Content("~/Image/Avatar/myAvatar-1.png"),
                    Gender = 1,
                    Bio = "My profile",
                    Birthday = new DateTime(2003,09,29)
                },

                new Account()
                {
                    Id = 2,
                    Name = "Hoàng Anh",
                    Email = "anh@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Image/Avatar/myAvatar-1.png"),
                    Gender = 0,
                    Bio = "My profile",
                    Birthday = new DateTime(2004,09,29)
                },

                new Account()
                {
                    Id = 3,
                    Name = "Hoàng Anh",
                    Email = "anh@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Image/Avatar/myAvatar-1.png"),
                    Gender = 1,
                    Bio = "My profile",
                    Birthday = new DateTime(2005,09,29)
                }
            };
            Account account = accounts.FirstOrDefault();
            ViewBag.Account = account;
            return View();

        }
    }
}
