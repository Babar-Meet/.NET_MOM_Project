-- =============================================
-- MOM_Staff Stored Procedures
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[MOM_Staff_GetAll]
AS
BEGIN
    SELECT s.StaffID,
           s.DepartmentID,
           d.DepartmentName,
           s.StaffName,
           s.MobileNo,
           s.EmailAddress,
           s.Remarks,
           s.Created,
           s.Modified
    FROM [dbo].[MOM_Staff] s
    INNER JOIN [dbo].[MOM_Department] d ON s.DepartmentID = d.DepartmentID
    ORDER BY s.StaffName
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_Staff_GetByID]
@StaffID INT
AS
BEGIN
    SELECT s.StaffID,
           s.DepartmentID,
           d.DepartmentName,
           s.StaffName,
           s.MobileNo,
           s.EmailAddress,
           s.Remarks,
           s.Created,
           s.Modified
    FROM [dbo].[MOM_Staff] s
    INNER JOIN [dbo].[MOM_Department] d ON s.DepartmentID = d.DepartmentID
    WHERE s.StaffID = @StaffID
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_Staff_Insert]
@DepartmentID INT,
@StaffName    NVARCHAR(50),
@MobileNo     NVARCHAR(20),
@EmailAddress NVARCHAR(50),
@Remarks      NVARCHAR(250)
AS
BEGIN
    INSERT INTO [dbo].[MOM_Staff]
    (DepartmentID, StaffName, MobileNo, EmailAddress, Remarks, Modified)
    VALUES
    (@DepartmentID, @StaffName, @MobileNo, @EmailAddress, @Remarks, GETDATE())
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_Staff_Update]
@StaffID      INT,
@DepartmentID INT,
@StaffName    NVARCHAR(50),
@MobileNo     NVARCHAR(20),
@EmailAddress NVARCHAR(50),
@Remarks      NVARCHAR(250)
AS
BEGIN
    UPDATE [dbo].[MOM_Staff]
    SET DepartmentID = @DepartmentID,
        StaffName = @StaffName,
        MobileNo = @MobileNo,
        EmailAddress = @EmailAddress,
        Remarks = @Remarks,
        Modified = GETDATE()
    WHERE StaffID = @StaffID
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_Staff_Delete]
@StaffID INT
AS
BEGIN
    DELETE FROM [dbo].[MOM_Staff]
    WHERE StaffID = @StaffID
END
GO
