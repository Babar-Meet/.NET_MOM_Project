--insert meetingvenue store procedure
create procedure MOM_MeetingVenue_Insert
	@MeetingVenueName nvarchar(250)
as
begin
	insert into MOM_MeetingVenue(MeetingVenueName,Created,Modified)
	values(@MeetingVenueName,GETDATE(),GETDATE())
end;

--update meetingvenue store procedure
go
create procedure MOM_MeetingVenue_Update
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

--delete meeting venue stored procedure
go
create procedure MOM_MeetingVenue_Delete
	@MeetingVenueID int
as 
begin
	delete from MOM_MeetingVenue
	where MeetingVenueID=@MeetingVenueID
end;

--get all meeting venue stored procedure
go
create procedure MOM_MeetingVenue_GetAll
as 
begin
	select * from MOM_MeetingVenue
end;

--get by id meeting venue stored procedure
go
create procedure MOM_MeetingVenue_GetById
	@MeetingVenueID int
as 
begin
	select * from MOM_MeetingVenue
	where MeetingVenueID=@MeetingVenueID
end;
