use MOM
go
--insert department stored procedure
CREATE OR ALTER PROCEDURE MOM_Department_Insert
 @DepartmentName nvarchar(250)
as
begin
 insert into MOM_Department(DepartmentName,Created,Modified)
	values(@DepartmentName,GETDATE(),GETDATE());
end;
GO

--update department store procedure
CREATE OR ALTER PROCEDURE MOM_Department_Update
	@DepartmentID int,
	@DepartmentName nvarchar(250)
as
begin
	update MOM_Department
	set 
		DepartmentName=@DepartmentName,
		Modified=GETDATE()
	where DepartmentID=@DepartmentID
end;
GO

--delete department stored procedure
CREATE OR ALTER PROCEDURE MOM_Department_Delete
	@DepartmentID int
as
begin
	delete from MOM_Department
	where DepartmentID=@DepartmentID
end;
GO

--getall department store procedure
CREATE OR ALTER PROCEDURE MOM_Department_GetAll
as
begin
	select * from MOM_Department;
end;
GO

--get by id department store procedure
CREATE OR ALTER PROCEDURE MOM_Department_GetByID
 @DepartmentID int
as
begin
 select * from MOM_Department
	where DepartmentID=@DepartmentID
end;
GO
