using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;

namespace MOM_Project.Filters
{
    public class CheckAccess : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var endpoint = context.HttpContext.GetEndpoint();
            var allowAnonymous = endpoint?.Metadata.GetMetadata<AllowAnonymousAttribute>();

            // Skip if [AllowAnonymous]
            if (allowAnonymous != null)
                return;

            var userName = context.HttpContext.Session.GetString("UserName");

            // Check session
            if (string.IsNullOrEmpty(userName))
            {
                context.Result = new RedirectToActionResult("loginPage", "LoginSignup", null);
                return;
            }
        }
    }
}
