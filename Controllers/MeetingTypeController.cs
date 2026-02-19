using Microsoft.AspNetCore.Mvc;
using MOM_Project.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MOM_Project.Controllers
{
    public class MeetingTypeController : Controller
    {
        private readonly IConfiguration _configuration;

        public MeetingTypeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }

        public IActionResult MeetingTypeList()
        {
            List<MeetingTypeModel> meetingTypes = new List<MeetingTypeModel>();

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "MOM_MeetingType_GetAll";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    MeetingTypeModel meetingType = new MeetingTypeModel();
                    meetingType.MeetingTypeID = Convert.ToInt32(reader["MeetingTypeID"]);
                    meetingType.MeetingTypeName = reader["MeetingTypeName"].ToString();
                    meetingType.Remarks = reader["Remarks"] != DBNull.Value ? reader["Remarks"].ToString() : "";
                    meetingType.Created = reader["Created"] != DBNull.Value ? Convert.ToDateTime(reader["Created"]) : DateTime.Now;
                    meetingType.Modified = reader["Modified"] != DBNull.Value ? Convert.ToDateTime(reader["Modified"]) : DateTime.Now;

                    meetingTypes.Add(meetingType);
                }

                reader.Close();
                con.Close();
            }

            ViewBag.MeetingTypes = meetingTypes;
            return View();
        }

        public IActionResult MeetingTypeAddEdit(int? id)
        {
            MeetingTypeModel model = new MeetingTypeModel();

            if (id.HasValue)
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "MOM_MeetingType_GetByID";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter p = new SqlParameter();
                    p.ParameterName = "@MeetingTypeID";
                    p.SqlDbType = System.Data.SqlDbType.Int;
                    p.Value = id.Value;

                    cmd.Parameters.Add(p);

                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        model.MeetingTypeID = Convert.ToInt32(reader["MeetingTypeID"]);
                        model.MeetingTypeName = reader["MeetingTypeName"].ToString();
                        model.Remarks = reader["Remarks"] != DBNull.Value ? reader["Remarks"].ToString() : "";
                        model.Created = reader["Created"] != DBNull.Value ? Convert.ToDateTime(reader["Created"]) : DateTime.Now;
                        model.Modified = reader["Modified"] != DBNull.Value ? Convert.ToDateTime(reader["Modified"]) : DateTime.Now;
                    }

                    reader.Close();
                    con.Close();
                }
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult saveMeetingType(MeetingTypeModel model)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand();

                    if (model.MeetingTypeID == 0)
                    {
                        // Insert new meeting type
                        cmd.CommandText = "MOM_MeetingType_Insert";
                    }
                    else
                    {
                        // Update existing meeting type
                        cmd.CommandText = "MOM_MeetingType_Update";

                        SqlParameter p = new SqlParameter();
                        p.ParameterName = "@MeetingTypeID";
                        p.SqlDbType = System.Data.SqlDbType.Int;
                        p.Value = model.MeetingTypeID;
                        cmd.Parameters.Add(p);
                    }

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = con;

                    SqlParameter pName = new SqlParameter();
                    pName.ParameterName = "@MeetingTypeName";
                    pName.SqlDbType = System.Data.SqlDbType.NVarChar;
                    pName.Value = model.MeetingTypeName;
                    cmd.Parameters.Add(pName);

                    SqlParameter pRemarks = new SqlParameter();
                    pRemarks.ParameterName = "@Remarks";
                    pRemarks.SqlDbType = System.Data.SqlDbType.NVarChar;
                    pRemarks.Value = model.Remarks ?? "";
                    cmd.Parameters.Add(pRemarks);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                return RedirectToAction("MeetingTypeList");
            }

            return View("MeetingTypeAddEdit", model);
        }

        public IActionResult Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "MOM_MeetingType_delete";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter p = new SqlParameter();
                p.ParameterName = "@MeetingTypeID";
                p.SqlDbType = System.Data.SqlDbType.Int;
                p.Value = id;

                cmd.Parameters.Add(p);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            return RedirectToAction("MeetingTypeList");
        }
    }
}
