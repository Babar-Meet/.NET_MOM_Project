# MOM Project - Meeting Organization Management System
## Complete Technical Documentation for Beginners

---

# Table of Contents
1. [Introduction](#introduction)
2. [Architecture Overview](#architecture-overview)
3. [Project Structure](#project-structure)
4. [Client-Side vs Server-Side Operations](#client-side-vs-server-side-operations)
5. [Detailed File Explanations](#detailed-file-explanations)
6. [Session Management](#session-management)
7. [Request Validation Flow](#request-validation-flow)
8. [Authentication and Authorization](#authentication-and-authorization)
9. [Data Flow Diagrams](#data-flow-diagrams)
10. [API Endpoints Reference](#api-endpoints-reference)
11. [Input/Output Specifications](#inputoutput-specifications)
12. [Error Handling](#error-handling)
13. [Dependencies and Their Purposes](#dependencies-and-their-purposes)
14. [Configuration Explanations](#configuration-explanations)
15. [Quick Reference](#quick-reference)

---

# 1. Introduction

## What is this Project?
This is a **Meeting Organization Management (MOM)** web application built with **ASP.NET Core MVC**. Think of it like a digital organizer that helps companies manage their meetings - who attends, where they happen, what type they are, and which department they belong to.

**Analogy**: Imagine a digital whiteboard in an office where you can:
- Schedule meetings (like writing appointments on a calendar)
- Track who attends (like a sign-in sheet)
- Manage meeting rooms (like a room booking system)
- Keep staff directories (like a company phonebook)

That's exactly what this application does!

---

# 2. Architecture Overview

## How the Application Flows (Client → Server → Database → Back)

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                            USER'S BROWSER                                   │
│  ┌─────────────┐    ┌─────────────┐    ┌─────────────┐    ┌─────────────┐  │
│  │   Login     │    │   Dashboard │    │   Meeting  │    │    Staff    │  │
│  │   Page      │    │   Page      │    │   Pages    │    │   Pages     │  │
│  └──────┬──────┘    └──────┬──────┘    └──────┬──────┘    └──────┬──────┘  │
│         │                  │                  │                  │         │
└─────────┼──────────────────┼──────────────────┼──────────────────┼─────────┘
          │                  │                  │                  │
          ▼                  ▼                  ▼                  ▼
┌─────────────────────────────────────────────────────────────────────────────┐
│                        ASP.NET CORE MVC FRAMEWORK                          │
│  ┌─────────────────────────────────────────────────────────────────────┐   │
│  │                     CONTROLLERS (Traffic Controllers)               │   │
│  │  ┌─────────┐ ┌─────────┐ ┌─────────┐ ┌─────────┐ ┌─────────┐      │   │
│  │  │ Login   │ │  Home   │ │Meeting  │ │ Dept    │ │ Staff   │      │   │
│  │  │Signup   │ │         │ │Control  │ │Control  │ │Control  │      │   │
│  │  └────┬────┘ └────┬────┘ └────┬────┘ └────┬────┘ └────┬────┘      │   │
│  └───────┼───────────┼───────────┼───────────┼───────────┼───────────┘   │
│          │           │           │           │           │               │
│          ▼           ▼           ▼           ▼           ▼               │
│  ┌─────────────────────────────────────────────────────────────────────┐   │
│  │                      MODELS (Data Containers)                      │   │
│  │  ┌─────────┐ ┌─────────┐ ┌─────────┐ ┌─────────┐ ┌─────────┐      │   │
│  │  │ User    │ │ Meeting │ │Department│ │  Staff  │ │ Venue   │      │   │
│  │  │Model    │ │  Model  │ │  Model  │ │  Model  │ │  Model  │      │   │
│  │  └─────────┘ └─────────┘ └─────────┘ └─────────┘ └─────────┘      │   │
│  └─────────────────────────────────────────────────────────────────────┘   │
│          │                                                                  │
│          ▼                                                                  │
│  ┌─────────────────────────────────────────────────────────────────────┐   │
│  │                   FILTERS (Security Guards)                         │   │
│  │                    CheckAccess Filter                               │   │
│  └─────────────────────────────────────────────────────────────────────┘   │
│          │                                                                  │
│          ▼                                                                  │
└──────────┼───────────────────────────────────────────────────────────────┘
           │
           ▼
┌─────────────────────────────────────────────────────────────────────────────┐
│                      SQL SERVER DATABASE                                   │
│  ┌────────────────┐  ┌────────────────┐  ┌────────────────┐                │
│  │  Stored        │  │    Tables      │  │   Views        │                │
│  │  Procedures    │  │   (Data)       │  │ (Readymade     │                │
│  │                 │  │                │  │  Queries)      │                │
│  └────────────────┘  └────────────────┘  └────────────────┘                │
└─────────────────────────────────────────────────────────────────────────────┘
```

## Simple Flow Explanation

1. **User Action**: User clicks a button or fills a form in their browser
2. **Controller Receives Request**: ASP.NET routes the request to the appropriate Controller
3. **Controller Processes**: Controller talks to the Model to prepare data
4. **Model Interacts with Database**: Model uses SQL to talk to SQL Server
5. **Database Returns Data**: SQL Server sends back the information
6. **Controller Creates View**: Controller combines data with HTML (Razor View)
7. **Browser Displays**: The final webpage is shown to the user

---

# 3. Project Structure

## File and Folder Organization

```
MOM_Project/
├── 📄 Program.cs                    # Application entry point (starting point)
├── 📄 appsettings.json              # Configuration settings (database, logging)
├── 📄 MOM_Project.csproj           # Project file (dependencies, settings)
├── 📄 MOM_Project.slnx             # Solution file (Visual Studio stuff)
│
├── 📁 Controllers/                  # 🚗 Traffic controllers - handle requests
│   ├── HomeController.cs           # Dashboard and homepage
│   ├── LoginSignupController.cs    # 🔐 Login and signup
│   ├── MeetingsController.cs       # 📅 Meeting management
│   ├── DepartmentController.cs    # 🏢 Department management
│   ├── MeetingTypeController.cs    # 📋 Types of meetings
│   ├── MeetingVenueController.cs   # 📍 Where meetings happen
│   ├── MeetingMemberController.cs # 👥 Who attends meetings
│   └── StaffController.cs          # 👨‍💼 Staff/employee management
│
├── 📁 Models/                      # 📦 Data containers
│   ├── UserModel.cs                # Login information
│   ├── MeetingsModel.cs            # Meeting details
│   ├── DepartmentModel.cs         # Department info
│   ├── MeetingTypeModel.cs        # Meeting type info
│   ├── MeetingVenueModel.cs       # Venue/location info
│   ├── MeetingMemberModel.cs      # Meeting attendee info
│   ├── StaffModel.cs              # Employee details
│   ├── DashboardViewModel.cs      # Dashboard statistics
│   └── ErrorViewModel.cs          # Error display
│
├── 📁 Views/                       # 🎨 HTML pages (what user sees)
│   └── [ControllerName]/           # Views for each controller
│       └── *.cshtml                # Razor HTML files
│
├── 📁 Filters/                     # 🔒 Security guards
│   └── CheckAccess.cs              # Session checking filter
│
└── 📁 bin/                         # Compiled code (ready to run)
```

---

# 4. Client-Side vs Server-Side Operations

## Client-Side (Browser) - What Happens on Your Computer

| Operation | Description | Example |
|-----------|-------------|---------|
| **HTML Rendering** | Displaying the webpage | Showing buttons, tables, forms |
| **JavaScript** | Interactive features | Search filtering, modal popups |
| **CSS Styling** | Visual appearance | Colors, fonts, layout |
| **Form Submission** | Sending data to server | Clicking "Save" button |
| **Session Cookies** | Remembering login | Keeping you logged in |

**In this project**: The client-side code is mostly in `.cshtml` files (Razor Views). For example, in `MeetingList.cshtml`:
- The search box uses JavaScript to filter the table
- Modal dialogs show meeting details
- Action buttons navigate between pages

## Server-Side (ASP.NET Core) - What Happens on the Server

| Operation | Description | Example |
|-----------|-------------|---------|
| **Controller Logic** | Processing requests | Deciding what to do with a login |
| **Database Operations** | Reading/writing data | Saving a new meeting to database |
| **Model Validation** | Checking input | Ensuring date is not empty |
| **Session Management** | Tracking users | Checking if you're logged in |
| **Authorization** | Security checks | Blocking unauthorized access |

**In this project**: All Controllers handle server-side operations:
- Reading from SQL Server
- Validating form data
- Creating sessions
- Returning views to browser

---

# 5. Detailed File Explanations

## 5.1 Program.cs - The Application Starting Point

**File**: `Program.cs`

**Purpose**: This is where the application begins. Think of it as the "front door" of the application.

**What It Does**:
1. Creates the web application
2. Sets up services (database, sessions, security)
3. Configures the request pipeline (how requests flow through the app)
4. Defines default route (which page opens first)

```csharp
// Line 1: Create the web application builder
var builder = WebApplication.CreateBuilder(args);

// Line 4-7: Add MVC controllers and views
// This tells ASP.NET we'll use Controllers and Views (not minimal APIs)
builder.Services.AddControllersWithViews(options => 
{
    // Add our custom security filter to every request
    options.Filters.Add(new MOM_Project.Filters.CheckAccess());
});

// Line 10: Make configuration available throughout the app
// This allows reading appsettings.json from anywhere
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// Line 13-19: Set up session management
// Session = remembering user data between page visits
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // 30 min timeout
    options.Cookie.HttpOnly = true;  // Security: can't be accessed by JavaScript
    options.Cookie.IsEssential = true;  // Required for app to work
});
builder.Services.AddHttpContextAccessor();

// Line 22: Build the application
var app = builder.Build();

// Line 25-27: Error handling in production (not development)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Line 29: Enable routing (deciding which controller handles which URL)
app.UseRouting();

// Line 31: Enable session (so we can remember users)
app.UseSession();

// Line 33: Enable authorization (security checks)
app.UseAuthorization();

// Line 35: Enable serving static files (CSS, JavaScript, images)
app.MapStaticAssets();

// Line 37-40: Define the default route
// If user visits root URL, go to LoginSignup controller, loginPage action
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LoginSignup}/{action=loginPage}/{id?}")
    .WithStaticAssets();

// Line 43: Start the application
app.Run();
```

**Parameters**: None (uses command-line arguments for configuration)

**Returns**: Nothing (void - starts the web server)

**Why It Exists**: Every web application needs a starting point. This file sets up everything needed for the app to work.

---

## 5.2 appsettings.json - Configuration

**File**: `appsettings.json`

**Purpose**: Stores settings that configure how the application behaves. Think of it as the "settings" or "preferences" of the app.

**Content Explanation**:
```json
{
  // Logging configuration - what information gets written to logs
  "Logging": {
    "LogLevel": {
      "Default": "Information",  // Normal messages
      "Microsoft.AspNetCore": "Warning"  // Only warnings, not every detail
    }
  },
  
  // Which hosts can run this application (* = all)
  "AllowedHosts": "*",
  
  // Database connection strings - how to connect to SQL Server
  "ConnectionStrings": {
    // Server = computer name (Meet\SQLEXPRESS = local SQL Server)
    // Database = MOM_Meet (the database name)
    // Trusted_Connection = use Windows authentication
    // TrustServerCertificate = allow self-signed certificates
    "DefaultConnection": "Server=Meet\\SQLEXPRESS;Database=MOM_Meet;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

**Simple Analogy**: This is like the "Settings" app on your phone - it contains preferences that the app reads to know how to behave.

---

## 5.3 Controllers

### 5.3.1 LoginSignupController.cs - Authentication

**File**: `Controllers/LoginSignupController.cs`

**Purpose**: Handles user login and logout. This is the "gatekeeper" that decides who can enter the application.

**Class Properties**:
- `_configuration` - Access to settings (database connection string)

**Methods**:

#### loginPage() [HttpGet]
- **Purpose**: Show the login form to user
- **What it does**: 
  - Checks if user already logged in (session exists)
  - If logged in, redirect to Dashboard
  - If not logged in, show login form
- **Input**: None
- **Output**: Login form view (Razor page)

```csharp
[HttpGet]
public IActionResult loginPage()
{
    // Check if session has username (user is logged in)
    if (HttpContext.Session.GetString("UserName") != null)
    {
        // Already logged in - go to dashboard
        return RedirectToAction("Dashboard", "Home");
    }
    // Not logged in - show login form with empty UserModel
    return View(new UserModel());
}
```

#### loginPage(UserModel model) [HttpPost]
- **Purpose**: Process the login form submission
- **What it does**:
  - Validates username and password are provided
  - Calls stored procedure to check credentials in database
  - If valid, creates session and redirects to Dashboard
  - If invalid, shows error message
- **Input**: UserModel with Username and Password
- **Output**: Redirect to Dashboard or login form with error
- **Security**: Uses ValidateAntiForgeryToken to prevent CSRF attacks

```csharp
[HttpPost]
[ValidateAntiForgeryToken]  // Security: prevents cross-site request forgery
public IActionResult loginPage(UserModel model)
{
    // Check if username and password were provided
    if (model != null && !string.IsNullOrEmpty(model.Username) && !string.IsNullOrEmpty(model.Password))
    {
        string sqlConnString = _configuration.GetConnectionString("DefaultConnection");
        bool isValidUser = false;

        // Check database for matching username/password
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
                // If we found a matching user, login is valid
                if (reader.HasRows)
                {
                    isValidUser = true;
                }
            }
        }

        if (isValidUser)
        {
            // Create session - remember user is logged in
            HttpContext.Session.SetString("UserName", model.Username);
            return RedirectToAction("Dashboard", "Home");
        }
        else
        {
            // Show error message
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }
    }
    return View(model ?? new UserModel());
}
```

#### Logout()
- **Purpose**: End user session and redirect to login
- **What it does**: Clears all session data and redirects to login page
- **Input**: None
- **Output**: Redirect to login page

---

### 5.3.2 HomeController.cs - Dashboard

**File**: `Controllers/HomeController.cs`

**Purpose**: Shows the main dashboard with summary statistics.

**Class Properties**:
- `_configuration` - Access to database connection

**Methods**:

#### Index()
- **Purpose**: Default action (redirects to Dashboard)
- **Input**: None
- **Output**: Redirects to Dashboard action

#### Dashboard()
- **Purpose**: Show statistics about the system
- **What it does**: 
  - Calls stored procedure to get counts
  - Returns count of meetings, departments, and staff
- **Input**: None
- **Output**: Dashboard view with DashboardViewModel

```csharp
public IActionResult Dashboard()
{
    var model = new DashboardViewModel();  // Create empty model
    string connString = _configuration.GetConnectionString("DefaultConnection");
    
    // Connect to database and run stored procedure
    using (var sqlConnection = new SqlConnection(connString))
    using (var sqlCommand = sqlConnection.CreateCommand())
    {
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.CommandText = "PR_MOM_Dashboard_Counts";
        
        sqlConnection.Open();
        using (var reader = sqlCommand.ExecuteReader())
        {
            if (reader.Read())  // Read the row of counts
            {
                model.TotalMeetings = reader.GetInt32(reader.GetOrdinal("TotalMeetings"));
                model.TotalDepartments = reader.GetInt32(reader.GetOrdinal("TotalDepartments"));
                model.TotalStaff = reader.GetInt32(reader.GetOrdinal("TotalStaff"));
            }
        }
    }
    return View(model);  // Send to view
}
```

---

### 5.3.3 MeetingsController.cs - Meeting Management

**File**: `Controllers/MeetingsController.cs`

**Purpose**: CRUD operations for meetings (Create, Read, Update, Delete).

**Class Properties**:
- `_configuration` - Access to database connection

**Private Methods**:

#### GetConnectionString()
- **Purpose**: Get database connection string
- **Input**: None
- **Output**: String (connection string)

#### LoadLookupData()
- **Purpose**: Load dropdown options for forms (venues, types, departments)
- **What it does**: Queries all venues, types, and departments to populate ViewBag
- **Input**: None
- **Output**: Populates ViewBag.Venues, ViewBag.MeetingTypes, ViewBag.Departments

**Public Methods**:

#### MeetingList()
- **Purpose**: Display all meetings in a table
- **What it does**:
  - Gets all meetings from database
  - Gets all meeting members and calculates attendance stats
  - Attaches member counts to each meeting
- **Input**: None
- **Output**: MeetingList view with meetings list

**Key Logic**: 
- First queries all meetings
- Then queries all meeting members
- Groups members by meeting and counts present/absent
- Assigns totals to each meeting object

#### MeetingAddEdit(int? id)
- **Purpose**: Show form for adding or editing a meeting
- **What it does**:
  - Loads dropdown options (venues, types, departments)
  - If id provided, fetches existing meeting for editing
  - If no id, shows empty form for new meeting
- **Input**: Optional id (null for new, number for edit)
- **Output**: MeetingAddEdit view with MeetingsModel

#### saveMeeting(MeetingsModel model)
- **Purpose**: Save meeting (insert or update)
- **What it does**:
  - Validates model (checks required fields)
  - If MeetingID == 0, calls INSERT stored procedure
  - If MeetingID != 0, calls UPDATE stored procedure
  - Redirects to MeetingList on success
  - Reloads form on validation failure
- **Input**: MeetingsModel from form
- **Output**: Redirect to MeetingList or back to form

#### Delete(int id)
- **Purpose**: Remove a meeting
- **What it does**: Calls DELETE stored procedure with meeting ID
- **Input**: Meeting ID
- **Output**: Redirect to MeetingList

---

### 5.3.4 DepartmentController.cs - Department Management

**File**: `Controllers/DepartmentController.cs`

**Purpose**: Manage departments ( organizational units).

**Structure**: Similar pattern to MeetingsController
- DepartmentList() - Show all departments
- DepartmentAddEdit(int? id) - Form for add/edit
- saveDept(DepartmentModel model) - Save department
- Delete(int id) - Remove department

---

### 5.3.5 MeetingTypeController.cs - Meeting Types

**File**: `Controllers/MeetingTypeController.cs`

**Purpose**: Manage types/categories of meetings (e.g., "Weekly Standup", "Project Review", "Town Hall").

**Structure**: Similar CRUD pattern as DepartmentController

---

### 5.3.6 MeetingVenueController.cs - Meeting Venues

**File**: `Controllers/MeetingVenueController.cs`

**Purpose**: Manage physical or virtual meeting locations.

**Structure**: Similar CRUD pattern

---

### 5.3.7 MeetingMemberController.cs - Attendance Tracking

**File**: `Controllers/MeetingMemberController.cs`

**Purpose**: Track which staff members attend which meetings and their attendance status.

**Special Features**:
- Can filter members by meeting ID
- Tracks if member was present/absent
- Can add remarks about attendance

---

### 5.3.8 StaffController.cs - Staff Management

**File**: `Controllers/StaffController.cs`

**Purpose**: Manage employees/staff members and their assignments to departments.

**Features**:
- Staff directory with contact information
- Links to departments
- CRUD operations

---

## 5.4 Models (Data Containers)

### 5.4.1 UserModel.cs
```csharp
public class UserModel
{
    public string Username { get; set; }    // Login name
    public string Password { get; set; }    // Login password
}
```
**Purpose**: Holds login credentials for authentication.

---

### 5.4.2 MeetingsModel.cs
```csharp
public class MeetingsModel
{
    [Key]                                    // Primary key in database
    public int MeetingID { get; set; }       // Unique ID
    
    [Required]                               // Must be provided
    public DateTime MeetingDate { get; set; }  // When meeting happens
    
    [Required]
    public int MeetingVenueID { get; set; }  // Where (link to Venue table)
    
    [Required]
    public int MeetingTypeID { get; set; }   // What type (link to Type table)
    
    [Required]
    public int DepartmentID { get; set; }    // Which department (link to Dept table)
    
    // These are populated from JOIN queries (read-only display)
    public string? MeetingVenueName { get; set; }
    public string? MeetingTypeName { get; set; }
    public string? DepartmentName { get; set; }
    
    [MaxLength(250)]
    public string? MeetingDescription { get; set; }  // What it's about
    
    [MaxLength(250)]
    public string? DocumentPath { get; set; }  // File attachment path
    
    public DateTime Created { get; set; }    // When record was created
    public DateTime Modified { get; set; }    // Last modification time
    
    public bool IsCancelled { get; set; }     // Is meeting cancelled?
    public DateTime? CancellationDateTime { get; set; }
    public string? CancellationReason { get; set; }
    
    // Computed properties (calculated in code, not stored in DB)
    public int TotalMembers { get; set; }
    public int PresentMembers { get; set; }
    public int AbsentMembers { get; set; }
}
```

---

### 5.4.3 DepartmentModel.cs
```csharp
public class DepartmentModel
{
    [Key]
    public int DepartmentID { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 2)]  // 2-100 characters
    public string DepartmentName { get; set; }
    
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}
```

---

### 5.4.4 StaffModel.cs
```csharp
public class StaffModel
{
    [Key]
    public int StaffID { get; set; }
    
    [Required]
    public int DepartmentID { get; set; }   // Link to department
    
    public string? DepartmentName { get; set; }  // From JOIN
    
    [Required]
    [MaxLength(50)]
    public string StaffName { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string MobileNo { get; set; }
    
    [Required]
    [MaxLength(50)]
    [EmailAddress]  // Validates email format
    public string EmailAddress { get; set; }
    
    [MaxLength(250)]
    public string? Remarks { get; set; }
    
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}
```

---

### 5.4.5 MeetingMemberModel.cs
```csharp
public class MeetingMemberModel
{
    [Key]
    public int MeetingMemberID { get; set; }
    
    [Required]
    public int MeetingID { get; set; }   // Which meeting
    
    [Required]
    public int StaffID { get; set; }     // Which staff member
    
    // Display properties from JOIN
    public string? StaffName { get; set; }
    public DateTime? MeetingDate { get; set; }
    
    public bool IsPresent { get; set; }   // Did they attend?
    
    [MaxLength(250)]
    public string? Remarks { get; set; }
    
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}
```

---

### 5.4.6 DashboardViewModel.cs
```csharp
public class DashboardViewModel
{
    public int TotalMeetings { get; set; }      // Count of all meetings
    public int TotalDepartments { get; set; }   // Count of all departments
    public int TotalStaff { get; set; }         // Count of all staff
}
```
**Purpose**: Holds aggregated statistics for the dashboard.

---

## 5.5 Filters - Security

### CheckAccess.cs
**File**: `Filters/CheckAccess.cs`

**Purpose**: Security guard that checks if user is logged in before allowing access to any page.

**How It Works**:
```csharp
public class CheckAccess : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Check if the endpoint allows anonymous access (like login page)
        var endpoint = context.HttpContext.GetEndpoint();
        var allowAnonymous = endpoint?.Metadata.GetMetadata<AllowAnonymousAttribute>();
        
        // If [AllowAnonymous] is present, skip this check
        if (allowAnonymous != null)
            return;
        
        // Check if user session exists (is user logged in?)
        var userName = context.HttpContext.Session.GetString("UserName");
        
        // If no session, redirect to login page
        if (string.IsNullOrEmpty(userName))
        {
            context.Result = new RedirectToActionResult("loginPage", "LoginSignup", null);
            return;
        }
    }
}
```

**Important**: This filter is added to ALL controllers in `Program.cs`, so every page requires login except those marked with `[AllowAnonymous]`.

---

## 5.6 Views (Razor Pages)

### MeetingList.cshtml - Example View
**File**: `Views/Meetings/MeetingList.cshtml`

**Purpose**: Display list of meetings in a searchable table with modal details.

**Components**:
1. **Header**: Title and "Add" button
2. **Search Input**: Filters table in real-time (JavaScript)
3. **Table**: Shows all meetings with columns (ID, Date, Venue, Type, Department, Status, Actions)
4. **Modal Popup**: Shows detailed meeting information when "View" clicked

**Key Features**:
- Client-side search filtering
- Dynamic status badges (Cancelled/Completed/Upcoming)
- Modal for viewing details without leaving page

---

# 6. Session Management

## How Sessions Work in This Application

### What is a Session?
A session is like a temporary ID card that proves you're logged in. It keeps you logged in as you move between pages.

### Session Lifecycle:

```
┌─────────────────────────────────────────────────────────────────┐
│                    SESSION LIFECYCLE                            │
├─────────────────────────────────────────────────────────────────┤
│                                                                 │
│  1. USER LOGS IN                                                │
│     ┌─────────────────┐                                        │
│     │ Enters username │                                        │
│     │ and password    │                                        │
│     └────────┬────────┘                                        │
│              ▼                                                  │
│  2. SERVER VERIFIES                                             │
│     ┌─────────────────┐                                        │
│     │ Checks database │                                        │
│     │ for valid user  │                                        │
│     └────────┬────────┘                                        │
│              ▼                                                  │
│  3. SESSION CREATED                                             │
│     ┌─────────────────┐                                        │
│     │ Server stores   │──────▶ Session["UserName"] = "John"   │
│     │ UserName in     │         (stored in memory)            │
│     │ session         │                                        │
│     └────────┬────────┘                                        │
│              ▼                                                  │
│  4. BROWSER COOKIE                                             │
│     ┌─────────────────┐                                        │
│     │ Browser gets    │──────▶ Session ID sent with every     │
│     │ Session ID      │         request                       │
│     └────────┬────────┘                                        │
│              ▼                                                  │
│  5. SUBSEQUENT REQUESTS                                         │
│     ┌─────────────────┐                                        │
│     │ Every request   │──────▶ Server looks up session by ID  │
│     │ includes cookie │         Gets UserName, validates     │
│     └────────┬────────┘                                        │
│              ▼                                                  │
│  6. SESSION EXPIRES                                             │
│     ┌─────────────────┐                                        │
│     │ After 30 min    │──────▶ User redirected to login       │
│     │ of inactivity   │         (CheckAccess filter catches)  │
│     └─────────────────┘                                        │
│                                                                 │
└─────────────────────────────────────────────────────────────────┘
```

### Session Configuration in Program.cs:
```csharp
// Configure session
builder.Services.AddDistributedMemoryCache();  // Store sessions in memory
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // 30 min timeout
    options.Cookie.HttpOnly = true;  // Can't be read by JavaScript (security)
    options.Cookie.IsEssential = true;  // Required cookie
});
```

### Checking Session (in Controllers):
```csharp
// Check if user is logged in
if (HttpContext.Session.GetString("UserName") != null)
{
    // User is logged in - allow access
}

// Create session
HttpContext.Session.SetString("UserName", "John");

// Clear session (logout)
HttpContext.Session.Clear();
```

### Session Termination:
- **Logout**: User clicks logout → Session.Clear() called
- **Timeout**: 30 minutes of inactivity → Session expires
- **Browser Close**: Cookie may be deleted

---

# 7. Request Validation Flow

## How Every Request Gets Validated

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                        REQUEST VALIDATION FLOW                             │
├─────────────────────────────────────────────────────────────────────────────┤
│                                                                             │
│  USER'S BROWSER                                                             │
│       │                                                                     │
│       ▼                                                                     │
│  ┌─────────────────────────────────────────────────────────────────────┐   │
│  │ 1. USER SUBMITS REQUEST (clicks link, button, or form)              │   │
│  └─────────────────────────────────────────────────────────────────────┘   │
│                                    │                                       │
│                                    ▼                                       │
│  ┌─────────────────────────────────────────────────────────────────────┐   │
│  │ 2. ROUTING - ASP.NET decides which Controller/Action handles it    │   │
│  │    URL: /Meetings/MeetingList  →  MeetingsController.MeetingList()  │   │
│  └─────────────────────────────────────────────────────────────────────┘   │
│                                    │                                       │
│                                    ▼                                       │
│  ┌─────────────────────────────────────────────────────────────────────┐   │
│  │ 3. CHECKACCESS FILTER (Security Guard)                              │   │
│  │    ┌──────────────────────────────────────────────────────────┐    │   │
│  │    │ • Is user logged in? (Session has UserName?)              │    │   │
│  │    │ • Is this endpoint allow anonymous? ([AllowAnonymous])    │    │   │
│  │    │                                                                │    │
│  │    │ YES: Continue to controller                                  │    │
│  │    │ NO: Redirect to loginPage                                    │    │   │
│  │    └──────────────────────────────────────────────────────────┘    │   │
│  └─────────────────────────────────────────────────────────────────────┘   │
│                                    │                                       │
│                                    ▼                                       │
│  ┌─────────────────────────────────────────────────────────────────────┐   │
│  │ 4. CONTROLLER ACTION EXECUTES                                      │   │
│  │    ┌──────────────────────────────────────────────────────────┐    │   │
│  │    │ • For POST: Model Binding (extract form data to Model)    │    │   │
│  │    │ • For POST: ModelState.IsValid (validation attributes)   │    │   │
│  │    │ • For POST: ValidateAntiForgeryToken (CSRF protection)   │    │   │
│  │    │                                                                │    │
│  │    │ Valid: Continue with processing                              │    │   │
│  │    │ Invalid: Return form with validation errors                 │    │   │
│  │    └──────────────────────────────────────────────────────────┘    │   │
│  └─────────────────────────────────────────────────────────────────────┘   │
│                                    │                                       │
│                                    ▼                                       │
│  ┌─────────────────────────────────────────────────────────────────────┐   │
│  │ 5. DATABASE OPERATION (if applicable)                              │   │
│  │    ┌──────────────────────────────────────────────────────────┐    │   │
│  │    │ • Open SQL connection                                     │    │   │
│  │    │ • Execute stored procedure with parameters              │    │   │
│  │    │ • Handle SQL exceptions                                  │    │   │
│  │    │ • Close connection                                       │    │   │
│  │    └──────────────────────────────────────────────────────────┘    │   │
│  └─────────────────────────────────────────────────────────────────────┘   │
│                                    │                                       │
│                                    ▼                                       │
│  ┌─────────────────────────────────────────────────────────────────────┐   │
│  │ 6. VIEW GENERATION                                                 │   │
│  │    ┌──────────────────────────────────────────────────────────┐    │   │
│  │    │ • Controller creates ViewResult with Model              │    │   │
│  │    │ • Razor engine combines HTML template + Model data      │    │   │
│  │    │ • HTML sent back to browser                              │    │   │
│  │    └──────────────────────────────────────────────────────────┘    │   │
│  └─────────────────────────────────────────────────────────────────────┘   │
│                                                                             │
└─────────────────────────────────────────────────────────────────────────────┘
```

### Validation at Each Level:

| Level | Validation Type | What It Checks |
|-------|-----------------|----------------|
| **CheckAccess Filter** | Session Check | Is user logged in? |
| **Model Binding** | Data Extraction | Did form data map correctly? |
| **ModelState** | Data Annotations | Are required fields present? Are values valid format? |
| **AntiForgeryToken** | CSRF Protection | Is this a legitimate form submission? |
| **Stored Procedures** | SQL Validation | Are parameters safe? (prevents SQL injection) |

---

# 8. Authentication and Authorization

## Authentication (WHO are you?)

**Definition**: Verifying that the user is who they claim to be (login process).

**In This Project**:
1. User enters username and password
2. System calls stored procedure `PR_MOM_User_SelectForLogin`
3. If credentials match database, session is created
4. Session stores `UserName` for subsequent requests

**Simple Analogy**: Authentication is like showing your ID card to enter a building - it proves who you are.

---

## Authorization (WHAT can you do?)

**Definition**: Checking if the authenticated user has permission to access a resource.

**In This Project**:
1. **CheckAccess Filter** runs on every request
2. Checks if session has `UserName`
3. If session exists → Allow access
4. If no session → Redirect to login

**Note**: This is a simple "all or nothing" authorization. The application doesn't have role-based access (like admin vs regular user).

**Simple Analogy**: Authorization is like checking your badge to enter different floors - it determines what you can access.

---

## Security Features Implemented:

| Feature | Implementation | Purpose |
|---------|----------------|---------|
| **Session-based Auth** | HttpContext.Session | Track logged-in users |
| **Password Storage** | Stored Procedure | Database handles password verification |
| **CSRF Protection** | ValidateAntiForgeryToken | Prevents cross-site request forgery |
| **Session Timeout** | 30-minute idle timeout | Auto-logout after inactivity |
| **HttpOnly Cookies** | Cookie.HttpOnly = true | Prevents JavaScript access to session |
| **Allow Anonymous** | [AllowAnonymous] attribute | Exempts certain pages from auth check |

---

# 9. Data Flow Diagrams

## 9.1 Login Flow

```
┌──────────┐     ┌──────────────────┐     ┌─────────────────┐     ┌────────────┐
│  User    │────▶│  LoginSignup     │────▶│  SQL Server     │     │  Session   │
│ enters   │     │  Controller     │     │  Database       │     │  Created   │
│ creds    │     └────────┬─────────┘     └────────┬────────┘     └─────┬──────┘
└──────────┘              │                         │                   │
                          │  Username/Password     │                   │
                          │  PR_MOM_User_Select    │                   │
                          │  _ForLogin             │                   │
                          ▼                         ▼                   ▼
                    ┌─────────────┐          ┌─────────┐         ┌──────────┐
                    │ Has Rows?   │          │ Valid   │         │ Redirect │
                    └──────┬──────┘          │ User    │         │ to Dash  │
                           │                  └────┬────┘         └──────────┘
                           │ No                      │ Yes
                           ▼                         ▼
                    ┌─────────────┐          ┌─────────────┐
                    │ Show Error  │          │ Set Session │
                    │ "Invalid   │          │ UserName    │
                    │  login"    │          └─────────────┘
                    └─────────────┘
```

## 9.2 Meeting Creation Flow

```
┌──────────┐     ┌──────────────────┐     ┌─────────────────┐     ┌────────────┐
│  User    │────▶│  MeetingAddEdit  │────▶│  saveMeeting    │     │  Database  │
│ fills    │     │  View (GET)     │     │  Action (POST)  │     │  Insert    │
│ form     │     └──────────────────┘     └────────┬────────┘     └─────┬──────┘
└──────────┘                                      │                    │
                                                     │ MeetingID==0      │
                                                     │ (New Meeting)    │
                                                     ▼                  ▼
                                               ┌─────────────┐    ┌────────────┐
                                               │ Execute     │    │ Insert     │
                                               │ MOM_Meetings│    │ New Record │
                                               │ _Insert     │    │            │
                                               └─────────────┘    └────────────┘
                                                      │
                                                      ▼
                                               ┌─────────────┐
                                               │ Redirect to │
                                               │ MeetingList │
                                               └─────────────┘
```

## 9.3 Dashboard Data Flow

```
┌─────────────┐     ┌──────────────────┐     ┌─────────────────┐
│  User       │────▶│  HomeController  │────▶│  SQL Server     │
│  visits     │     │  Dashboard()     │     │  Database       │
│  Dashboard  │     └────────┬─────────┘     └────────┬────────┘
└─────────────┘              │                         │
                            │                         │
                            ▼                         ▼
                      ┌─────────────┐          ┌─────────────┐
                      │ Create      │          │ Execute     │
                      │ Empty       │          │ PR_MOM_     │
                      │ Dashboard   │          │ Dashboard   │
                      │ ViewModel   │          │ _Counts     │
                      └─────────────┘          └──────┬──────┘
                                                       │
                                                       │ Returns 3 counts:
                                                       │ - TotalMeetings
                                                       │ - TotalDepartments
                                                       │ - TotalStaff
                                                       ▼
                                                 ┌─────────────┐
                                                 │ Populate    │
                                                 │ ViewModel   │
                                                 └──────┬──────┘
                                                        │
                                                        ▼
                                                 ┌─────────────┐
                                                 │ Return      │
                                                 │ View with   │
                                                 │ Model       │
                                                 └─────────────┘
```

## 9.4 Data Relationships

```
┌─────────────┐         ┌─────────────┐         ┌─────────────┐
│  Department │         │    Staff    │         │ Meeting    │
│             │◀────────│             │         │  Venue     │
│ DeptID (PK) │ 1    *  │ StaffID(PK) │         │ VenueID(PK)│
│ DeptName    │         │ DeptID(FK)  │         │ VenueName  │
└─────────────┘         └─────────────┘         └─────────────┘
         │                      │                      │
         │                      │                      │
         ▼                      ▼                      ▼
┌─────────────────────────────────────────────────────────────────┐
│                         MEETINGS                                │
│                                                                  │
│ MeetingID (PK)      MeetingVenueID (FK) ──────────────────────│
│ MeetingDate         MeetingTypeID (FK)  ──────────────────────│
│ DepartmentID (FK)   Created/Modified                           │
│ Description                                                     │
└─────────────────────────────┬───────────────────────────────────┘
                              │
                              │
                              ▼
┌─────────────────────────────────────────────────────────────────┐
│                      MEETING_MEMBERS                            │
│                                                                  │
│ MeetingMemberID (PK)    MeetingID (FK) ────────┐               │
│ StaffID (FK) ──────────►                        │               │
│ IsPresent                                     *               │
│ Remarks                                        │               │
│ Created/Modified                               │               │
└────────────────────────────────────────────────┘───────────────┘

Legend:
 PK = Primary Key (unique identifier)
 FK = Foreign Key (link to another table)
 1    * = One-to-Many relationship
```

---

# 10. API Endpoints Reference

## How to Read This Table

- **URL Pattern**: The address user visits
- **HTTP Method**: GET (view data) or POST (submit data)
- **Controller.Action**: Which method handles it

| URL Pattern | Method | Controller.Action | Purpose |
|-------------|--------|-------------------|---------|
| `/` | GET | LoginSignup.loginPage | Show login form |
| `/LoginSignup/loginPage` | POST | LoginSignup.loginPage | Process login |
| `/LoginSignup/Logout` | POST | LoginSignup.Logout | Log out user |
| `/Home/Dashboard` | GET | Home.Dashboard | Show dashboard |
| `/Meetings/MeetingList` | GET | Meetings.MeetingList | List all meetings |
| `/Meetings/MeetingAddEdit` | GET | Meetings.MeetingAddEdit | Show add form |
| `/Meetings/MeetingAddEdit?id=5` | GET | Meetings.MeetingAddEdit | Show edit form |
| `/Meetings/saveMeeting` | POST | Meetings.saveMeeting | Save meeting |
| `/Meetings/Delete/5` | GET | Meetings.Delete | Delete meeting |
| `/Department/DepartmentList` | GET | Department.DepartmentList | List departments |
| `/Department/DepartmentAddEdit` | GET | Department.DepartmentAddEdit | Show add form |
| `/Department/saveDept` | POST | Department.saveDept | Save department |
| `/Department/Delete/5` | GET | Department.Delete | Delete department |
| `/MeetingType/MeetingTypeList` | GET | MeetingType.MeetingTypeList | List types |
| `/MeetingType/saveMeetingType` | POST | MeetingType.saveMeetingType | Save type |
| `/MeetingVenue/MeetingVenueList` | GET | MeetingVenue.MeetingVenueList | List venues |
| `/MeetingVenue/saveMeetingVenue` | POST | MeetingVenue.saveMeetingVenue | Save venue |
| `/MeetingMember/MeetingMemberList` | GET | MeetingMember.MeetingMemberList | List attendees |
| `/MeetingMember/MeetingMemberList?meetingId=3` | GET | MeetingMember.MeetingMemberList | Filter by meeting |
| `/MeetingMember/saveMeetingMember` | POST | MeetingMember.saveMeetingMember | Save attendee |
| `/Staff/StaffList` | GET | Staff.StaffList | List staff |
| `/Staff/StaffAddEdit` | GET | Staff.StaffAddEdit | Show add form |
| `/Staff/saveStaff` | POST | Staff.saveStaff | Save staff |
| `/Staff/Delete/5` | GET | Staff.Delete | Delete staff |

---

# 11. Input/Output Specifications

## 11.1 LoginSignupController

### loginPage (POST)
**Input**:
```csharp
public IActionResult loginPage(UserModel model)
```
| Field | Type | Required | Validation |
|-------|------|----------|------------|
| Username | string | Yes | Not empty |
| Password | string | Yes | Not empty |

**Output**: 
- Success → Redirect to `/Home/Dashboard`
- Failure → View with ModelState error

---

## 11.2 MeetingsController

### saveMeeting (POST)
**Input**: `MeetingsModel model`
| Field | Type | Required | Validation |
|-------|------|----------|------------|
| MeetingID | int | Auto | 0 = Insert, >0 = Update |
| MeetingDate | DateTime | Yes | Must be valid date |
| MeetingVenueID | int | Yes | Must be > 0 |
| MeetingTypeID | int | Yes | Must be > 0 |
| DepartmentID | int | Yes | Must be > 0 |
| MeetingDescription | string | No | Max 250 chars |
| DocumentPath | string | No | Max 250 chars |
| IsCancelled | bool | Yes | Default false |
| CancellationDateTime | DateTime? | No | If cancelled |
| CancellationReason | string | No | Max 250 chars |

**Output**:
- Success → Redirect to `/Meetings/MeetingList`
- Failure → View with validation errors

---

### MeetingList (GET)
**Input**: None

**Output**:
- ViewBag.Meetings: List of MeetingsModel with computed member counts

---

## 11.3 StaffController

### saveStaff (POST)
**Input**: `StaffModel model`
| Field | Type | Required | Validation |
|-------|------|----------|------------|
| StaffID | int | Auto | 0 = Insert, >0 = Update |
| DepartmentID | int | Yes | Must be > 0 |
| StaffName | string | Yes | Max 50 chars |
| MobileNo | string | Yes | Max 20 chars |
| EmailAddress | string | Yes | Valid email format |
| Remarks | string | No | Max 250 chars |

**Output**:
- Success → Redirect to `/Staff/StaffList`
- Failure → View with validation errors

---

## 11.4 MeetingMemberController

### saveMeetingMember (POST)
**Input**: `MeetingMemberModel model`
| Field | Type | Required | Validation |
|-------|------|----------|------------|
| MeetingMemberID | int | Auto | 0 = Insert, >0 = Update |
| MeetingID | int | Yes | Must be > 0 |
| StaffID | int | Yes | Must be > 0 |
| IsPresent | bool | Yes | Default false |
| Remarks | string | No | Max 250 chars |

**Output**:
- Success → Redirect to `/MeetingMember/MeetingMemberList`
- Failure → View with validation errors

---

# 12. Error Handling

## Types of Errors and How They're Handled

### 12.1 Validation Errors (User Input)
**Example**: User forgets to select a department when creating staff

**Handling**:
- Model validation attributes (like `[Required]`) trigger automatically
- Form is redisplayed with error messages
- User must fix and resubmit

```csharp
// In StaffModel.cs
[Required(ErrorMessage = "Department is required")]
[Range(1, int.MaxValue, ErrorMessage = "Please select a department")]
public int DepartmentID { get; set; }

// In controller
if (ModelState.IsValid)  // If validation fails, this is false
{
    // Save to database
}
return View("StaffAddEdit", model);  // Show form with errors
```

### 12.2 Database Errors (SQL)
**Example**: Connection string is wrong, or stored procedure doesn't exist

**Handling**:
- Exception is thrown by SqlClient
- Application continues (no explicit error handling in controllers)
- In production, shows error page via exception handler

**Configured in Program.cs**:
```csharp
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");  // Show error page in production
}
```

### 12.3 Authentication Errors
**Example**: User tries to access dashboard without logging in

**Handling**:
- CheckAccess filter catches the request
- Redirects to `/LoginSignup/loginPage`
- User must log in to continue

### 12.4 Session Errors
**Example**: Session expires during long inactivity

**Handling**:
- CheckAccess filter finds no UserName in session
- Redirects to login page
- User logs in again to continue

---

# 13. Dependencies and Their Purposes

## 13.1 Project File Dependencies

**File**: `MOM_Project.csproj`

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <!-- .NET 10.0 (latest version) -->
    <Nullable>enable</Nullable>
    <!-- Enable null reference safety -->
    <ImplicitUsings>enable</ImplicitUsings>
    <!-- Use default usings automatically -->
  </PropertyGroup>

  <ItemGroup>
    <!-- Database connectivity library -->
    <PackageReference Include="Microsoft.Data.SqlClient" Version="6.1.4" />
  </ItemGroup>
</Project>
```

## 13.2 Package Details

| Package | Version | Purpose |
|---------|---------|---------|
| **Microsoft.Data.SqlClient** | 6.1.4 | Connect to SQL Server database, execute queries |

This is the main external dependency - it allows the application to talk to Microsoft SQL Server.

## 13.3 Built-in ASP.NET Core Services

These are included automatically by ASP.NET Core:

| Service | Purpose |
|---------|---------|
| **MVC Controllers** | Handle HTTP requests |
| **Razor Views** | Generate HTML |
| **Session** | Store user data |
| **Routing** | Map URLs to controllers |
| **Model Binding** | Convert form data to objects |
| **Validation** | Check data correctness |
| **Static Files** | Serve CSS, JS, images |

---

# 14. Configuration Explanations

## 14.1 appsettings.json Detailed

```json
{
  // Logging settings - what gets written to log files
  "Logging": {
    "LogLevel": {
      // Default: Show Information level messages and above
      "Default": "Information",
      // For ASP.NET Core framework: Show only warnings
      // (reduces noise in logs)
      "Microsoft.AspNetCore": "Warning"
    }
  },
  
  // Allowed hosts - which domain names can host this app
  // * means any host is allowed
  "AllowedHosts": "*",
  
  // Database connection strings
  "ConnectionStrings": {
    // DefaultConnection - main database
    "DefaultConnection": "Server=Meet\\SQLEXPRESS;Database=MOM_Meet;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### Connection String Breakdown:
```
Server=Meet\SQLEXPRESS     - SQL Server instance name (Meet = computer name)
                           - SQLEXPRESS = SQL Server Express edition
Database=MOM_Meet         - Name of the database
Trusted_Connection=True   - Use Windows Authentication (no username/password)
TrustServerCertificate=True - Accept self-signed certificates
```

---

## 14.2 Program.cs Configuration

### Session Configuration
```csharp
builder.Services.AddDistributedMemoryCache();
// Stores session data in server memory
// For production, use Redis or SQL Server session store

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    // If user is inactive for 30 minutes, session expires
    
    options.Cookie.HttpOnly = true;
    // JavaScript cannot read session cookie
    // Protects against XSS attacks
    
    options.Cookie.IsEssential = true;
    // Session cookie works even if user rejects cookies
    // (GDPR compliance)
});
```

### Global Filter Configuration
```csharp
builder.Services.AddControllersWithViews(options => 
{
    options.Filters.Add(new MOM_Project.Filters.CheckAccess());
});
// Adds CheckAccess filter to ALL controllers
// Every page requires login except [AllowAnonymous]

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LoginSignup}/{action=loginPage}/{id?}")
// Default route when app starts
// Opens LoginSignup controller, loginPage action
```

---

# 15. Quick Reference

## Common Tasks

### Check if User is Logged In
```csharp
var userName = HttpContext.Session.GetString("UserName");
if (userName != null) { /* logged in */ }
```

### Get Database Connection
```csharp
string connString = _configuration.GetConnectionString("DefaultConnection");
```

### Redirect to Another Page
```csharp
return RedirectToAction("ActionName", "ControllerName");
return RedirectToAction("Dashboard", "Home");
```

### Return View with Data
```csharp
return View(model);  // Pass model to view
```

### Add Error Message
```csharp
ModelState.AddModelError(string.Empty, "Error message");
```

### Check Model Validation
```csharp
if (ModelState.IsValid) { /* all fields valid */ }
```

---

## Database Stored Procedures Used

| Procedure | Purpose |
|-----------|---------|
| `PR_MOM_User_SelectForLogin` | Verify login credentials |
| `PR_MOM_Dashboard_Counts` | Get meeting/staff/department counts |
| `MOM_Meetings_GetAll` | Get all meetings |
| `MOM_Meetings_GetByID` | Get single meeting |
| `MOM_Meetings_Insert` | Create new meeting |
| `MOM_Meetings_Update` | Update existing meeting |
| `MOM_Meetings_Delete` | Delete meeting |
| `MOM_Department_*` | All department operations |
| `MOM_MeetingType_*` | All meeting type operations |
| `MOM_MeetingVenue_*` | All venue operations |
| `MOM_Staff_*` | All staff operations |
| `MOM_MeetingMember_*` | All attendee operations |

---

## File Summary Table

| File | Type | Lines | Purpose |
|------|------|-------|---------|
| Program.cs | C# | 43 | Application entry point |
| appsettings.json | JSON | 12 | Configuration |
| LoginSignupController.cs | C# | 88 | Authentication |
| HomeController.cs | C# | 46 | Dashboard |
| MeetingsController.cs | C# | 248 | Meeting CRUD |
| DepartmentController.cs | C# | 168 | Department CRUD |
| MeetingTypeController.cs | C# | 176 | Meeting type CRUD |
| MeetingVenueController.cs | C# | 125 | Venue CRUD |
| MeetingMemberController.cs | C# | 183 | Attendance CRUD |
| StaffController.cs | C# | 164 | Staff CRUD |
| CheckAccess.cs | C# | 28 | Security filter |
| MeetingsModel.cs | C# | 47 | Meeting data model |
| DepartmentModel.cs | C# | 21 | Department data model |
| StaffModel.cs | C# | 36 | Staff data model |

---

# Glossary for Beginners

| Term | Simple Meaning |
|------|----------------|
| **Controller** | A class that handles requests and decides what to do |
| **Model** | A data container that holds information |
| **View** | An HTML page that the user sees |
| **Session** | Temporary memory that remembers logged-in user |
| **Filter** | Code that runs before or after every request |
| **Route** | A URL pattern that maps to a controller action |
| **ViewBag** | A container to pass data from controller to view |
| **ViewModel** | A custom model for a specific view |
| **Stored Procedure** | Pre-written SQL code stored in the database |
| **MVC** | Model-View-Controller architecture pattern |
| **Razor** | ASP.NET's view engine that mixes HTML and C# |
| **SQL** | Language to talk to databases |

---

# End of Documentation

This documentation covers every component of the MOM Project. If you have questions about any specific part, refer to the relevant section above.

**Happy Learning! 🎉**