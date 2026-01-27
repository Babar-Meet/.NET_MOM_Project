using Microsoft.AspNetCore.Mvc;
using MOM_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MOM_Project.Controllers
{
    public class MeetingMemberController : Controller
    {
        // Static list to store meeting members (in real app, use database)
        private static List<MeetingMemberModel> _meetingMembers = new List<MeetingMemberModel>
        {
            new MeetingMemberModel { MeetingMemberID = 1, MeetingID = 1, StaffID = 101, IsPresent = true, Remarks = "On time", Created = DateTime.Parse("2024-10-28 10:15:00"), Modified = DateTime.Parse("2024-10-28 10:15:00") },
            new MeetingMemberModel { MeetingMemberID = 2, MeetingID = 1, StaffID = 102, IsPresent = true, Remarks = "Present", Created = DateTime.Parse("2024-10-28 10:15:00"), Modified = DateTime.Parse("2024-10-28 10:15:00") },
            new MeetingMemberModel { MeetingMemberID = 3, MeetingID = 1, StaffID = 103, IsPresent = false, Remarks = "On leave", Created = DateTime.Parse("2024-10-28 10:15:00"), Modified = DateTime.Parse("2024-10-28 10:15:00") },
            new MeetingMemberModel { MeetingMemberID = 4, MeetingID = 2, StaffID = 104, IsPresent = true, Remarks = "", Created = DateTime.Parse("2024-10-25 14:30:00"), Modified = DateTime.Parse("2024-10-25 14:30:00") },
            new MeetingMemberModel { MeetingMemberID = 5, MeetingID = 2, StaffID = 105, IsPresent = true, Remarks = "Joined virtually", Created = DateTime.Parse("2024-10-25 14:30:00"), Modified = DateTime.Parse("2024-10-25 14:30:00") },
            new MeetingMemberModel { MeetingMemberID = 6, MeetingID = 3, StaffID = 106, IsPresent = true, Remarks = "Active participant", Created = DateTime.Parse("2024-11-01 09:45:00"), Modified = DateTime.Parse("2024-11-01 09:45:00") },
            new MeetingMemberModel { MeetingMemberID = 7, MeetingID = 3, StaffID = 107, IsPresent = false, Remarks = "Sick leave", Created = DateTime.Parse("2024-11-01 09:45:00"), Modified = DateTime.Parse("2024-11-01 09:45:00") },
            new MeetingMemberModel { MeetingMemberID = 8, MeetingID = 4, StaffID = 108, IsPresent = true, Remarks = "", Created = DateTime.Parse("2024-10-10 13:20:00"), Modified = DateTime.Parse("2024-10-10 13:20:00") },
            new MeetingMemberModel { MeetingMemberID = 9, MeetingID = 5, StaffID = 109, IsPresent = true, Remarks = "Attended remotely", Created = DateTime.Parse("2024-10-30 16:45:00"), Modified = DateTime.Parse("2024-10-30 16:45:00") },
            new MeetingMemberModel { MeetingMemberID = 10, MeetingID = 6, StaffID = 110, IsPresent = true, Remarks = "Coordinator", Created = DateTime.Parse("2024-10-15 11:10:00"), Modified = DateTime.Parse("2024-10-15 11:10:00") }
        };

        public IActionResult MeetingMemberList()
        {
            ViewBag.MeetingMembers = _meetingMembers;
            return View();
        }

        public IActionResult MeetingMemberAddEdit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult saveMeetingMember(MeetingMemberModel meetingMemberModel)
        {
            if (ModelState.IsValid)
            {
                // Generate new MeetingMemberID
                var newId = _meetingMembers.Any() ? _meetingMembers.Max(m => m.MeetingMemberID) + 1 : 1;

                // Set created and modified dates
                meetingMemberModel.MeetingMemberID = newId;
                meetingMemberModel.Created = DateTime.Now;
                meetingMemberModel.Modified = DateTime.Now;

                // Add to the list
                _meetingMembers.Add(meetingMemberModel);

                // Redirect to list view
                return RedirectToAction("MeetingMemberList");
            }
            return View("MeetingMemberAddEdit", meetingMemberModel);
        }
    }
}