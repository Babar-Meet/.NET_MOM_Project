using Microsoft.AspNetCore.Mvc;
using MOM_Project.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MOM_Project.Controllers
{
    public class MeetingVenueController : Controller
    {
        private readonly IConfiguration _configuration;

        public MeetingVenueController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection") ?? "";
        }

        public IActionResult MeetingVenueList()
        {
            List<MeetingVenueModel> venues = new List<MeetingVenueModel>();

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MOM_MeetingVenue_GetAll", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    venues.Add(new MeetingVenueModel
                    {
                        MeetingVenueID = Convert.ToInt32(reader["MeetingVenueID"]),
                        MeetingVenueName = reader["MeetingVenueName"].ToString(),
                        Created = Convert.ToDateTime(reader["Created"]),
                        Modified = Convert.ToDateTime(reader["Modified"])
                    });
                }
                con.Close();
            }

            ViewBag.MeetingVenues = venues;
            return View();
        }

        public IActionResult MeetingVenueAddEdit(int? id)
        {
            MeetingVenueModel model = new MeetingVenueModel();

            if (id.HasValue)
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("MOM_MeetingVenue_GetByID", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MeetingVenueID", id.Value);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        model.MeetingVenueID = Convert.ToInt32(reader["MeetingVenueID"]);
                        model.MeetingVenueName = reader["MeetingVenueName"].ToString();
                        model.Created = Convert.ToDateTime(reader["Created"]);
                        model.Modified = Convert.ToDateTime(reader["Modified"]);
                    }
                    con.Close();
                }
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult saveMeetingVenue(MeetingVenueModel model)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    if (model.MeetingVenueID == 0)
                    {
                        cmd.CommandText = "MOM_MeetingVenue_Insert";
                    }
                    else
                    {
                        cmd.CommandText = "MOM_MeetingVenue_Update";
                        cmd.Parameters.AddWithValue("@MeetingVenueID", model.MeetingVenueID);
                    }

                    cmd.Parameters.AddWithValue("@MeetingVenueName", model.MeetingVenueName);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                return RedirectToAction("MeetingVenueList");
            }
            return View("MeetingVenueAddEdit", model);
        }

        public IActionResult Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MOM_MeetingVenue_Delete", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MeetingVenueID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return RedirectToAction("MeetingVenueList");
        }
    }
}