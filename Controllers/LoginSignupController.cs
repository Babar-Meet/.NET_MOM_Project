using Microsoft.AspNetCore.Mvc;

namespace MOM_Project.Controllers
{
    public class LoginSignupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult loginPage()
        {
            return View();
        }
        public IActionResult SignupPage()
        {
            return View();
        }
    }
}
