--insert meetingvenue store procedure
CREATE OR ALTER PROCEDURE MOM_MeetingVenue_Insert
	@MeetingVenueName nvarchar(250)
as
begin
	insert into MOM_MeetingVenue(MeetingVenueName,Created,Modified)
	values(@MeetingVenueName,GETDATE(),GETDATE())
end;
GO

--update meetingvenue store procedure
CREATE OR ALTER PROCEDURE MOM_MeetingVenue_Update
	@MeetingVenueID int,
	@MeetingVenueName nvarchar(250)
 as
 begin
  update MOM_MeetingVenue
  set 
	MeetingVenueName=@MeetingVenueName,
	Modified=GETDATE()
  WHERE MeetingVenueID=@MeetingVenueID
end
GO

--delete meeting venue stored procedure
CREATE OR ALTER PROCEDURE MOM_MeetingVenue_Delete
	@MeetingVenueID int
as 
begin
	delete from MOM_MeetingVenue
	where MeetingVenueID=@MeetingVenueID
end;
GO

--get all meeting venue stored procedure
CREATE OR ALTER PROCEDURE MOM_MeetingVenue_GetAll
as 
begin
	select * from MOM_MeetingVenue
end;
GO

--get by id meeting venue stored procedure
CREATE OR ALTER PROCEDURE MOM_MeetingVenue_GetById
	@MeetingVenueID int
as 
begin
	select * from MOM_MeetingVenue
	where MeetingVenueID=@MeetingVenueID
end;
GO
