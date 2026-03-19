using Microsoft.AspNetCore.Mvc;
using MOM_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MOM_Project.Controllers
{
    public class MeetingMemberController : Controller
    {
        private readonly IConfiguration _configuration;

        public MeetingMemberController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection") ?? "";
        }

        private void LoadLookupData()
        {
            List<MeetingsModel> meetings = new List<MeetingsModel>();
            List<StaffModel> staffList = new List<StaffModel>();

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();

                // Meetings
                using (SqlCommand cmd = new SqlCommand("MOM_Meetings_GetAll", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read()) meetings.Add(new MeetingsModel { MeetingID = (int)r["MeetingID"], MeetingDate = (DateTime)r["MeetingDate"] });
                    }
                }

                // Staff
                using (SqlCommand cmd = new SqlCommand("MOM_Staff_GetAll", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read()) staffList.Add(new StaffModel { StaffID = (int)r["StaffID"], StaffName = r["StaffName"].ToString()! });
                    }
                }

                con.Close();
            }

            ViewBag.Meetings = meetings;
            ViewBag.Staff = staffList;
        }

        public IActionResult MeetingMemberList(int? meetingId)
        {
            List<MeetingMemberModel> members = new List<MeetingMemberModel>();

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MOM_MeetingMember_GetAll", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    members.Add(new MeetingMemberModel
                    {
                        MeetingMemberID = Convert.ToInt32(reader["MeetingMemberID"]),
                        MeetingID = Convert.ToInt32(reader["MeetingID"]),
                        MeetingDate = Convert.ToDateTime(reader["MeetingDate"]),
                        StaffID = Convert.ToInt32(reader["StaffID"]),
                        StaffName = reader["StaffName"].ToString(),
                        IsPresent = Convert.ToBoolean(reader["IsPresent"]),
                        Remarks = reader["Remarks"] != DBNull.Value ? reader["Remarks"].ToString() : "",
                        Created = Convert.ToDateTime(reader["Created"]),
                        Modified = Convert.ToDateTime(reader["Modified"])
                    });
                }
                con.Close();
            }

            if (meetingId.HasValue)
            {
                members = members.Where(m => m.MeetingID == meetingId.Value).ToList();
            }

            ViewBag.MeetingMembers = members;
            ViewBag.FilterMeetingID = meetingId;
            return View();
        }

        public IActionResult MeetingMemberAddEdit(int? id)
        {
            LoadLookupData();
            MeetingMemberModel model = new MeetingMemberModel();

            if (id.HasValue)
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("MOM_MeetingMember_GetByID", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MeetingMemberID", id.Value);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        model.MeetingMemberID = Convert.ToInt32(reader["MeetingMemberID"]);
                        model.MeetingID = Convert.ToInt32(reader["MeetingID"]);
                        model.StaffID = Convert.ToInt32(reader["StaffID"]);
                        model.IsPresent = Convert.ToBoolean(reader["IsPresent"]);
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
        public IActionResult saveMeetingMember(MeetingMemberModel model)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    if (model.MeetingMemberID == 0)
                    {
                        cmd.CommandText = "MOM_MeetingMember_Insert";
                    }
                    else
                    {
                        cmd.CommandText = "MOM_MeetingMember_Update";
                        cmd.Parameters.AddWithValue("@MeetingMemberID", model.MeetingMemberID);
                    }

                    cmd.Parameters.AddWithValue("@MeetingID", model.MeetingID);
                    cmd.Parameters.AddWithValue("@StaffID", model.StaffID);
                    cmd.Parameters.AddWithValue("@IsPresent", model.IsPresent);
                    cmd.Parameters.AddWithValue("@Remarks", model.Remarks ?? (object)DBNull.Value);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                return RedirectToAction("MeetingMemberList");
            }
            LoadLookupData();
            return View("MeetingMemberAddEdit", model);
        }

        public IActionResult Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MOM_MeetingMember_Delete", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MeetingMemberID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return RedirectToAction("MeetingMemberList");
        }
    }
}
