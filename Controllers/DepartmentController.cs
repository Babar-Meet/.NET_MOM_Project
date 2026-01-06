using Microsoft.AspNetCore.Mvc;
using MOM_Project.Models;
using System;
using System.Collections.Generic;

namespace MOM_Project.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult DepartmentList()
        {
            // Create sample data using DepartmentModel
            var departments = new List<DepartmentModel>
            {
                new DepartmentModel { DepartmentID = 3331, DepartmentName = "Computer Science & Engineering", Created = DateTime.Parse("2023-03-15 10:30:00"), Modified = DateTime.Parse("2024-11-22 14:15:00") },
                new DepartmentModel{ DepartmentID= 2, DepartmentName = "Information Technology", Created = DateTime.Parse("2023-05-10 09:45:00"), Modified = DateTime.Parse("2024-10-15 16:20:00") },
                new DepartmentModel{ DepartmentID= 3, DepartmentName = "Mechanical Engineering", Created = DateTime.Parse("2022-08-22 11:00:00"), Modified = DateTime.Parse("2024-09-30 13:45:00") },
                new DepartmentModel{ DepartmentID= 4, DepartmentName = "Electrical Engineering", Created = DateTime.Parse("2022-11-05 14:25:00"), Modified = DateTime.Parse("2024-11-10 10:10:00") },
                new DepartmentModel{ DepartmentID= 5, DepartmentName = "Civil Engineering", Created = DateTime.Parse("2023-01-18 08:15:00"), Modified = DateTime.Parse("2024-08-25 15:30:00") },
                new DepartmentModel{ DepartmentID= 6, DepartmentName = "Business Administration", Created = DateTime.Parse("2023-06-30 12:45:00"), Modified = DateTime.Parse("2024-12-01 09:00:00") },
                new DepartmentModel{ DepartmentID= 7, DepartmentName = "Humanities & Social Sciences", Created = DateTime.Parse("2022-09-14 13:20:00"), Modified = DateTime.Parse("2024-07-19 11:40:00") },
                new DepartmentModel{ DepartmentID= 8, DepartmentName = "Mathematics", Created = DateTime.Parse("2023-02-28 10:10:00"), Modified = DateTime.Parse("2024-11-05 14:50:00") },
                new DepartmentModel{ DepartmentID= 9, DepartmentName = "Physics", Created = DateTime.Parse("2023-04-12 15:35:00"), Modified = DateTime.Parse("2024-10-28 08:25:00") },
                new DepartmentModel{ DepartmentID= 10, DepartmentName = "Chemistry", Created = DateTime.Parse("2023-07-25 09:50:00"), Modified = DateTime.Parse("2024-09-12 12:15:00") },
                new DepartmentModel{ DepartmentID= 11, DepartmentName = "Library & Information Science", Created = DateTime.Parse("2022-12-08 11:30:00"), Modified = DateTime.Parse("2024-08-14 16:45:00") },
                new DepartmentModel{ DepartmentID= 12, DepartmentName = "Student Affairs", Created = DateTime.Parse("2023-03-05 14:00:00"), Modified = DateTime.Parse("2024-11-30 10:05:00") },
                new DepartmentModel{ DepartmentID= 13, DepartmentName = "Research & Development", Created = DateTime.Parse("2023-08-20 08:40:00"), Modified = DateTime.Parse("2024-10-10 13:20:00") },
                new DepartmentModel{ DepartmentID= 14, DepartmentName = "Placement Cell", Created = DateTime.Parse("2023-10-05 12:10:00"), Modified = DateTime.Parse("2024-09-05 15:55:00") },
                new DepartmentModel{ DepartmentID= 15, DepartmentName = "Administration", Created = DateTime.Parse("2022-10-01 09:00:00"), Modified = DateTime.Parse("2024-12-05 11:30:00") }
            };

            // Store in ViewBag
            ViewBag.Departments = departments;

            return View();
        }

        public IActionResult DepartmentAddEdit()
        {
            return View();
        }
    }
}