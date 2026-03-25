# Login Implementation Plan (Session-Based)

This guide documents the steps taken to implement a simple session-based authentication system into the `MOM_1` application, querying a stored procedure directly.

## 1. Configure Session in [Program.cs]
Register Session services to keep track of logged-in users. Add `builder.Services.AddSession(...)` and append the `app.UseSession()` middleware in the HTTP request pipeline.

## 2. Create the View Model
Create [Models/UserModel.cs](Models/UserModel.cs) to capture form inputs for `Username` and `Password`.

## 3. Implement Custom Access Filter
To secure all controllers globally without relying on `CookieAuthentication` and `AuthorizeFilter`, create a custom filter class [Filters/CheckAccess.cs] This class inherits from `ActionFilterAttribute` and overrides [OnActionExecuting] 
- It bypasses security if the endpoint has an `[AllowAnonymous]` attribute.
- For all other endpoints, if `HttpContext.Session.GetString("UserName") == null`, it intercepts the request and redirects to the [Login] page.
- Once created, apply it globally in [Program.cs] within `AddControllersWithViews(options => options.Filters.Add(new CheckAccess()))`.

## 4. Create the Controller
Create [Controllers/AuthController.cs], adorned with `[AllowAnonymous]` to exempt it from the global [CheckAccess] session check. It contains:
- [Login] (GET): Displays the login page. Redirects to `/Home/Index` if already logged in via session.
- [Login] (POST): Validates the username and password by querying the SQL Server User database. This involves opening an `SqlConnection` and calling your stored procedure `PR_MST_User_SelectForLogin`. If `reader.HasRows` evaluates to true, we issue a session using `HttpContext.Session.SetString("UserName", model.Username);`.
- [Logout]: Clears the session object variables completely (`HttpContext.Session.Clear()`) and relocates the user out to the login page.

## 5. Create the Login View
Create a clean [Login.cshtml] view inside `Views/Auth/`. Supply HTML mechanisms for `Username` and `Password` inputs alongside a robust submit button using your existing UI components (`NiceAdmin`).

## 6. Update Header Design
In `Views/Shared/_Header.cshtml`:
- Replaced the hardcoded 'Sign Out' href anchor link tag with a POST form that triggers the `AuthController`'s `Logout` route. 
- Integrated the `@using Microsoft.AspNetCore.Http` namespace.
- Handled profile data text outputs utilizing `@Context.Session.GetString("UserName")` to actively display the current user's actual username.
