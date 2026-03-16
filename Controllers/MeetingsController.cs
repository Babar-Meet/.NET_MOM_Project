using Microsoft.AspNetCore.Mvc;
using MOM_Project.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MOM_Project.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly IConfiguration _configuration;

        public MeetingsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection") ?? "";
        }

        private void LoadLookupData()
        {
            List<MeetingVenueModel> venues = new List<MeetingVenueModel>();
            List<MeetingTypeModel> types = new List<MeetingTypeModel>();
            List<DepartmentModel> departments = new List<DepartmentModel>();

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();

                // Venues
                using (SqlCommand cmd = new SqlCommand("MOM_MeetingVenue_GetAll", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read()) venues.Add(new MeetingVenueModel { MeetingVenueID = (int)r["MeetingVenueID"], MeetingVenueName = r["MeetingVenueName"].ToString()! });
                    }
                }

                // Types
                using (SqlCommand cmd = new SqlCommand("MOM_MeetingType_GetAll", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read()) types.Add(new MeetingTypeModel { MeetingTypeID = (int)r["MeetingTypeID"], MeetingTypeName = r["MeetingTypeName"].ToString()! });
                    }
                }

                // Departments
                using (SqlCommand cmd = new SqlCommand("MOM_Department_GetAll", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read()) departments.Add(new DepartmentModel { DepartmentID = (int)r["DepartmentID"], DepartmentName = r["DepartmentName"].ToString()! });
                    }
                }

                con.Close();
            }

            ViewBag.Venues = venues;
            ViewBag.MeetingTypes = types;
            ViewBag.Departments = departments;
        }

        public IActionResult MeetingList()
        {
            List<MeetingsModel> meetings = new List<MeetingsModel>();

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MOM_Meetings_GetAll", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    meetings.Add(new MeetingsModel
                    {
                        MeetingID = Convert.ToInt32(reader["MeetingID"]),
                        MeetingDate = Convert.ToDateTime(reader["MeetingDate"]),
                        MeetingVenueID = Convert.ToInt32(reader["MeetingVenueID"]),
                        MeetingVenueName = reader["MeetingVenueName"].ToString() ?? string.Empty,
                        MeetingTypeID = Convert.ToInt32(reader["MeetingTypeID"]),
                        MeetingTypeName = reader["MeetingTypeName"].ToString() ?? string.Empty,
                        DepartmentID = Convert.ToInt32(reader["DepartmentID"]),
                        DepartmentName = reader["DepartmentName"].ToString() ?? string.Empty,
                        MeetingDescription = reader["MeetingDescription"] != DBNull.Value ? reader["MeetingDescription"].ToString() ?? string.Empty : string.Empty,
                        DocumentPath = reader["DocumentPath"] != DBNull.Value ? reader["DocumentPath"].ToString() ?? string.Empty : string.Empty,
                        Created = Convert.ToDateTime(reader["Created"]),
                        Modified = Convert.ToDateTime(reader["Modified"]),
                        IsCancelled = Convert.ToBoolean(reader["IsCancelled"]),
                        CancellationDateTime = reader["CancellationDateTime"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["CancellationDateTime"]) : null,
                        CancellationReason = reader["CancellationReason"] != DBNull.Value ? reader["CancellationReason"].ToString() ?? string.Empty : string.Empty
                    });
                }
                con.Close();
            }

            ViewBag.Meetings = meetings;
            return View();
        }

        public IActionResult MeetingAddEdit(int? id)
        {
            LoadLookupData();
            MeetingsModel model = new MeetingsModel { MeetingDate = DateTime.Now };

            if (id.HasValue)
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("MOM_Meetings_GetByID", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MeetingID", id.Value);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        model.MeetingID = Convert.ToInt32(reader["MeetingID"]);
                        model.MeetingDate = Convert.ToDateTime(reader["MeetingDate"]);
                        model.MeetingVenueID = Convert.ToInt32(reader["MeetingVenueID"]);
                        model.MeetingTypeID = Convert.ToInt32(reader["MeetingTypeID"]);
                        model.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                        model.MeetingDescription = reader["MeetingDescription"] != DBNull.Value ? reader["MeetingDescription"].ToString() : "";
                        model.DocumentPath = reader["DocumentPath"] != DBNull.Value ? reader["DocumentPath"].ToString() : "";
                        model.Created = Convert.ToDateTime(reader["Created"]);
                        model.Modified = Convert.ToDateTime(reader["Modified"]);
                        model.IsCancelled = Convert.ToBoolean(reader["IsCancelled"]);
                        model.CancellationDateTime = reader["CancellationDateTime"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["CancellationDateTime"]) : null;
                        model.CancellationReason = reader["CancellationReason"] != DBNull.Value ? reader["CancellationReason"].ToString() : "";
                    }
                    con.Close();
                }
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult saveMeeting(MeetingsModel model)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    if (model.MeetingID == 0)
                    {
                        cmd.CommandText = "MOM_Meetings_Insert";
                    }
                    else
                    {
                        cmd.CommandText = "MOM_Meetings_Update";
                        cmd.Parameters.AddWithValue("@MeetingID", model.MeetingID);
                    }

                    cmd.Parameters.AddWithValue("@MeetingDate", model.MeetingDate);
                    cmd.Parameters.AddWithValue("@MeetingVenueID", model.MeetingVenueID);
                    cmd.Parameters.AddWithValue("@MeetingTypeID", model.MeetingTypeID);
                    cmd.Parameters.AddWithValue("@DepartmentID", model.DepartmentID);
                    cmd.Parameters.AddWithValue("@MeetingDescription", model.MeetingDescription ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DocumentPath", model.DocumentPath ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsCancelled", model.IsCancelled);
                    cmd.Parameters.AddWithValue("@CancellationDateTime", model.CancellationDateTime ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CancellationReason", model.CancellationReason ?? (object)DBNull.Value);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                return RedirectToAction("MeetingList");
            }
            LoadLookupData();
            return View("MeetingAddEdit", model);
        }

        public IActionResult Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MOM_Meetings_Delete", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MeetingID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return RedirectToAction("MeetingList");
        }
    }
}
