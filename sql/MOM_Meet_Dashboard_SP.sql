USE [MOM_Meet]
GO

CREATE OR ALTER PROCEDURE [dbo].[PR_MOM_Dashboard_Counts]
AS
BEGIN
    SELECT 
        (SELECT COUNT(*) FROM MOM_Meetings) AS TotalMeetings,
        (SELECT COUNT(*) FROM MOM_Department) AS TotalDepartments,
        (SELECT COUNT(*) FROM MOM_Staff) AS TotalStaff
END
GO
