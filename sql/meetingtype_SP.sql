--insert meeting type store procedure
CREATE OR ALTER PROCEDURE MOM_MeetingType_Insert
	@MeetingTypeName nvarchar(250),
	@Remarks nvarchar(250)
as 
begin
	insert into MOM_MeetingType(MeetingTypeName,Remarks)
	values(@MeetingTypeName,@Remarks)
end
GO

--update meeting type store procedure
CREATE OR ALTER PROCEDURE MOM_MeetingType_Update
	@MeetingTypeID int,
	@MeetingTypeName nvarchar(250),
	@Remarks nvarchar(250)
as 
begin
	update MOM_MeetingType
	set 
		MeetingTypeName=@MeetingTypeName,
		Remarks=@Remarks
	where MeetingTypeID=@MeetingTypeID
end;
GO

--delete meeting type store procedure
CREATE OR ALTER PROCEDURE MOM_MeetingType_delete
	@MeetingTypeID int
as
begin
	delete from MOM_MeetingType
	where MeetingTypeID=@MeetingTypeID
end;
GO

--get all meeting type store procedure
CREATE OR ALTER PROCEDURE MOM_MeetingType_GetAll
as 
begin
	select * from MOM_MeetingType;
end;
GO

--get by id meeting type stored procedure
CREATE OR ALTER PROCEDURE MOM_MeetingType_GetByID
	@MeetingTypeID int
 as
 begin
	select * from MOM_MeetingType
	where MeetingTypeID=@MeetingTypeID
end;
GO
