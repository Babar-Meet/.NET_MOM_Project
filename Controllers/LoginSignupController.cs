using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using MOM_Project.Models;
using System.Data;

namespace MOM_Project.Controllers
{
    [AllowAnonymous]
    public class LoginSignupController : Controller
    {
        private readonly IConfiguration _configuration;

        public LoginSignupController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult loginPage()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                return RedirectToAction("Dashboard", "Home");
            }
            return View(new UserModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult loginPage(UserModel model)
        {
            // Since we're adding UserModel but view might not use it yet, we just check manually or by model binding.
            if (model != null && !string.IsNullOrEmpty(model.Username) && !string.IsNullOrEmpty(model.Password))
            {
                string sqlConnString = _configuration.GetConnectionString("DefaultConnection");
                bool isValidUser = false;

                using (var sqlConnection = new SqlConnection(sqlConnString))
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "PR_MOM_User_SelectForLogin";
                    sqlCommand.Parameters.AddWithValue("@Username", model.Username);
                    sqlCommand.Parameters.AddWithValue("@Password", model.Password);

                    sqlConnection.Open();
                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            isValidUser = true;
                        }
                    }
                }

                if (isValidUser)
                {
                    HttpContext.Session.SetString("UserName", model.Username);
                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            return View(model ?? new UserModel());
        }

        public IActionResult SignupPage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("loginPage");
        }
    }
}
