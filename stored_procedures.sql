Use InstituteAttendenceSystem;

go

create procedure Course_GetAll
AS
BEGIN 
	SELECT * FROM tbl_course
END;
go
CREATE PROCEDURE Course_Save
@ParamTable1 VARCHAR(10),
@ParamTable2 VARCHAR(150),
@ParamTable3 VARCHAR(150)

AS
	BEGIN
	INSERT INTO tbl_course
	VALUES (@ParamTable1,@ParamTable2,@ParamTable3)
END;
go
CREATE PROCEDURE Course_Edit
@CourseId INT,
@CourseCode VARCHAR(50),
@CourseName VARCHAR(50),
@CourseShortName VARCHAR(50)

AS
BEGIN
    UPDATE tbl_course
    SET CourseCode = @CourseCode, CourseName = @CourseName, CourseShortName = @CourseShortName
    WHERE CourseId = @CourseId
END;
go
CREATE PROCEDURE Course_Delete
@CourseId INT

AS
BEGIN
	DELETE FROM tbl_course
	WHERE CourseId = @CourseId
END;