using Microsoft.AspNetCore.Mvc;
using MOM_Project.Models;
using System;
using System.Collections.Generic;

namespace MOM_Project.Controllers
{
    public class MeetingTypeController : Controller
    {
        public IActionResult MeetingTypeList()
        {
            // Create sample MeetingType data
            var meetingTypes = new List<MeetingTypeModel>
            {
                new MeetingTypeModel {
                    MeetingTypeID = 1,
                    MeetingTypeName = "Project Review Meeting",
                    Remarks = "Review progress of ongoing projects",
                    Created = DateTime.Parse("2023-01-15 09:30:00"),
                    Modified = DateTime.Parse("2024-10-05 14:20:00")
                },
                new MeetingTypeModel {
                    MeetingTypeID = 2,
                    MeetingTypeName = "Planning Session",
                    Remarks = "Strategic planning and roadmap discussions",
                    Created = DateTime.Parse("2023-01-15 10:15:00"),
                    Modified = DateTime.Parse("2024-09-18 11:45:00")
                },
                new MeetingTypeModel {
                    MeetingTypeID = 3,
                    MeetingTypeName = "Faculty Meeting",
                    Remarks = "Regular faculty coordination and updates",
                    Created = DateTime.Parse("2023-02-10 08:45:00"),
                    Modified = DateTime.Parse("2024-11-12 16:30:00")
                },
                new MeetingTypeModel {
                    MeetingTypeID = 4,
                    MeetingTypeName = "Department Meeting",
                    Remarks = "Department-level coordination and decision making",
                    Created = DateTime.Parse("2023-02-10 09:00:00"),
                    Modified = DateTime.Parse("2024-10-22 10:15:00")
                },
                new MeetingTypeModel {
                    MeetingTypeID = 5,
                    MeetingTypeName = "Budget Review",
                    Remarks = "Financial planning and budget allocation discussions",
                    Created = DateTime.Parse("2023-03-05 14:30:00"),
                    Modified = DateTime.Parse("2024-11-05 13:40:00")
                },
                new MeetingTypeModel {
                    MeetingTypeID = 6,
                    MeetingTypeName = "Training Workshop",
                    Remarks = "Faculty development and training sessions",
                    Created = DateTime.Parse("2023-03-20 11:20:00"),
                    Modified = DateTime.Parse("2024-09-30 15:25:00")
                },
                new MeetingTypeModel {
                    MeetingTypeID = 7,
                    MeetingTypeName = "Research Committee",
                    Remarks = "Research proposals and grant discussions",
                    Created = DateTime.Parse("2023-04-12 10:00:00"),
                    Modified = DateTime.Parse("2024-10-18 09:50:00")
                },
                new MeetingTypeModel {
                    MeetingTypeID = 8,
                    MeetingTypeName = "Exam Coordination",
                    Remarks = "Examination schedule and paper setting meetings",
                    Created = DateTime.Parse("2023-05-08 13:15:00"),
                    Modified = DateTime.Parse("2024-11-08 14:10:00")
                },
                new MeetingTypeModel {
                    MeetingTypeID = 9,
                    MeetingTypeName = "Technical Review",
                    Remarks = "Technical equipment and infrastructure reviews",
                    Created = DateTime.Parse("2023-05-22 15:45:00"),
                    Modified = DateTime.Parse("2024-10-30 11:35:00")
                },
                new MeetingTypeModel {
                    MeetingTypeID = 10,
                    MeetingTypeName = "Library Committee",
                    Remarks = "Library resources and acquisition meetings",
                    Created = DateTime.Parse("2023-06-10 09:30:00"),
                    Modified = DateTime.Parse("2024-09-25 12:20:00")
                },
                new MeetingTypeModel {
                    MeetingTypeID = 11,
                    MeetingTypeName = "Annual Review",
                    Remarks = "Annual performance and department reviews",
                    Created = DateTime.Parse("2023-07-05 14:00:00"),
                    Modified = DateTime.Parse("2024-11-15 10:45:00")
                },
                new MeetingTypeModel {
                    MeetingTypeID = 12,
                    MeetingTypeName = "Student Feedback",
                    Remarks = "Student grievance and feedback committee meetings",
                    Created = DateTime.Parse("2023-08-18 11:10:00"),
                    Modified = DateTime.Parse("2024-10-12 16:05:00")
                },
                new MeetingTypeModel {
                    MeetingTypeID = 13,
                    MeetingTypeName = "Project Discussion",
                    Remarks = "Student project evaluation and guidance meetings",
                    Created = DateTime.Parse("2023-09-22 10:30:00"),
                    Modified = DateTime.Parse("2024-11-20 13:25:00")
                },
                new MeetingTypeModel {
                    MeetingTypeID = 14,
                    MeetingTypeName = "Administrative Meeting",
                    Remarks = "University administration and policy meetings",
                    Created = DateTime.Parse("2023-10-15 08:45:00"),
                    Modified = DateTime.Parse("2024-10-28 09:15:00")
                },
                new MeetingTypeModel {
                    MeetingTypeID = 15,
                    MeetingTypeName = "Placement Committee",
                    Remarks = "Campus recruitment and placement planning",
                    Created = DateTime.Parse("2023-11-05 14:20:00"),
                    Modified = DateTime.Parse("2024-11-10 15:40:00")
                },
                new MeetingTypeModel {
                    MeetingTypeID = 16,
                    MeetingTypeName = "Research Meeting",
                    Remarks = "Research publication and patent discussions",
                    Created = DateTime.Parse("2023-12-12 11:45:00"),
                    Modified = DateTime.Parse("2024-10-05 14:30:00")
                },
                new MeetingTypeModel {
                    MeetingTypeID = 17,
                    MeetingTypeName = "Faculty Development",
                    Remarks = "Faculty orientation and development programs",
                    Created = DateTime.Parse("2024-01-10 09:15:00"),
                    Modified = DateTime.Parse("2024-11-18 10:50:00")
                },
                new MeetingTypeModel {
                    MeetingTypeID = 18,
                    MeetingTypeName = "Industry Collaboration",
                    Remarks = "Industry partnership and MoU discussions",
                    Created = DateTime.Parse("2024-01-25 15:30:00"),
                    Modified = DateTime.Parse("2024-10-15 12:25:00")
                },
                new MeetingTypeModel {
                    MeetingTypeID = 19,
                    MeetingTypeName = "Quality Assurance",
                    Remarks = "NAAC and quality assurance committee meetings",
                    Created = DateTime.Parse("2024-02-14 10:00:00"),
                    Modified = DateTime.Parse("2024-11-05 14:15:00")
                },
                new MeetingTypeModel {
                    MeetingTypeID = 20,
                    MeetingTypeName = "Guest Lecture",
                    Remarks = "Invited talks and guest lecture sessions",
                    Created = DateTime.Parse("2024-03-08 13:20:00"),
                    Modified = DateTime.Parse("2024-10-22 11:10:00")
                }
            };

            // Store in ViewBag
            ViewBag.MeetingTypes = meetingTypes;

            return View();
        }

        public IActionResult MeetingTypeAddEdit()
        {
            return View();
        }
    }
}