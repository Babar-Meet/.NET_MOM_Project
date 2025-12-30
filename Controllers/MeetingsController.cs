using Microsoft.AspNetCore.Mvc;

namespace MOM_Project.Controllers
{
    public class MeetingsController : Controller
    {
        public IActionResult MeetingList()
        {
            return View();
        }
        public IActionResult MeetingAddEdit()
        {
            return View();
        }
    }
}
