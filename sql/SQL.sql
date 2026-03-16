-- =============================================
-- MOM Project - Database Setup
-- =============================================

-- =============================================
-- TABLE CREATION
-- =============================================

use MOM_Project
-- Run these CREATE TABLE statements only if the tables don't exist yet.
-- If tables already exist, skip to the Stored Procedures section below.
SELECT * FROM INFORMATION_SCHEMA.TABLES

select * from MOM_MeetingType
select * from MOM_Department
select * from MOM_MeetingMember
select * from MOM_Meetings
select * from MOM_MeetingVenue
select  * from MOM_Staff



CREATE TABLE MOM_MeetingType (
    MeetingTypeID INT IDENTITY(1,1) PRIMARY KEY,
    MeetingTypeName NVARCHAR(100) NOT NULL,
    Remarks NVARCHAR(100) NOT NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NOT NULL
);

CREATE TABLE MOM_Department (
    DepartmentID INT IDENTITY(1,1) PRIMARY KEY,
    DepartmentName NVARCHAR(100) NOT NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NOT NULL
);

CREATE TABLE MOM_MeetingVenue (
    MeetingVenueID INT IDENTITY(1,1) PRIMARY KEY,
    MeetingVenueName NVARCHAR(100) NOT NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NOT NULL
);

CREATE TABLE MOM_Meetings (
    MeetingID INT IDENTITY(1,1) PRIMARY KEY,
    MeetingDate DATETIME NOT NULL,
    MeetingVenueID INT NOT NULL,
    MeetingTypeID INT NOT NULL,
    DepartmentID INT NOT NULL,
    MeetingDescription NVARCHAR(250) NULL,
    DocumentPath NVARCHAR(250) NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NOT NULL,
    IsCancelled BIT NOT NULL DEFAULT 0,
    CancellationDateTime DATETIME NULL,
    CancellationReason NVARCHAR(250) NULL,

    CONSTRAINT FK_Meeting_Venue FOREIGN KEY (MeetingVenueID)
        REFERENCES MOM_MeetingVenue(MeetingVenueID),

    CONSTRAINT FK_Meeting_Type FOREIGN KEY (MeetingTypeID)
        REFERENCES MOM_MeetingType(MeetingTypeID),

    CONSTRAINT FK_Meeting_Department FOREIGN KEY (DepartmentID)
        REFERENCES MOM_Department(DepartmentID)
);

CREATE TABLE MOM_Staff (
    StaffID INT IDENTITY(1,1) PRIMARY KEY,
    DepartmentID INT NOT NULL,
    StaffName NVARCHAR(50) NOT NULL,
    MobileNo NVARCHAR(20) NOT NULL,
    EmailAddress NVARCHAR(50) NOT NULL,
    Remarks NVARCHAR(250) NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NOT NULL,

    CONSTRAINT FK_Staff_Department FOREIGN KEY (DepartmentID)
        REFERENCES MOM_Department(DepartmentID)
);

CREATE TABLE MOM_MeetingMember (
    MeetingMemberID INT IDENTITY(1,1) PRIMARY KEY,
    MeetingID INT NOT NULL,
    StaffID INT NOT NULL,
    IsPresent BIT NOT NULL,
    Remarks NVARCHAR(250) NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NOT NULL,

    CONSTRAINT FK_Member_Meeting FOREIGN KEY (MeetingID)
        REFERENCES MOM_Meetings(MeetingID),

    CONSTRAINT FK_Member_Staff FOREIGN KEY (StaffID)
        REFERENCES MOM_Staff(StaffID)
);

GO

-- =============================================
-- STORED PROCEDURES
-- =============================================

-- =============================================
-- MOM_MeetingType Stored Procedures
-- =============================================

CREATE OR ALTER PROCEDURE [dbo].[MOM_MeetingType_GetAll]
AS
BEGIN
    SELECT MeetingTypeID,
           MeetingTypeName,
           Remarks,
           Created,
           Modified
    FROM [dbo].[MOM_MeetingType]
    ORDER BY MeetingTypeName
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_MeetingType_GetByID]
@MeetingTypeID INT
AS
BEGIN
    SELECT MeetingTypeID,
           MeetingTypeName,
           Remarks,
           Created,
           Modified
    FROM [dbo].[MOM_MeetingType]
    WHERE MeetingTypeID = @MeetingTypeID
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_MeetingType_Insert]
@MeetingTypeName NVARCHAR(100),
@Remarks         NVARCHAR(100)
AS
BEGIN
    INSERT INTO [dbo].[MOM_MeetingType]
    (MeetingTypeName, Remarks, Modified)
    VALUES
    (@MeetingTypeName, @Remarks, GETDATE())
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_MeetingType_Update]
@MeetingTypeID   INT,
@MeetingTypeName NVARCHAR(100),
@Remarks         NVARCHAR(100)
AS
BEGIN
    UPDATE [dbo].[MOM_MeetingType]
    SET MeetingTypeName = @MeetingTypeName,
        Remarks = @Remarks,
        Modified = GETDATE()
    WHERE MeetingTypeID = @MeetingTypeID
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_MeetingType_Delete]
@MeetingTypeID INT
AS
BEGIN
    DELETE FROM [dbo].[MOM_MeetingType]
    WHERE MeetingTypeID = @MeetingTypeID
END
GO

-- =============================================
-- MOM_Department Stored Procedures
-- =============================================

CREATE OR ALTER PROCEDURE [dbo].[MOM_Department_GetAll]
AS
BEGIN
    SELECT DepartmentID,
           DepartmentName,
           Created,
           Modified
    FROM [dbo].[MOM_Department]
    ORDER BY DepartmentName
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_Department_GetByID]
@DepartmentID INT
AS
BEGIN
    SELECT DepartmentID,
           DepartmentName,
           Created,
           Modified
    FROM [dbo].[MOM_Department]
    WHERE DepartmentID = @DepartmentID
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_Department_Insert]
@DepartmentName NVARCHAR(100)
AS
BEGIN
    INSERT INTO [dbo].[MOM_Department]
    (DepartmentName, Modified)
    VALUES
    (@DepartmentName, GETDATE())
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_Department_Update]
@DepartmentID   INT,
@DepartmentName NVARCHAR(100)
AS
BEGIN
    UPDATE [dbo].[MOM_Department]
    SET DepartmentName = @DepartmentName,
        Modified = GETDATE()
    WHERE DepartmentID = @DepartmentID
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_Department_Delete]
@DepartmentID INT
AS
BEGIN
    DELETE FROM [dbo].[MOM_Department]
    WHERE DepartmentID = @DepartmentID
END
GO

-- =============================================
-- MOM_MeetingVenue Stored Procedures
-- =============================================

CREATE OR ALTER PROCEDURE [dbo].[MOM_MeetingVenue_GetAll]
AS
BEGIN
    SELECT MeetingVenueID,
           MeetingVenueName,
           Created,
           Modified
    FROM [dbo].[MOM_MeetingVenue]
    ORDER BY MeetingVenueName
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_MeetingVenue_GetByID]
@MeetingVenueID INT
AS
BEGIN
    SELECT MeetingVenueID,
           MeetingVenueName,
           Created,
           Modified
    FROM [dbo].[MOM_MeetingVenue]
    WHERE MeetingVenueID = @MeetingVenueID
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_MeetingVenue_Insert]
@MeetingVenueName NVARCHAR(100)
AS
BEGIN
    INSERT INTO [dbo].[MOM_MeetingVenue]
    (MeetingVenueName, Modified)
    VALUES
    (@MeetingVenueName, GETDATE())
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_MeetingVenue_Update]
@MeetingVenueID   INT,
@MeetingVenueName NVARCHAR(100)
AS
BEGIN
    UPDATE [dbo].[MOM_MeetingVenue]
    SET MeetingVenueName = @MeetingVenueName,
        Modified = GETDATE()
    WHERE MeetingVenueID = @MeetingVenueID
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_MeetingVenue_Delete]
@MeetingVenueID INT
AS
BEGIN
    DELETE FROM [dbo].[MOM_MeetingVenue]
    WHERE MeetingVenueID = @MeetingVenueID
END
GO

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

-- =============================================
-- MOM_Meetings Stored Procedures
-- =============================================

CREATE OR ALTER PROCEDURE [dbo].[MOM_Meetings_GetAll]
AS
BEGIN
    SELECT m.MeetingID,
           m.MeetingDate,
           m.MeetingVenueID,
           mv.MeetingVenueName,
           m.MeetingTypeID,
           mt.MeetingTypeName,
           m.DepartmentID,
           d.DepartmentName,
           m.MeetingDescription,
           m.DocumentPath,
           m.Created,
           m.Modified,
           m.IsCancelled,
           m.CancellationDateTime,
           m.CancellationReason
    FROM [dbo].[MOM_Meetings] m
    INNER JOIN [dbo].[MOM_MeetingVenue] mv ON m.MeetingVenueID = mv.MeetingVenueID
    INNER JOIN [dbo].[MOM_MeetingType] mt ON m.MeetingTypeID = mt.MeetingTypeID
    INNER JOIN [dbo].[MOM_Department] d ON m.DepartmentID = d.DepartmentID
    ORDER BY m.MeetingDate DESC
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_Meetings_GetByID]
@MeetingID INT
AS
BEGIN
    SELECT m.MeetingID,
           m.MeetingDate,
           m.MeetingVenueID,
           mv.MeetingVenueName,
           m.MeetingTypeID,
           mt.MeetingTypeName,
           m.DepartmentID,
           d.DepartmentName,
           m.MeetingDescription,
           m.DocumentPath,
           m.Created,
           m.Modified,
           m.IsCancelled,
           m.CancellationDateTime,
           m.CancellationReason
    FROM [dbo].[MOM_Meetings] m
    INNER JOIN [dbo].[MOM_MeetingVenue] mv ON m.MeetingVenueID = mv.MeetingVenueID
    INNER JOIN [dbo].[MOM_MeetingType] mt ON m.MeetingTypeID = mt.MeetingTypeID
    INNER JOIN [dbo].[MOM_Department] d ON m.DepartmentID = d.DepartmentID
    WHERE m.MeetingID = @MeetingID
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_Meetings_Insert]
@MeetingDate          DATETIME,
@MeetingVenueID       INT,
@MeetingTypeID        INT,
@DepartmentID         INT,
@MeetingDescription   NVARCHAR(250),
@DocumentPath         NVARCHAR(250),
@IsCancelled          BIT = 0,
@CancellationDateTime DATETIME = NULL,
@CancellationReason   NVARCHAR(250) = NULL
AS
BEGIN
    INSERT INTO [dbo].[MOM_Meetings]
    (MeetingDate, MeetingVenueID, MeetingTypeID, DepartmentID, MeetingDescription, DocumentPath, IsCancelled, CancellationDateTime, CancellationReason, Modified)
    VALUES
    (@MeetingDate, @MeetingVenueID, @MeetingTypeID, @DepartmentID, @MeetingDescription, @DocumentPath, @IsCancelled, @CancellationDateTime, @CancellationReason, GETDATE())
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_Meetings_Update]
@MeetingID            INT,
@MeetingDate          DATETIME,
@MeetingVenueID       INT,
@MeetingTypeID        INT,
@DepartmentID         INT,
@MeetingDescription   NVARCHAR(250),
@DocumentPath         NVARCHAR(250),
@IsCancelled          BIT = 0,
@CancellationDateTime DATETIME = NULL,
@CancellationReason   NVARCHAR(250) = NULL
AS
BEGIN
    UPDATE [dbo].[MOM_Meetings]
    SET MeetingDate = @MeetingDate,
        MeetingVenueID = @MeetingVenueID,
        MeetingTypeID = @MeetingTypeID,
        DepartmentID = @DepartmentID,
        MeetingDescription = @MeetingDescription,
        DocumentPath = @DocumentPath,
        IsCancelled = @IsCancelled,
        CancellationDateTime = @CancellationDateTime,
        CancellationReason = @CancellationReason,
        Modified = GETDATE()
    WHERE MeetingID = @MeetingID
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_Meetings_Delete]
@MeetingID INT
AS
BEGIN
    DELETE FROM [dbo].[MOM_Meetings]
    WHERE MeetingID = @MeetingID
END
GO

-- =============================================
-- MOM_MeetingMember Stored Procedures
-- =============================================

CREATE OR ALTER PROCEDURE [dbo].[MOM_MeetingMember_GetAll]
AS
BEGIN
    SELECT mm.MeetingMemberID,
           mm.MeetingID,
           m.MeetingDate,
           mm.StaffID,
           s.StaffName,
           mm.IsPresent,
           mm.Remarks,
           mm.Created,
           mm.Modified
    FROM [dbo].[MOM_MeetingMember] mm
    INNER JOIN [dbo].[MOM_Meetings] m ON mm.MeetingID = m.MeetingID
    INNER JOIN [dbo].[MOM_Staff] s ON mm.StaffID = s.StaffID
    ORDER BY m.MeetingDate DESC, s.StaffName
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_MeetingMember_GetByID]
@MeetingMemberID INT
AS
BEGIN
    SELECT mm.MeetingMemberID,
           mm.MeetingID,
           m.MeetingDate,
           mm.StaffID,
           s.StaffName,
           mm.IsPresent,
           mm.Remarks,
           mm.Created,
           mm.Modified
    FROM [dbo].[MOM_MeetingMember] mm
    INNER JOIN [dbo].[MOM_Meetings] m ON mm.MeetingID = m.MeetingID
    INNER JOIN [dbo].[MOM_Staff] s ON mm.StaffID = s.StaffID
    WHERE mm.MeetingMemberID = @MeetingMemberID
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_MeetingMember_Insert]
@MeetingID INT,
@StaffID   INT,
@IsPresent BIT,
@Remarks   NVARCHAR(250)
AS
BEGIN
    INSERT INTO [dbo].[MOM_MeetingMember]
    (MeetingID, StaffID, IsPresent, Remarks, Modified)
    VALUES
    (@MeetingID, @StaffID, @IsPresent, @Remarks, GETDATE())
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_MeetingMember_Update]
@MeetingMemberID INT,
@MeetingID       INT,
@StaffID         INT,
@IsPresent       BIT,
@Remarks         NVARCHAR(250)
AS
BEGIN
    UPDATE [dbo].[MOM_MeetingMember]
    SET MeetingID = @MeetingID,
        StaffID = @StaffID,
        IsPresent = @IsPresent,
        Remarks = @Remarks,
        Modified = GETDATE()
    WHERE MeetingMemberID = @MeetingMemberID
END
GO

CREATE OR ALTER PROCEDURE [dbo].[MOM_MeetingMember_Delete]
@MeetingMemberID INT
AS
BEGIN
    DELETE FROM [dbo].[MOM_MeetingMember]
    WHERE MeetingMemberID = @MeetingMemberID
END
GO
