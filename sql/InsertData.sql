-- =============================================
-- MOM Project - Sample Data
-- =============================================

-- 1. Meeting Types
INSERT INTO MOM_MeetingType (MeetingTypeName, Remarks, Modified) VALUES
('Board Meeting', 'Official board discussions', GETDATE()),
('Technical Sync', 'Weekly dev team sync', GETDATE()),
('Budget Review', 'Quarterly financial review', GETDATE());

-- 2. Departments
INSERT INTO MOM_Department (DepartmentName, Modified) VALUES
('Management', GETDATE()),
('Engineering', GETDATE()),
('Finance', GETDATE()),
('Human Resources', GETDATE());

-- 3. Meeting Venues
INSERT INTO MOM_MeetingVenue (MeetingVenueName, Modified) VALUES
('Conference Room A', GETDATE()),
('Meeting Room 101', GETDATE()),
('Executive Suite', GETDATE());

-- 4. Staff
INSERT INTO MOM_Staff (DepartmentID, StaffName, MobileNo, EmailAddress, Remarks, Modified) VALUES
(1, 'John Doe', '1234567890', 'john.doe@company.com', 'Manager', GETDATE()),
(2, 'Jane Smith', '0987654321', 'jane.smith@company.com', 'Lead Developer', GETDATE()),
(2, 'Alice Johnson', '5551234567', 'alice.j@company.com', 'Senior Dev', GETDATE()),
(3, 'Bob Wilson', '4449876543', 'bob.w@company.com', 'Accountant', GETDATE());

-- 5. Meetings
INSERT INTO MOM_Meetings (MeetingDate, MeetingVenueID, MeetingTypeID, DepartmentID, MeetingDescription, DocumentPath, Modified) VALUES
(DATEADD(day, 1, GETDATE()), 1, 1, 1, 'Initial Strategy Meeting', '/docs/strategy.pdf', GETDATE()),
(DATEADD(day, -1, GETDATE()), 2, 2, 2, 'Dev Sprint Planning', '/docs/sprint.pdf', GETDATE());

-- 6. Meeting Members
INSERT INTO MOM_MeetingMember (MeetingID, StaffID, IsPresent, Remarks, Modified) VALUES
(1, 1, 1, 'Attending', GETDATE()),
(1, 4, 1, 'Finance representative', GETDATE()),
(2, 2, 1, 'Presenter', GETDATE()),
(2, 3, 0, 'On leave', GETDATE());
