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

        public IActionResult Settings()
        {
            return View();
        }

       
        public IActionResult Help()
        {
            return View();
        }

        public IActionResult Requests()
        {
            return View();
        }

    }

}
