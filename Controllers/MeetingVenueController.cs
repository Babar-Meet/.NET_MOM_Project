using Microsoft.AspNetCore.Mvc;
using MOM_Project.Models;
using System;
using System.Collections.Generic;

namespace MOM_Project.Controllers
{
    public class MeetingVenueController : Controller
    {
        public IActionResult MeetingVenueList()
        {
            // Create sample MeetingVenue data
            var meetingVenues = new List<MeetingVenueModel>
            {
                new MeetingVenueModel {
                    MeetingVenueID = 1,
                    MeetingVenueName = "Conference Room A (Room 101)",
                    Created = DateTime.Parse("2023-01-10 09:00:00"),
                    Modified = DateTime.Parse("2024-11-05 14:20:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 2,
                    MeetingVenueName = "Conference Room B (Room 102)",
                    Created = DateTime.Parse("2023-01-10 09:15:00"),
                    Modified = DateTime.Parse("2024-10-18 11:30:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 3,
                    MeetingVenueName = "Conference Room C (Room 103)",
                    Created = DateTime.Parse("2023-01-10 09:30:00"),
                    Modified = DateTime.Parse("2024-09-22 16:45:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 4,
                    MeetingVenueName = "Seminar Hall A",
                    Created = DateTime.Parse("2023-02-05 10:00:00"),
                    Modified = DateTime.Parse("2024-11-12 10:15:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 5,
                    MeetingVenueName = "Seminar Hall B",
                    Created = DateTime.Parse("2023-02-05 10:15:00"),
                    Modified = DateTime.Parse("2024-10-28 14:30:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 6,
                    MeetingVenueName = "Auditorium (Main)",
                    Created = DateTime.Parse("2023-02-15 08:45:00"),
                    Modified = DateTime.Parse("2024-11-08 09:40:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 7,
                    MeetingVenueName = "Mini Auditorium",
                    Created = DateTime.Parse("2023-03-10 14:20:00"),
                    Modified = DateTime.Parse("2024-10-15 13:25:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 8,
                    MeetingVenueName = "Principal's Office",
                    Created = DateTime.Parse("2023-03-12 11:10:00"),
                    Modified = DateTime.Parse("2024-11-10 15:50:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 9,
                    MeetingVenueName = "Principal's Conference Room",
                    Created = DateTime.Parse("2023-03-12 11:30:00"),
                    Modified = DateTime.Parse("2024-10-22 10:05:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 10,
                    MeetingVenueName = "Training Room 1",
                    Created = DateTime.Parse("2023-04-05 09:45:00"),
                    Modified = DateTime.Parse("2024-11-15 11:20:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 11,
                    MeetingVenueName = "Training Room 2",
                    Created = DateTime.Parse("2023-04-05 10:00:00"),
                    Modified = DateTime.Parse("2024-09-30 14:15:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 12,
                    MeetingVenueName = "Training Room 3",
                    Created = DateTime.Parse("2023-04-05 10:15:00"),
                    Modified = DateTime.Parse("2024-10-10 16:30:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 13,
                    MeetingVenueName = "Faculty Lounge",
                    Created = DateTime.Parse("2023-05-20 13:00:00"),
                    Modified = DateTime.Parse("2024-11-05 12:40:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 14,
                    MeetingVenueName = "Library Conference Room",
                    Created = DateTime.Parse("2023-06-08 10:30:00"),
                    Modified = DateTime.Parse("2024-10-18 09:55:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 15,
                    MeetingVenueName = "Project Room 1",
                    Created = DateTime.Parse("2023-06-15 14:45:00"),
                    Modified = DateTime.Parse("2024-11-12 13:10:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 16,
                    MeetingVenueName = "Project Room 2",
                    Created = DateTime.Parse("2023-06-15 15:00:00"),
                    Modified = DateTime.Parse("2024-10-25 11:25:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 17,
                    MeetingVenueName = "Research Center Room 301",
                    Created = DateTime.Parse("2023-07-10 11:20:00"),
                    Modified = DateTime.Parse("2024-11-08 14:50:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 18,
                    MeetingVenueName = "Research Center Room 302",
                    Created = DateTime.Parse("2023-07-10 11:35:00"),
                    Modified = DateTime.Parse("2024-10-30 10:40:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 19,
                    MeetingVenueName = "Lab Complex Room 205",
                    Created = DateTime.Parse("2023-08-22 09:10:00"),
                    Modified = DateTime.Parse("2024-11-15 15:15:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 20,
                    MeetingVenueName = "Examination Hall",
                    Created = DateTime.Parse("2023-09-05 08:30:00"),
                    Modified = DateTime.Parse("2024-10-20 12:20:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 21,
                    MeetingVenueName = "Placement Cell Office",
                    Created = DateTime.Parse("2023-10-12 13:45:00"),
                    Modified = DateTime.Parse("2024-11-10 16:05:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 22,
                    MeetingVenueName = "Virtual - Zoom Meeting",
                    Created = DateTime.Parse("2023-11-15 10:00:00"),
                    Modified = DateTime.Parse("2024-11-18 14:30:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 23,
                    MeetingVenueName = "Virtual - Microsoft Teams",
                    Created = DateTime.Parse("2023-11-15 10:15:00"),
                    Modified = DateTime.Parse("2024-11-05 11:45:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 24,
                    MeetingVenueName = "Virtual - Google Meet",
                    Created = DateTime.Parse("2023-11-20 14:20:00"),
                    Modified = DateTime.Parse("2024-10-28 13:10:00")
                },
                new MeetingVenueModel {
                    MeetingVenueID = 25,
                    MeetingVenueName = "Virtual - Webex",
                    Created = DateTime.Parse("2024-01-10 09:30:00"),
                    Modified = DateTime.Parse("2024-11-12 10:50:00")
                }
            };

            // Store in ViewBag
            ViewBag.MeetingVenues = meetingVenues;

            return View();
        }

        public IActionResult MeetingVenueAddEdit()
        {
            return View();
        }
    }
}