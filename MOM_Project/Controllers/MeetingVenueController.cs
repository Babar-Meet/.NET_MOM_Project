using Microsoft.AspNetCore.Mvc;

namespace MOM_Project.Controllers
{
    public class MeetingVenueController : Controller
    {
        public IActionResult MeetingVenueList()
        {
            return View();
        }
        public IActionResult MeetingVenueAddEdit()
        {
            return View();
        }
    }
}
