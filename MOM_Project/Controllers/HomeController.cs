using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MOM_Project.Models;

namespace MOM_Project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

    }
}
