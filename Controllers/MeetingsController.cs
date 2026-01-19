using Microsoft.AspNetCore.Mvc;
using MOM_Project.Models;
using System;
using System.Collections.Generic;

namespace MOM_Project.Controllers
{
    public class MeetingsController : Controller
    {
        public IActionResult MeetingList()
        {
            // Create sample Meetings data
            var meetings = new List<MeetingsModel>
            {
                new MeetingsModel {
                    MeetingID = 1,
                    MeetingDate = DateTime.Parse("2024-11-05 14:30:00"),
                    MeetingVenue = "Conference Room A (Room 101)",
                    MeetingType = "Project Review Meeting",
                    Department = "Computer Science & Engineering",
                    MeetingDescription = "Quarterly project status review meeting for final year students",
                    DocumentPath = "project_review.pdf",
                    Created = DateTime.Parse("2024-10-28 10:15:00"),
                    Modified = DateTime.Parse("2024-11-05 16:45:00"),
                    IsCancelled = false,
                    CancellationDateTime = null,
                    CancellationReason = ""
                },
                new MeetingsModel {
                    MeetingID = 2,
                    MeetingDate = DateTime.Parse("2024-11-10 09:00:00"),
                    MeetingVenue = "Virtual - Zoom Meeting",
                    MeetingType = "Planning Session",
                    Department = "Information Technology",
                    MeetingDescription = "2025 Academic year planning and curriculum updates",
                    DocumentPath = "",
                    Created = DateTime.Parse("2024-10-25 14:30:00"),
                    Modified = DateTime.Parse("2024-11-08 11:20:00"),
                    IsCancelled = false,
                    CancellationDateTime = null,
                    CancellationReason = ""
                },
                new MeetingsModel {
                    MeetingID = 3,
                    MeetingDate = DateTime.Parse("2024-11-15 11:00:00"),
                    MeetingVenue = "Seminar Hall B",
                    MeetingType = "Faculty Meeting",
                    Department = "Mechanical Engineering",
                    MeetingDescription = "Faculty development program discussion and training schedule",
                    DocumentPath = "faculty_dev.pdf",
                    Created = DateTime.Parse("2024-11-01 09:45:00"),
                    Modified = DateTime.Parse("2024-11-01 09:45:00"),
                    IsCancelled = false,
                    CancellationDateTime = null,
                    CancellationReason = ""
                },
                new MeetingsModel {
                    MeetingID = 4,
                    MeetingDate = DateTime.Parse("2024-10-20 15:00:00"),
                    MeetingVenue = "Principal's Office",
                    MeetingType = "Budget Review",
                    Department = "Administration",
                    MeetingDescription = "Annual budget allocation review for all departments",
                    DocumentPath = "budget_2025.xlsx",
                    Created = DateTime.Parse("2024-10-10 13:20:00"),
                    Modified = DateTime.Parse("2024-10-21 10:30:00"),
                    IsCancelled = false,
                    CancellationDateTime = null,
                    CancellationReason = ""
                },
                new MeetingsModel {
                    MeetingID = 5,
                    MeetingDate = DateTime.Parse("2024-11-18 10:00:00"),
                    MeetingVenue = "Training Room 3",
                    MeetingType = "Training Workshop",
                    Department = "Humanities & Social Sciences",
                    MeetingDescription = "Research methodology workshop for new faculty members",
                    DocumentPath = "",
                    Created = DateTime.Parse("2024-10-30 16:45:00"),
                    Modified = DateTime.Parse("2024-11-10 14:15:00"),
                    IsCancelled = true,
                    CancellationDateTime = DateTime.Parse("2024-11-10 14:15:00"),
                    CancellationReason = "Key speaker unavailable due to health reasons"
                },
                new MeetingsModel {
                    MeetingID = 6,
                    MeetingDate = DateTime.Parse("2024-10-25 13:30:00"),
                    MeetingVenue = "Conference Room C (Room 103)",
                    MeetingType = "Department Meeting",
                    Department = "Electrical Engineering",
                    MeetingDescription = "Curriculum revision meeting for B.Tech program",
                    DocumentPath = "curriculum_update.docx",
                    Created = DateTime.Parse("2024-10-15 11:10:00"),
                    Modified = DateTime.Parse("2024-10-26 09:20:00"),
                    IsCancelled = false,
                    CancellationDateTime = null,
                    CancellationReason = ""
                },
                // Add more meetings here following the same pattern...
                // I'll add a few more as examples
                new MeetingsModel {
                    MeetingID = 11,
                    MeetingDate = DateTime.Parse("2024-11-25 10:00:00"),
                    MeetingVenue = "Auditorium (Main)",
                    MeetingType = "Annual Review",
                    Department = "Business Administration",
                    MeetingDescription = "Annual department performance review and planning for next year",
                    DocumentPath = "",
                    Created = DateTime.Parse("2024-11-10 09:15:00"),
                    Modified = DateTime.Parse("2024-11-18 16:30:00"),
                    IsCancelled = true,
                    CancellationDateTime = DateTime.Parse("2024-11-18 16:30:00"),
                    CancellationReason = "Venue unavailable due to maintenance work"
                },
                new MeetingsModel {
                    MeetingID = 20,
                    MeetingDate = DateTime.Parse("2024-11-13 10:00:00"),
                    MeetingVenue = "Seminar Hall A",
                    MeetingType = "Guest Lecture",
                    Department = "Electrical Engineering",
                    MeetingDescription = "Invited talk by industry expert on renewable energy trends",
                    DocumentPath = "",
                    Created = DateTime.Parse("2024-10-30 14:20:00"),
                    Modified = DateTime.Parse("2024-10-30 14:20:00"),
                    IsCancelled = true,
                    CancellationDateTime = DateTime.Parse("2024-11-05 09:15:00"),
                    CancellationReason = "Guest speaker's flight cancelled due to weather conditions"
                }
            };

            // Store in ViewBag
            ViewBag.Meetings = meetings;

            return View();
        }

        public IActionResult MeetingAddEdit()
        {
            return View();
        }
    }
}