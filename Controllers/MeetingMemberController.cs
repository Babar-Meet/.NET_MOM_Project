using Microsoft.AspNetCore.Mvc;
using MOM_Project.Models;
using System;
using System.Collections.Generic;

namespace MOM_Project.Controllers
{
    public class MeetingMemberController : Controller
    {
        public IActionResult MeetingMemberList()
        {
            // Create sample MeetingMember data
            var meetingMembers = new List<MeetingMemberModel>
            {
                new MeetingMemberModel {
                    MeetingMemberID = 1,
                    MeetingID = 1,
                    StaffID = 101,
                    IsPresent = true,
                    Remarks = "On time",
                    Created = DateTime.Parse("2024-11-05 14:30:00"),
                    Modified = DateTime.Parse("2024-11-05 16:45:00")
                },
                new MeetingMemberModel {
                    MeetingMemberID = 2,
                    MeetingID = 1,
                    StaffID = 102,
                    IsPresent = false,
                    Remarks = "On leave",
                    Created = DateTime.Parse("2024-11-05 14:30:00"),
                    Modified = DateTime.Parse("2024-11-05 16:45:00")
                },
                new MeetingMemberModel {
                    MeetingMemberID = 3,
                    MeetingID = 2,
                    StaffID = 103,
                    IsPresent = true,
                    Remarks = "Active participant",
                    Created = DateTime.Parse("2024-11-10 09:00:00"),
                    Modified = DateTime.Parse("2024-11-08 11:20:00")
                },
                new MeetingMemberModel {
                    MeetingMemberID = 4,
                    MeetingID = 2,
                    StaffID = 104,
                    IsPresent = true,
                    Remarks = "Present",
                    Created = DateTime.Parse("2024-11-10 09:00:00"),
                    Modified = DateTime.Parse("2024-11-08 11:20:00")
                },
                new MeetingMemberModel {
                    MeetingMemberID = 5,
                    MeetingID = 3,
                    StaffID = 105,
                    IsPresent = true,
                    Remarks = "Submitted report",
                    Created = DateTime.Parse("2024-11-15 11:00:00"),
                    Modified = DateTime.Parse("2024-11-01 09:45:00")
                },
                new MeetingMemberModel {
                    MeetingMemberID = 6,
                    MeetingID = 3,
                    StaffID = 106,
                    IsPresent = false,
                    Remarks = "Training session",
                    Created = DateTime.Parse("2024-11-15 11:00:00"),
                    Modified = DateTime.Parse("2024-11-01 09:45:00")
                },
                new MeetingMemberModel {
                    MeetingMemberID = 7,
                    MeetingID = 4,
                    StaffID = 107,
                    IsPresent = true,
                    Remarks = "Budget presenter",
                    Created = DateTime.Parse("2024-10-20 15:00:00"),
                    Modified = DateTime.Parse("2024-10-21 10:30:00")
                },
                new MeetingMemberModel {
                    MeetingMemberID = 8,
                    MeetingID = 5,
                    StaffID = 108,
                    IsPresent = false,
                    Remarks = "Cancelled attendance",
                    Created = DateTime.Parse("2024-11-18 10:00:00"),
                    Modified = DateTime.Parse("2024-11-10 14:15:00")
                },
                new MeetingMemberModel {
                    MeetingMemberID = 9,
                    MeetingID = 6,
                    StaffID = 109,
                    IsPresent = true,
                    Remarks = "Curriculum expert",
                    Created = DateTime.Parse("2024-10-25 13:30:00"),
                    Modified = DateTime.Parse("2024-10-26 09:20:00")
                },
                new MeetingMemberModel {
                    MeetingMemberID = 10,
                    MeetingID = 7,
                    StaffID = 110,
                    IsPresent = true,
                    Remarks = "Research lead",
                    Created = DateTime.Parse("2024-11-22 14:00:00"),
                    Modified = DateTime.Parse("2024-11-05 10:30:00")
                }
            };

            // Store in ViewBag
            ViewBag.MeetingMembers = meetingMembers;

            return View();
        }

        public IActionResult MeetingMemberAddEdit()
        {
            return View();
        }
    }
}