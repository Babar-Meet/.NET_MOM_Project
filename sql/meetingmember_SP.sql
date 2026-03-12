--insert meeting member stored procedure
GO

CREATE OR ALTER PROCEDURE MOM_MeetingMember_Insert
    @MeetingID INT,
    @StaffID INT,
    @IsPresent BIT,
    @Remarks NVARCHAR(250)
AS
BEGIN
    INSERT INTO MOM_MeetingMember (MeetingID, StaffID, IsPresent, Remarks, Modified)
    VALUES (@MeetingID, @StaffID, @IsPresent, @Remarks, GETDATE());
END;
GO

--update meeting member stored procedure--
CREATE OR ALTER PROCEDURE MOM_MeetingMember_Update
    @MeetingMemberID INT,
    @MeetingID INT,
    @StaffID INT,
    @IsPresent BIT,
    @Remarks NVARCHAR(250)
as 
begin
    update MOM_MeetingMember
    set
        MeetingID=@MeetingID,
        StaffID=@StaffID,
        IsPresent=@IsPresent,
        Remarks=@Remarks,
        Modified=GETDATE()
    where MeetingMemberID=@MeetingMemberID
end;
GO

--delete meeting member stored procedure--
CREATE OR ALTER PROCEDURE MOM_MeetingMember_Delete
    @MeetingMemberID INT
as
begin
    delete from MOM_MeetingMember
    where MeetingMemberID = @MeetingMemberID;
end;
GO

---getall meeting member stored procedure
CREATE OR ALTER PROCEDURE MOM_MeetingMember_GetAll
as
begin
    SELECT mm.MeetingMemberID,
           mm.MeetingID,
           m.MeetingDate,
           mm.StaffID,
           s.StaffName,
           mm.IsPresent,
           mm.Remarks,
           mm.Created,
           mm.Modified
    FROM MOM_MeetingMember mm
    INNER JOIN MOM_Meetings m ON mm.MeetingID = m.MeetingID
    INNER JOIN MOM_Staff s ON mm.StaffID = s.StaffID
    ORDER BY m.MeetingDate DESC, s.StaffName
end;
GO

--get by id meeting member stored procedure
CREATE OR ALTER PROCEDURE MOM_MeetingMember_GetById
    @MeetingMemberID int
as 
begin
    SELECT mm.MeetingMemberID,
           mm.MeetingID,
           m.MeetingDate,
           mm.StaffID,
           s.StaffName,
           mm.IsPresent,
           mm.Remarks,
           mm.Created,
           mm.Modified
    FROM MOM_MeetingMember mm
    INNER JOIN MOM_Meetings m ON mm.MeetingID = m.MeetingID
    INNER JOIN MOM_Staff s ON mm.StaffID = s.StaffID
    WHERE mm.MeetingMemberID=@MeetingMemberID;
end;
GO