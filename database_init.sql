USE [master]
GO
/****** Object:  Database [InstituteAttendenceSystem]    Script Date: 1/21/2023 10:15:22 PM ******/
CREATE DATABASE [InstituteAttendenceSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InstituteAttendenceSystem', FILENAME = N'D:\sqlserver\MSSQL16.MSSQLSERVER\MSSQL\DATA\InstituteAttendenceSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'InstituteAttendenceSystem_log', FILENAME = N'D:\sqlserver\MSSQL16.MSSQLSERVER\MSSQL\DATA\InstituteAttendenceSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [InstituteAttendenceSystem] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InstituteAttendenceSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InstituteAttendenceSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET  MULTI_USER 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InstituteAttendenceSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [InstituteAttendenceSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'InstituteAttendenceSystem', N'ON'
GO
ALTER DATABASE [InstituteAttendenceSystem] SET QUERY_STORE = OFF
GO
USE [InstituteAttendenceSystem]
GO
/****** Object:  Table [dbo].[tbl_Course]    Script Date: 1/21/2023 10:15:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseCode] [nvarchar](50) NOT NULL,
	[CourseName] [nvarchar](50) NOT NULL,
	[CourseShortName] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TimeSlot]    Script Date: 1/21/2023 10:15:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TimeSlot](
	[TSId] [int] IDENTITY(1,1) NOT NULL,
	[TSCode] [varchar](50) NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
	[Status] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_TimeSlot] PRIMARY KEY CLUSTERED 
(
	[TSId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Course] ON 
GO
INSERT [dbo].[tbl_Course] ([CourseId], [CourseCode], [CourseName], [CourseShortName]) VALUES (1006, N'E1001', N'Interactive Design and Multimedia', N'IDAM')
GO
INSERT [dbo].[tbl_Course] ([CourseId], [CourseCode], [CourseName], [CourseShortName]) VALUES (1008, N'CS1002', N'Digital Media & Enterpreneurship', N'DME')
GO
INSERT [dbo].[tbl_Course] ([CourseId], [CourseCode], [CourseName], [CourseShortName]) VALUES (3001, N'CS222', N'Data Communication & Computer Networks', N'DCCN')
GO
INSERT [dbo].[tbl_Course] ([CourseId], [CourseCode], [CourseName], [CourseShortName]) VALUES (4002, N'SE319', N'Web Engineering', N'WE')
GO
SET IDENTITY_INSERT [dbo].[tbl_Course] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_TimeSlot] ON 
GO
INSERT [dbo].[tbl_TimeSlot] ([TSId], [TSCode], [StartTime], [EndTime], [Status]) VALUES (1, N'M101', CAST(N'13:30:00' AS Time), CAST(N'14:30:00' AS Time), N'Postpond')
GO
INSERT [dbo].[tbl_TimeSlot] ([TSId], [TSCode], [StartTime], [EndTime], [Status]) VALUES (2, N'E001', CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'Postpond')
GO
SET IDENTITY_INSERT [dbo].[tbl_TimeSlot] OFF
GO
/****** Object:  StoredProcedure [dbo].[Course_Delete]    Script Date: 1/21/2023 10:15:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Course_Delete]
@CourseId INT

AS
BEGIN
	DELETE FROM tbl_course
	WHERE CourseId = @CourseId
END;
GO
/****** Object:  StoredProcedure [dbo].[Course_Edit]    Script Date: 1/21/2023 10:15:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Course_Edit]
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

GO
/****** Object:  StoredProcedure [dbo].[Course_GetAll]    Script Date: 1/21/2023 10:15:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Course_GetAll]
AS
BEGIN 
	SELECT * FROM tbl_course
END;

GO
/****** Object:  StoredProcedure [dbo].[Course_Save]    Script Date: 1/21/2023 10:15:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Course_Save]
@ParamTable1 VARCHAR(10),
@ParamTable2 VARCHAR(150),
@ParamTable3 VARCHAR(150)

AS
	BEGIN
	INSERT INTO tbl_course
	VALUES (@ParamTable1,@ParamTable2,@ParamTable3)
END;

GO
/****** Object:  StoredProcedure [dbo].[TimeSlot_Delete]    Script Date: 1/21/2023 10:15:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TimeSlot_Delete]
@TimeSlotId INT

AS
BEGIN
	DELETE FROM tbl_TimeSlot
	WHERE TSId =  @TimeSlotId
END;


GO
/****** Object:  StoredProcedure [dbo].[TimeSlot_Edit]    Script Date: 1/21/2023 10:15:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TimeSlot_Edit]
@TimeSlotId INT,
@TSCode VARCHAR(50),
@StartTime time,
@EndTime time,
@Status varchar(50)

AS
BEGIN
    UPDATE  tbl_TimeSlot
    SET TSCode = @TSCode, StartTime = @StartTime, EndTime = @EndTime,Status=@Status
    WHERE TSId = @TimeSlotId
END;

GO
/****** Object:  StoredProcedure [dbo].[TimeSlot_GetAll]    Script Date: 1/21/2023 10:15:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[TimeSlot_GetAll]
AS
BEGIN 
	SELECT * FROM tbl_TimeSlot
END;

GO
/****** Object:  StoredProcedure [dbo].[TimeSlot_Save]    Script Date: 1/21/2023 10:15:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[TimeSlot_Save]
@ParamTable1 VARCHAR(50),
@ParamTable2 time,
@ParamTable3 time,
@ParamTable4 varchar(50)

AS
	BEGIN
	INSERT INTO tbl_TimeSlot
	VALUES (@ParamTable1,@ParamTable2,@ParamTable3,@ParamTable4)
END;

GO
USE [master]
GO
ALTER DATABASE [InstituteAttendenceSystem] SET  READ_WRITE 
GO
