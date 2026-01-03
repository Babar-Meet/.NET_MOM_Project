using Microsoft.AspNetCore.Mvc;

namespace MOM_Project.Controllers
{
    public class LoginSignupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult loginpage()
        {
            return View();
        }
    }
}
