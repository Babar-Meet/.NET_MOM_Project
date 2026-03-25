USE [MOM_Meet]
GO

-- =============================================
-- Insert Dummy Departments (5 rows)
-- =============================================
INSERT INTO [dbo].[MOM_Department] ([DepartmentName], [Modified]) VALUES 
('Engineering', GETDATE()),
('Human Resources', GETDATE()),
('Marketing', GETDATE()),
('Sales', GETDATE()),
('Finance', GETDATE());
GO

-- =============================================
-- Insert Dummy Meeting Types (5 rows)
-- =============================================
INSERT INTO [dbo].[MOM_MeetingType] ([MeetingTypeName], [Remarks], [Modified]) VALUES
('Weekly Sync', 'Regular weekly touch base', GETDATE()),
('Project Kickoff', 'Starting a new initiative', GETDATE()),
('Performance Review', 'Quarterly or annual reviews', GETDATE()),
('Client Pitch', 'External client meetings', GETDATE()),
('All Hands', 'Company wide announcements', GETDATE());
GO

-- =============================================
-- Insert Dummy Venues (5 rows)
-- =============================================
INSERT INTO [dbo].[MOM_MeetingVenue] ([MeetingVenueName], [Modified]) VALUES
('Conference Room A (Floor 1)', GETDATE()),
('Boardroom (Floor 2)', GETDATE()),
('Huddle Room 1 (Floor 1)', GETDATE()),
('Auditorium (Floor 3)', GETDATE()),
('Virtual Link (Online)', GETDATE());
GO

-- =============================================
-- Insert Dummy Staff (6 rows)
-- Relies on Departments 1-5 being created
-- =============================================
INSERT INTO [dbo].[MOM_Staff] ([DepartmentID], [StaffName], [MobileNo], [EmailAddress], [Remarks], [Modified]) VALUES
(1, 'Alice Smith', '555-0101', 'alice@example.com', 'Senior Engineer', GETDATE()),
(2, 'Bob Jones', '555-0102', 'bob@example.com', 'HR Director', GETDATE()),
(3, 'Charlie Brown', '555-0103', 'charlie@example.com', 'Marketing Lead', GETDATE()),
(4, 'Diana Prince', '555-0104', 'diana@example.com', 'VP of Sales', GETDATE()),
(5, 'Evan Wright', '555-0105', 'evan@example.com', 'Chief Financial Officer', GETDATE()),
(1, 'Frank Miller', '555-0106', 'frank@example.com', 'Junior Developer', GETDATE());
GO

-- =============================================
-- Insert Dummy Meetings (6 rows)
-- Relies on Venues, Types, and Departments 1-5
-- =============================================
INSERT INTO [dbo].[MOM_Meetings] ([MeetingDate], [MeetingVenueID], [MeetingTypeID], [DepartmentID], [MeetingDescription], [DocumentPath], [Modified], [IsCancelled]) VALUES
('2026-03-30 10:00:00', 1, 1, 1, 'Weekly Engineering Sync tracking Q1 sprint velocity', NULL, GETDATE(), 0),
('2026-04-05 14:00:00', 2, 3, 3, 'Q1 Marketing Campaign Review metrics discussion', NULL, GETDATE(), 0),
('2026-04-10 09:00:00', 1, 4, 4, 'Pitching enterprise suite to new regional client', NULL, GETDATE(), 0),
('2026-04-15 13:00:00', 4, 5, 2, 'Annual All Hands update regarding company goals', NULL, GETDATE(), 0),
('2026-03-31 11:00:00', 3, 1, 5, 'End of month financial audit review', NULL, GETDATE(), 0),
('2026-04-20 09:30:00', 5, 2, 1, 'Architecture kickoff for new microservices project', NULL, GETDATE(), 0);
GO

-- =============================================
-- Insert Dummy Meeting Members (14 rows)
-- Links Staff (1-6) to Meetings (1-6)
-- =============================================
INSERT INTO [dbo].[MOM_MeetingMember] ([MeetingID], [StaffID], [IsPresent], [Remarks], [Modified]) VALUES
(1, 1, 1, 'Attended via Zoom', GETDATE()),
(1, 6, 1, 'Present in room', GETDATE()),
(2, 3, 1, NULL, GETDATE()),
(2, 4, 0, 'Out Sick', GETDATE()),
(3, 4, 1, 'Lead Presenter', GETDATE()),
(3, 1, 1, 'Technical Support', GETDATE()),
(4, 1, 1, NULL, GETDATE()),
(4, 2, 1, NULL, GETDATE()),
(4, 3, 1, NULL, GETDATE()),
(4, 4, 1, NULL, GETDATE()),
(4, 5, 1, NULL, GETDATE()),
(4, 6, 1, NULL, GETDATE()),
(5, 5, 1, 'Leading session', GETDATE()),
(6, 1, 0, 'Double booked', GETDATE());
GO
