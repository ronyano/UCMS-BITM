USE [master]
GO
/****** Object:  Database [UniversityCourseAndResultManagement]    Script Date: 10/23/2017 11:45:07 AM ******/
CREATE DATABASE [UniversityCourseAndResultManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversityCourseAndResultManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\UniversityCourseAndResultManagement.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniversityCourseAndResultManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\UniversityCourseAndResultManagement_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityCourseAndResultManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET  MULTI_USER 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [UniversityCourseAndResultManagement]
GO
/****** Object:  Table [dbo].[AllocateClassroom]    Script Date: 10/23/2017 11:45:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllocateClassroom](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
	[DayId] [int] NOT NULL,
	[FromTime] [time](7) NOT NULL,
	[ToTime] [time](7) NOT NULL,
 CONSTRAINT [PK_AllocateClassroom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Course]    Script Date: 10/23/2017 11:45:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseCode] [varchar](50) NOT NULL,
	[CourseName] [varchar](50) NOT NULL,
	[Description] [varchar](100) NULL,
	[SemesterId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[Credit] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CourseAssignTeacher]    Script Date: 10/23/2017 11:45:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseAssignTeacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_CourseAssignTeacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Day]    Script Date: 10/23/2017 11:45:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Day](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DayName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Day] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 10/23/2017 11:45:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](50) NOT NULL,
	[Code] [varchar](7) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 10/23/2017 11:45:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Designation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DesignationName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EnrollCourse]    Script Date: 10/23/2017 11:45:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnrollCourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[EnrollDate] [date] NOT NULL,
 CONSTRAINT [PK_EnrollCourse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Grade]    Script Date: 10/23/2017 11:45:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GradeLetter] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Grade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Room]    Script Date: 10/23/2017 11:45:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [int] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Semester]    Script Date: 10/23/2017 11:45:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semester](
	[Id] [int] NOT NULL,
	[SemesterNo] [varchar](50) NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student]    Script Date: 10/23/2017 11:45:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[ContactNo] [varchar](11) NOT NULL,
	[RegDate] [date] NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[RegNo] [varchar](12) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 10/23/2017 11:45:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [varchar](50) NOT NULL,
	[Address] [varchar](100) NULL,
	[Email] [varchar](50) NOT NULL,
	[ContactNo] [varchar](11) NOT NULL,
	[DesignationId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CreditToBeTaken] [int] NOT NULL,
	[CreditRemaining] [int] NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AllocateClassroom] ON 

INSERT [dbo].[AllocateClassroom] ([Id], [DepartmentId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime]) VALUES (1, 8, 12, 3, 1, CAST(0x070068C461080000 AS Time), CAST(0x07000236D36C0000 AS Time))
INSERT [dbo].[AllocateClassroom] ([Id], [DepartmentId], [CourseId], [RoomId], [DayId], [FromTime], [ToTime]) VALUES (2, 3, 2, 9, 4, CAST(0x0700A0E3D08C0000 AS Time), CAST(0x0700ECE9EB5B0000 AS Time))
SET IDENTITY_INSERT [dbo].[AllocateClassroom] OFF
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Description], [SemesterId], [DepartmentId], [Credit]) VALUES (2, N'CSE105', N'Structured Programming', N'', 1, 3, 4)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Description], [SemesterId], [DepartmentId], [Credit]) VALUES (3, N'PHY109', N'Engineering Physics I', N'', 3, 3, 4)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Description], [SemesterId], [DepartmentId], [Credit]) VALUES (4, N'CSE107', N'Object Oriented Programming', N'', 2, 3, 4)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Description], [SemesterId], [DepartmentId], [Credit]) VALUES (5, N'CSE322', N'Computer Architecture', N'', 6, 3, 4)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Description], [SemesterId], [DepartmentId], [Credit]) VALUES (10, N'ece100', N'ece100', N'ece100', 1, 9, 3)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Description], [SemesterId], [DepartmentId], [Credit]) VALUES (11, N'ece101', N'ece111', N'ece111', 2, 9, 3)
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Description], [SemesterId], [DepartmentId], [Credit]) VALUES (12, N'EEE100', N'eee100', N'eee100', 1, 8, 3)
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[CourseAssignTeacher] ON 

INSERT [dbo].[CourseAssignTeacher] ([Id], [TeacherId], [DepartmentId], [CourseId]) VALUES (1, 1, 3, 0)
INSERT [dbo].[CourseAssignTeacher] ([Id], [TeacherId], [DepartmentId], [CourseId]) VALUES (2, 1, 3, 0)
INSERT [dbo].[CourseAssignTeacher] ([Id], [TeacherId], [DepartmentId], [CourseId]) VALUES (3, 1, 3, 0)
INSERT [dbo].[CourseAssignTeacher] ([Id], [TeacherId], [DepartmentId], [CourseId]) VALUES (4, 5, 9, 11)
INSERT [dbo].[CourseAssignTeacher] ([Id], [TeacherId], [DepartmentId], [CourseId]) VALUES (5, 5, 9, 10)
INSERT [dbo].[CourseAssignTeacher] ([Id], [TeacherId], [DepartmentId], [CourseId]) VALUES (6, 1, 3, 3)
INSERT [dbo].[CourseAssignTeacher] ([Id], [TeacherId], [DepartmentId], [CourseId]) VALUES (7, 1, 3, 2)
INSERT [dbo].[CourseAssignTeacher] ([Id], [TeacherId], [DepartmentId], [CourseId]) VALUES (8, 1, 3, 3)
INSERT [dbo].[CourseAssignTeacher] ([Id], [TeacherId], [DepartmentId], [CourseId]) VALUES (9, 1, 3, 2)
INSERT [dbo].[CourseAssignTeacher] ([Id], [TeacherId], [DepartmentId], [CourseId]) VALUES (10, 1, 3, 5)
INSERT [dbo].[CourseAssignTeacher] ([Id], [TeacherId], [DepartmentId], [CourseId]) VALUES (1002, 1, 3, 3)
INSERT [dbo].[CourseAssignTeacher] ([Id], [TeacherId], [DepartmentId], [CourseId]) VALUES (1003, 1, 3, 5)
INSERT [dbo].[CourseAssignTeacher] ([Id], [TeacherId], [DepartmentId], [CourseId]) VALUES (1004, 5, 9, 10)
INSERT [dbo].[CourseAssignTeacher] ([Id], [TeacherId], [DepartmentId], [CourseId]) VALUES (1005, 2, 3, 3)
INSERT [dbo].[CourseAssignTeacher] ([Id], [TeacherId], [DepartmentId], [CourseId]) VALUES (1006, 1, 3, 2)
INSERT [dbo].[CourseAssignTeacher] ([Id], [TeacherId], [DepartmentId], [CourseId]) VALUES (1007, 1, 3, 3)
INSERT [dbo].[CourseAssignTeacher] ([Id], [TeacherId], [DepartmentId], [CourseId]) VALUES (1008, 1010, 8, 12)
INSERT [dbo].[CourseAssignTeacher] ([Id], [TeacherId], [DepartmentId], [CourseId]) VALUES (1009, 1010, 8, 12)
SET IDENTITY_INSERT [dbo].[CourseAssignTeacher] OFF
SET IDENTITY_INSERT [dbo].[Day] ON 

INSERT [dbo].[Day] ([Id], [DayName]) VALUES (1, N'Saturday')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (2, N'Sunday')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (3, N'Monday')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (4, N'Tuesday')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (5, N'Wednesday')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (6, N'Thursday')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (7, N'Friday')
SET IDENTITY_INSERT [dbo].[Day] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([Id], [DepartmentName], [Code]) VALUES (3, N'Computer Science & Engineering', N'CSE')
INSERT [dbo].[Department] ([Id], [DepartmentName], [Code]) VALUES (8, N'Electrical & Electronic Engineering', N'EEE')
INSERT [dbo].[Department] ([Id], [DepartmentName], [Code]) VALUES (9, N'Electronic & Communication Engineering', N'ECE')
INSERT [dbo].[Department] ([Id], [DepartmentName], [Code]) VALUES (10, N'Software Engineering', N'SWE')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Designation] ON 

INSERT [dbo].[Designation] ([Id], [DesignationName]) VALUES (1, N'Professor')
INSERT [dbo].[Designation] ([Id], [DesignationName]) VALUES (2, N'Associate Professor')
INSERT [dbo].[Designation] ([Id], [DesignationName]) VALUES (3, N'Assistant Professor')
INSERT [dbo].[Designation] ([Id], [DesignationName]) VALUES (4, N'Senior Lecturer')
INSERT [dbo].[Designation] ([Id], [DesignationName]) VALUES (5, N'Lecturer')
SET IDENTITY_INSERT [dbo].[Designation] OFF
SET IDENTITY_INSERT [dbo].[EnrollCourse] ON 

INSERT [dbo].[EnrollCourse] ([Id], [StudentId], [CourseId], [EnrollDate]) VALUES (1, 0, 0, CAST(0x6E3D0B00 AS Date))
INSERT [dbo].[EnrollCourse] ([Id], [StudentId], [CourseId], [EnrollDate]) VALUES (2, 0, 0, CAST(0x6E3D0B00 AS Date))
INSERT [dbo].[EnrollCourse] ([Id], [StudentId], [CourseId], [EnrollDate]) VALUES (3, 0, 0, CAST(0x6E3D0B00 AS Date))
INSERT [dbo].[EnrollCourse] ([Id], [StudentId], [CourseId], [EnrollDate]) VALUES (4, 0, 0, CAST(0x6E3D0B00 AS Date))
INSERT [dbo].[EnrollCourse] ([Id], [StudentId], [CourseId], [EnrollDate]) VALUES (5, 1002, 4, CAST(0x6E3D0B00 AS Date))
INSERT [dbo].[EnrollCourse] ([Id], [StudentId], [CourseId], [EnrollDate]) VALUES (1002, 1, 12, CAST(0x6F3D0B00 AS Date))
SET IDENTITY_INSERT [dbo].[EnrollCourse] OFF
SET IDENTITY_INSERT [dbo].[Grade] ON 

INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (1, N'A+')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (2, N'A')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (3, N'A-')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (4, N'B+')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (5, N'B')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (6, N'B-')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (7, N'C+')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (8, N'C')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (9, N'C-')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (10, N'D+')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (11, N'D')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (12, N'D-')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (13, N'F')
SET IDENTITY_INSERT [dbo].[Grade] OFF
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (1, 101)
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (2, 102)
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (3, 103)
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (4, 104)
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (5, 105)
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (6, 201)
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (7, 202)
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (8, 203)
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (9, 204)
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (10, 205)
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (11, 301)
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (12, 302)
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (13, 303)
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (14, 304)
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (15, 305)
SET IDENTITY_INSERT [dbo].[Room] OFF
INSERT [dbo].[Semester] ([Id], [SemesterNo]) VALUES (1, N'1st')
INSERT [dbo].[Semester] ([Id], [SemesterNo]) VALUES (2, N'2nd')
INSERT [dbo].[Semester] ([Id], [SemesterNo]) VALUES (3, N'3rd')
INSERT [dbo].[Semester] ([Id], [SemesterNo]) VALUES (4, N'4th')
INSERT [dbo].[Semester] ([Id], [SemesterNo]) VALUES (5, N'5th')
INSERT [dbo].[Semester] ([Id], [SemesterNo]) VALUES (6, N'6th')
INSERT [dbo].[Semester] ([Id], [SemesterNo]) VALUES (7, N'7th')
INSERT [dbo].[Semester] ([Id], [SemesterNo]) VALUES (8, N'8th')
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [StudentName], [Email], [ContactNo], [RegDate], [Address], [DepartmentId], [RegNo]) VALUES (1, N'Student', N's21@1', N'1224', CAST(0x6A3D0B00 AS Date), N'kh', 8, N'EEE-2017-001')
INSERT [dbo].[Student] ([Id], [StudentName], [Email], [ContactNo], [RegDate], [Address], [DepartmentId], [RegNo]) VALUES (2, N'se2', N's@2l', N'990', CAST(0x6A3D0B00 AS Date), N'dfd', 8, N'EEE-2017-002')
INSERT [dbo].[Student] ([Id], [StudentName], [Email], [ContactNo], [RegDate], [Address], [DepartmentId], [RegNo]) VALUES (4, N's@3', N's@3', N'3434', CAST(0xF13B0B00 AS Date), N'2016', 8, N'EEE-2016-001')
INSERT [dbo].[Student] ([Id], [StudentName], [Email], [ContactNo], [RegDate], [Address], [DepartmentId], [RegNo]) VALUES (5, N'st4', N's@4', N'4402', CAST(0x2D390B00 AS Date), N'EEE4', 8, N'EEE-2014-001')
INSERT [dbo].[Student] ([Id], [StudentName], [Email], [ContactNo], [RegDate], [Address], [DepartmentId], [RegNo]) VALUES (1002, N'S1', N's@11', N'11332212345', CAST(0x6E3D0B00 AS Date), N'sdfsdf', 3, N'CSE-2017-001')
INSERT [dbo].[Student] ([Id], [StudentName], [Email], [ContactNo], [RegDate], [Address], [DepartmentId], [RegNo]) VALUES (1003, N's2c', N's@2c', N'33222112321', CAST(0x013C0B00 AS Date), N'df', 3, N'CSE-2016-001')
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([Id], [TeacherName], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [CreditRemaining]) VALUES (1, N'Imtiaz Ahmed', N'', N'imtiaz@gmail.com', N'01521206419', 3, 3, 20, -4)
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [CreditRemaining]) VALUES (2, N't', N't', N't@a', N'1', 1, 3, 10, 6)
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [CreditRemaining]) VALUES (3, N't2', N't2', N't@2', N'2', 1, 3, 9, 9)
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [CreditRemaining]) VALUES (4, N't@3', N'3', N'3@e', N'4', 2, 8, 99, 99)
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [CreditRemaining]) VALUES (5, N'ff', N'ff', N'f@f', N'33', 3, 9, 99, 96)
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [CreditRemaining]) VALUES (6, N'dd', N'dd', N'dd@d', N'44', 5, 10, 66, 66)
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [CreditRemaining]) VALUES (7, N'efdf', N'dfd', N'd@d', N'6', 1, 3, 66, 66)
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [CreditRemaining]) VALUES (8, N'tss', N'tss', N't@sss', N'33434', 5, 10, 13, 0)
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [CreditRemaining]) VALUES (9, N'dfdf', N'dfdf', N'd@sssdfd', N'3333333', 4, 10, 45, 45)
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [CreditRemaining]) VALUES (10, N'sst', N'ttt', N't@dd', N'4433', 4, 10, 43, 43)
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [CreditRemaining]) VALUES (1010, N'Teacher of EEE', N'eee', N'e@1', N'01111111111', 1, 8, 15, 9)
SET IDENTITY_INSERT [dbo].[Teacher] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Course]    Script Date: 10/23/2017 11:45:07 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Course] ON [dbo].[Course]
(
	[CourseCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Course_1]    Script Date: 10/23/2017 11:45:07 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Course_1] ON [dbo].[Course]
(
	[CourseName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Department]    Script Date: 10/23/2017 11:45:07 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Department] ON [dbo].[Department]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Department_1]    Script Date: 10/23/2017 11:45:07 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Department_1] ON [dbo].[Department]
(
	[DepartmentName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Student]    Script Date: 10/23/2017 11:45:07 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Student] ON [dbo].[Student]
(
	[ContactNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Student_1]    Script Date: 10/23/2017 11:45:07 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Student_1] ON [dbo].[Student]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Teacher]    Script Date: 10/23/2017 11:45:07 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Teacher] ON [dbo].[Teacher]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Department]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Semester] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semester] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Semester]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Department]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Department]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Designation] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[Designation] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Designation]
GO
USE [master]
GO
ALTER DATABASE [UniversityCourseAndResultManagement] SET  READ_WRITE 
GO
