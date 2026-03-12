using Microsoft.AspNetCore.Mvc;
using MOM_Project.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MOM_Project.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IConfiguration _configuration;

        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection") ?? "";
        }

        public IActionResult DepartmentList()
        {
            List<DepartmentModel> departments = new List<DepartmentModel>();

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "MOM_Department_GetAll";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DepartmentModel dept = new DepartmentModel();
                    dept.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                    dept.DepartmentName = reader["DepartmentName"].ToString();
                    dept.Created = Convert.ToDateTime(reader["Created"]);
                    dept.Modified = Convert.ToDateTime(reader["Modified"]);

                    departments.Add(dept);
                }

                reader.Close();
                con.Close();
            }

            ViewBag.Departments = departments;
            return View();
        }

        public IActionResult DepartmentAddEdit(int? id)
        {
            DepartmentModel model = new DepartmentModel();

            if (id.HasValue)
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "MOM_Department_GetByID";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter p = new SqlParameter();
                    p.ParameterName = "@DepartmentID";
                    p.SqlDbType = System.Data.SqlDbType.Int;
                    p.Value = id.Value;

                    cmd.Parameters.Add(p);

                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        model.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                        model.DepartmentName = reader["DepartmentName"].ToString();
                        model.Created = Convert.ToDateTime(reader["Created"]);
                        model.Modified = Convert.ToDateTime(reader["Modified"]);
                    }

                    reader.Close();
                    con.Close();
                }
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult saveDept(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand();

                    if (model.DepartmentID == 0)
                    {
                        // Insert new department
                        cmd.CommandText = "MOM_Department_Insert";
                    }
                    else
                    {
                        // Update existing department
                        cmd.CommandText = "MOM_Department_Update";
                        
                        SqlParameter p = new SqlParameter();
                        p.ParameterName = "@DepartmentID";
                        p.SqlDbType = System.Data.SqlDbType.Int;
                        p.Value = model.DepartmentID;
                        cmd.Parameters.Add(p);
                    }

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = con;

                    SqlParameter pName = new SqlParameter();
                    pName.ParameterName = "@DepartmentName";
                    pName.SqlDbType = System.Data.SqlDbType.NVarChar;
                    pName.Value = model.DepartmentName;
                    cmd.Parameters.Add(pName);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                return RedirectToAction("DepartmentList");
            }

            return View("DepartmentAddEdit", model);
        }

        public IActionResult Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "MOM_Department_Delete";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter p = new SqlParameter();
                p.ParameterName = "@DepartmentID";
                p.SqlDbType = System.Data.SqlDbType.Int;
                p.Value = id;

                cmd.Parameters.Add(p);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            return RedirectToAction("DepartmentList");
        }
    }
}
