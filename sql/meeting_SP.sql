--insert meeting store procedure
CREATE OR ALTER PROCEDURE MOM_Meetings_Insert
     @MeetingDate DATETIME,
    @MeetingVenueID INT,
    @MeetingTypeID INT,
    @DepartmentID INT,
    @MeetingDescription NVARCHAR(250),
    @DocumentPath NVARCHAR(250)
as
begin
    insert into MOM_Meetings(
                    MeetingDate,
                    MeetingVenueID,
                    MeetingTypeID,
                    DepartmentID,
                    MeetingDescription,
                    DocumentPath,
                    Created,
                    Modified,
                    IsCancelled
                  )
           values(
                   @MeetingDate,
                   @MeetingVenueID,
                   @MeetingTypeID,
                   @DepartmentID,
                   @MeetingDescription,
                   @DocumentPath,
                   GETDATE(),
                    GETDATE(),
                    0
                   )
end;
GO

--update meeting stored procedure
CREATE OR ALTER PROCEDURE MOM_Meetings_Update
     @MeetingID int,
    @MeetingDate datetime,
    @MeetingVenueID int,
    @MeetingTypeID int,
    @DepartmentID int,
    @MeetingDescription nvarchar(250),
    @DocumentPath nvarchar(250)
as
begin
    update MOM_Meetings
    set
        MeetingDate = @MeetingDate,
        MeetingVenueID = @MeetingVenueID,
        MeetingTypeID = @MeetingTypeID,
        DepartmentID = @DepartmentID,
        MeetingDescription = @MeetingDescription,
        DocumentPath = @DocumentPath,
        Modified = GETDATE()
    where MeetingID = @MeetingID;
end;
GO

--meeting cancel stored procedure
CREATE OR ALTER PROCEDURE MOM_Meetings_Cancel
    @MeetingID int,
    @CancellationReason nvarchar(250)
as
begin
    update MOM_Meetings
    set 
        IsCancelled=1,
        CancellationDateTime=GETDATE(),
        CancellationReason=@CancellationReason,
        Modified=GETDATE()
    where MeetingID=@MeetingID
end;
GO

--delete meetings stored procedure 
CREATE OR ALTER PROCEDURE MOM_Meetings_Delete
    @MeetingID int
as
begin
    delete from MOM_Meetings
    where MeetingID=@MeetingID
end;
GO

--get all stored procedure
CREATE OR ALTER PROCEDURE MOM_Meetings_GetAll
as
begin
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
end;
GO

--get by id stored procedure
CREATE OR ALTER PROCEDURE MOM_Meetings_GetByID
    @MeetingID int
as
begin
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
    where m.MeetingID=@MeetingID
end;
GO

--get by department store procedure
CREATE OR ALTER PROCEDURE MOM_Meetings_GetByDepartment
    @DepartmentID int
as
begin
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
    where m.DepartmentID=@DepartmentID
end;
GO
