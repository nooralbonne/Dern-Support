﻿using Microsoft.AspNetCore.Mvc;

namespace Dern_Support.Controllers.MVC_Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
