﻿using Microsoft.AspNetCore.Mvc;

namespace Lab09.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
