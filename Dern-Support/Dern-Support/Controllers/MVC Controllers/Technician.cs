using Microsoft.AspNetCore.Mvc;

namespace Dern_Support.Controllers.MVC_Controllers
{
    public class Technician : Controller
    {
        public IActionResult Index()
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

        public IActionResult Job()
        {
            return View();
        }

    }
}

