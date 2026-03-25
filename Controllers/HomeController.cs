using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MOM_Project.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MOM_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            var model = new DashboardViewModel();
            string connString = _configuration.GetConnectionString("DefaultConnection");
            using (var sqlConnection = new SqlConnection(connString))
            using (var sqlCommand = sqlConnection.CreateCommand())
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "PR_MOM_Dashboard_Counts";
                sqlConnection.Open();
                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        model.TotalMeetings = reader.GetInt32(reader.GetOrdinal("TotalMeetings"));
                        model.TotalDepartments = reader.GetInt32(reader.GetOrdinal("TotalDepartments"));
                        model.TotalStaff = reader.GetInt32(reader.GetOrdinal("TotalStaff"));
                    }
                }
            }
            return View(model);
        }
    }
}
