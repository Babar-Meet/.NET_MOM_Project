using Microsoft.AspNetCore.Mvc;
using MOM_Project.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MOM_Project.Controllers
{
    public class StaffController : Controller
    {
        private readonly IConfiguration _configuration;

        public StaffController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection") ?? "";
        }

        private void LoadDepartments()
        {
            List<DepartmentModel> departments = new List<DepartmentModel>();
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MOM_Department_GetAll", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    departments.Add(new DepartmentModel
                    {
                        DepartmentID = Convert.ToInt32(reader["DepartmentID"]),
                        DepartmentName = reader["DepartmentName"].ToString()!
                    });
                }
                con.Close();
            }
            ViewBag.Departments = departments;
        }

        public IActionResult StaffList()
        {
            List<StaffModel> staffList = new List<StaffModel>();

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MOM_Staff_GetAll", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    staffList.Add(new StaffModel
                    {
                        StaffID = Convert.ToInt32(reader["StaffID"]),
                        DepartmentID = Convert.ToInt32(reader["DepartmentID"]),
                        DepartmentName = reader["DepartmentName"].ToString(),
                        StaffName = reader["StaffName"].ToString()!,
                        MobileNo = reader["MobileNo"].ToString()!,
                        EmailAddress = reader["EmailAddress"].ToString()!,
                        Remarks = reader["Remarks"] != DBNull.Value ? reader["Remarks"].ToString() : "",
                        Created = Convert.ToDateTime(reader["Created"]),
                        Modified = Convert.ToDateTime(reader["Modified"])
                    });
                }
                con.Close();
            }

            ViewBag.StaffList = staffList;
            return View();
        }

        public IActionResult StaffAddEdit(int? id)
        {
            LoadDepartments();
            StaffModel model = new StaffModel();

            if (id.HasValue)
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("MOM_Staff_GetByID", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StaffID", id.Value);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        model.StaffID = Convert.ToInt32(reader["StaffID"]);
                        model.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                        model.StaffName = reader["StaffName"].ToString()!;
                        model.MobileNo = reader["MobileNo"].ToString()!;
                        model.EmailAddress = reader["EmailAddress"].ToString()!;
                        model.Remarks = reader["Remarks"] != DBNull.Value ? reader["Remarks"].ToString() : "";
                        model.Created = Convert.ToDateTime(reader["Created"]);
                        model.Modified = Convert.ToDateTime(reader["Modified"]);
                    }
                    con.Close();
                }
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult saveStaff(StaffModel model)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    if (model.StaffID == 0)
                    {
                        cmd.CommandText = "MOM_Staff_Insert";
                    }
                    else
                    {
                        cmd.CommandText = "MOM_Staff_Update";
                        cmd.Parameters.AddWithValue("@StaffID", model.StaffID);
                    }

                    cmd.Parameters.AddWithValue("@DepartmentID", model.DepartmentID);
                    cmd.Parameters.AddWithValue("@StaffName", model.StaffName);
                    cmd.Parameters.AddWithValue("@MobileNo", model.MobileNo);
                    cmd.Parameters.AddWithValue("@EmailAddress", model.EmailAddress);
                    cmd.Parameters.AddWithValue("@Remarks", model.Remarks ?? (object)DBNull.Value);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                return RedirectToAction("StaffList");
            }
            LoadDepartments();
            return View("StaffAddEdit", model);
        }

        public IActionResult Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MOM_Staff_Delete", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return RedirectToAction("StaffList");
        }
    }
}