using Microsoft.AspNetCore.Mvc;

namespace MOM_Project.Controllers
{
    public class MeetingTypeController : Controller
    {
        public IActionResult MeetingTypeList()
        {
            return View();
        }

        public IActionResult MeetingTypeAddEdit()
        {
            return View();
        }
    }
}
