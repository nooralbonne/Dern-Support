using Dern_Support.Model;
using Microsoft.AspNetCore.Mvc;

namespace Dern_Support.Controllers.MVC_Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Accounts()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult Inventory()
        {
            return View();
        }
        public IActionResult Help()
        {
            return View();
        }

        public IActionResult Scheduling()
        {
            return View();
        }
    }
}

