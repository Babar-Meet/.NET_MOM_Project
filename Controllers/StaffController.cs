using Microsoft.AspNetCore.Mvc;
using MOM_Project.Models;
using System;
using System.Collections.Generic;

namespace MOM_Project.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult StaffList()
        {
            // Create sample Staff data with DepartmentID
            var staffList = new List<StaffModel>
            {
                new StaffModel {
                    StaffID = 1,
                    DepartmentID = 1, // Computer Science & Engineering
                    StaffName = "Dr. Rajesh Sharma",
                    MobileNo = "+91-9876543210",
                    EmailAddress = "rajesh.sharma@darshanuniversity.edu",
                    Remarks = "Head of Department",
                    Created = DateTime.Parse("2022-03-10 09:30:00"),
                    Modified = DateTime.Parse("2024-11-05 14:25:00")
                },
                new StaffModel {
                    StaffID = 2,
                    DepartmentID = 1, // Computer Science & Engineering
                    StaffName = "Prof. Priya Patel",
                    MobileNo = "+91-9876543211",
                    EmailAddress = "priya.patel@darshanuniversity.edu",
                    Remarks = "Professor - AI & ML",
                    Created = DateTime.Parse("2022-05-15 10:45:00"),
                    Modified = DateTime.Parse("2024-10-18 11:40:00")
                },
                new StaffModel {
                    StaffID = 3,
                    DepartmentID = 2, // Information Technology
                    StaffName = "Dr. Sunil Kumar",
                    MobileNo = "+91-9876543212",
                    EmailAddress = "sunil.kumar@darshanuniversity.edu",
                    Remarks = "Associate Professor",
                    Created = DateTime.Parse("2022-06-20 14:20:00"),
                    Modified = DateTime.Parse("2024-11-12 16:30:00")
                },
                new StaffModel {
                    StaffID = 4,
                    DepartmentID = 2, // Information Technology
                    StaffName = "Ms. Anjali Desai",
                    MobileNo = "+91-9876543213",
                    EmailAddress = "anjali.desai@darshanuniversity.edu",
                    Remarks = "Assistant Professor - Cybersecurity",
                    Created = DateTime.Parse("2022-07-12 11:15:00"),
                    Modified = DateTime.Parse("2024-10-22 10:20:00")
                },
                new StaffModel {
                    StaffID = 5,
                    DepartmentID = 3, // Mechanical Engineering
                    StaffName = "Dr. Vikram Singh",
                    MobileNo = "+91-9876543214",
                    EmailAddress = "vikram.singh@darshanuniversity.edu",
                    Remarks = "Professor & Research Coordinator",
                    Created = DateTime.Parse("2021-09-05 08:45:00"),
                    Modified = DateTime.Parse("2024-11-08 13:45:00")
                },
                new StaffModel {
                    StaffID = 6,
                    DepartmentID = 3, // Mechanical Engineering
                    StaffName = "Mr. Harish Mehta",
                    MobileNo = "+91-9876543215",
                    EmailAddress = "harish.mehta@darshanuniversity.edu",
                    Remarks = "Lab Incharge",
                    Created = DateTime.Parse("2022-01-22 15:30:00"),
                    Modified = DateTime.Parse("2024-10-15 12:50:00")
                },
                new StaffModel {
                    StaffID = 7,
                    DepartmentID = 4, // Electrical Engineering
                    StaffName = "Dr. Nisha Gupta",
                    MobileNo = "+91-9876543216",
                    EmailAddress = "nisha.gupta@darshanuniversity.edu",
                    Remarks = "Head of Department",
                    Created = DateTime.Parse("2021-11-18 10:10:00"),
                    Modified = DateTime.Parse("2024-11-10 09:35:00")
                },
                new StaffModel {
                    StaffID = 8,
                    DepartmentID = 4, // Electrical Engineering
                    StaffName = "Prof. Amit Joshi",
                    MobileNo = "+91-9876543217",
                    EmailAddress = "amit.joshi@darshanuniversity.edu",
                    Remarks = "Professor - Power Systems",
                    Created = DateTime.Parse("2022-02-14 13:25:00"),
                    Modified = DateTime.Parse("2024-10-30 14:15:00")
                },
                new StaffModel {
                    StaffID = 9,
                    DepartmentID = 5, // Civil Engineering
                    StaffName = "Dr. Sanjay Verma",
                    MobileNo = "+91-9876543218",
                    EmailAddress = "sanjay.verma@darshanuniversity.edu",
                    Remarks = "Professor - Structural Engineering",
                    Created = DateTime.Parse("2022-03-05 09:50:00"),
                    Modified = DateTime.Parse("2024-11-05 11:20:00")
                },
                new StaffModel {
                    StaffID = 10,
                    DepartmentID = 5, // Civil Engineering
                    StaffName = "Ms. Radhika Iyer",
                    MobileNo = "+91-9876543219",
                    EmailAddress = "radhika.iyer@darshanuniversity.edu",
                    Remarks = "Assistant Professor",
                    Created = DateTime.Parse("2022-07-30 16:40:00"),
                    Modified = DateTime.Parse("2024-10-25 10:45:00")
                },
                new StaffModel {
                    StaffID = 11,
                    DepartmentID = 6, // Business Administration
                    StaffName = "Dr. Meera Nair",
                    MobileNo = "+91-9876543220",
                    EmailAddress = "meera.nair@darshanuniversity.edu",
                    Remarks = "Dean - Faculty of Management",
                    Created = DateTime.Parse("2022-04-12 11:30:00"),
                    Modified = DateTime.Parse("2024-11-15 15:10:00")
                },
                new StaffModel {
                    StaffID = 12,
                    DepartmentID = 6, // Business Administration
                    StaffName = "Prof. Karan Malhotra",
                    MobileNo = "+91-9876543221",
                    EmailAddress = "karan.malhotra@darshanuniversity.edu",
                    Remarks = "Professor - Marketing",
                    Created = DateTime.Parse("2022-08-08 14:55:00"),
                    Modified = DateTime.Parse("2024-10-18 13:30:00")
                },
                new StaffModel {
                    StaffID = 13,
                    DepartmentID = 7, // Humanities & Social Sciences
                    StaffName = "Dr. Aruna Reddy",
                    MobileNo = "+91-9876543222",
                    EmailAddress = "aruna.reddy@darshanuniversity.edu",
                    Remarks = "Head of Department",
                    Created = DateTime.Parse("2022-02-28 10:05:00"),
                    Modified = DateTime.Parse("2024-11-08 09:25:00")
                },
                new StaffModel {
                    StaffID = 14,
                    DepartmentID = 7, // Humanities & Social Sciences
                    StaffName = "Ms. Sneha Kapoor",
                    MobileNo = "+91-9876543223",
                    EmailAddress = "sneha.kapoor@darshanuniversity.edu",
                    Remarks = "Assistant Professor - Psychology",
                    Created = DateTime.Parse("2022-09-17 12:40:00"),
                    Modified = DateTime.Parse("2024-10-22 11:50:00")
                },
                new StaffModel {
                    StaffID = 15,
                    DepartmentID = 8, // Mathematics
                    StaffName = "Dr. Ramesh Choudhary",
                    MobileNo = "+91-9876543224",
                    EmailAddress = "ramesh.choudhary@darshanuniversity.edu",
                    Remarks = "Professor - Applied Mathematics",
                    Created = DateTime.Parse("2022-03-25 09:15:00"),
                    Modified = DateTime.Parse("2024-11-12 14:40:00")
                },
                new StaffModel {
                    StaffID = 16,
                    DepartmentID = 8, // Mathematics
                    StaffName = "Prof. Deepa Shah",
                    MobileNo = "+91-9876543225",
                    EmailAddress = "deepa.shah@darshanuniversity.edu",
                    Remarks = "Associate Professor",
                    Created = DateTime.Parse("2022-10-05 15:20:00"),
                    Modified = DateTime.Parse("2024-10-30 16:25:00")
                },
                new StaffModel {
                    StaffID = 17,
                    DepartmentID = 9, // Physics
                    StaffName = "Dr. Suresh Menon",
                    MobileNo = "+91-9876543226",
                    EmailAddress = "suresh.menon@darshanuniversity.edu",
                    Remarks = "Head of Department",
                    Created = DateTime.Parse("2022-05-08 11:00:00"),
                    Modified = DateTime.Parse("2024-11-05 10:15:00")
                },
                new StaffModel {
                    StaffID = 18,
                    DepartmentID = 9, // Physics
                    StaffName = "Mr. Vijay Anand",
                    MobileNo = "+91-9876543227",
                    EmailAddress = "vijay.anand@darshanuniversity.edu",
                    Remarks = "Lab Assistant",
                    Created = DateTime.Parse("2022-11-20 13:45:00"),
                    Modified = DateTime.Parse("2024-10-15 12:10:00")
                },
                new StaffModel {
                    StaffID = 19,
                    DepartmentID = 10, // Chemistry
                    StaffName = "Dr. Pooja Bhatt",
                    MobileNo = "+91-9876543228",
                    EmailAddress = "pooja.bhatt@darshanuniversity.edu",
                    Remarks = "Professor - Organic Chemistry",
                    Created = DateTime.Parse("2022-06-18 10:30:00"),
                    Modified = DateTime.Parse("2024-11-10 13:55:00")
                },
                new StaffModel {
                    StaffID = 20,
                    DepartmentID = 10, // Chemistry
                    StaffName = "Ms. Ritu Sharma",
                    MobileNo = "+91-9876543229",
                    EmailAddress = "ritu.sharma@darshanuniversity.edu",
                    Remarks = "Research Scholar",
                    Created = DateTime.Parse("2023-01-15 14:10:00"),
                    Modified = DateTime.Parse("2024-10-25 09:40:00")
                },
                new StaffModel {
                    StaffID = 21,
                    DepartmentID = 11, // Library & Information Science
                    StaffName = "Mr. Arun Kumar",
                    MobileNo = "+91-9876543230",
                    EmailAddress = "arun.kumar@darshanuniversity.edu",
                    Remarks = "Chief Librarian",
                    Created = DateTime.Parse("2022-04-05 09:00:00"),
                    Modified = DateTime.Parse("2024-11-08 11:30:00")
                },
                new StaffModel {
                    StaffID = 22,
                    DepartmentID = 12, // Student Affairs
                    StaffName = "Ms. Geeta Sharma",
                    MobileNo = "+91-9876543231",
                    EmailAddress = "geeta.sharma@darshanuniversity.edu",
                    Remarks = "Student Coordinator",
                    Created = DateTime.Parse("2022-07-22 12:25:00"),
                    Modified = DateTime.Parse("2024-11-12 15:45:00")
                },
                new StaffModel {
                    StaffID = 23,
                    DepartmentID = 13, // Research & Development
                    StaffName = "Dr. Anand Prakash",
                    MobileNo = "+91-9876543232",
                    EmailAddress = "anand.prakash@darshanuniversity.edu",
                    Remarks = "Director - R&D",
                    Created = DateTime.Parse("2022-03-18 08:45:00"),
                    Modified = DateTime.Parse("2024-11-05 14:20:00")
                },
                new StaffModel {
                    StaffID = 24,
                    DepartmentID = 14, // Placement Cell
                    StaffName = "Mr. Rohan Desai",
                    MobileNo = "+91-9876543233",
                    EmailAddress = "rohan.desai@darshanuniversity.edu",
                    Remarks = "Placement Officer",
                    Created = DateTime.Parse("2022-09-10 10:50:00"),
                    Modified = DateTime.Parse("2024-11-10 13:15:00")
                },
                new StaffModel {
                    StaffID = 25,
                    DepartmentID = 15, // Administration
                    StaffName = "Mr. Ajay Mehta",
                    MobileNo = "+91-9876543234",
                    EmailAddress = "ajay.mehta@darshanuniversity.edu",
                    Remarks = "Administrative Officer",
                    Created = DateTime.Parse("2022-01-10 09:15:00"),
                    Modified = DateTime.Parse("2024-11-15 16:30:00")
                }
            };

            // Create department mapping dictionary
            var departmentMap = new Dictionary<int, string>
            {
                {1, "Computer Science & Engineering"},
                {2, "Information Technology"},
                {3, "Mechanical Engineering"},
                {4, "Electrical Engineering"},
                {5, "Civil Engineering"},
                {6, "Business Administration"},
                {7, "Humanities & Social Sciences"},
                {8, "Mathematics"},
                {9, "Physics"},
                {10, "Chemistry"},
                {11, "Library & Information Science"},
                {12, "Student Affairs"},
                {13, "Research & Development"},
                {14, "Placement Cell"},
                {15, "Administration"}
            };

            // Store in ViewBag
            ViewBag.StaffList = staffList;
            ViewBag.DepartmentMap = departmentMap;

            return View();
        }

        public IActionResult StaffAddEdit()
        {
            return View();
        }
    }
}