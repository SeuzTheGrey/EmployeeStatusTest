USE [master]
GO
/****** Object:  Database [StaffStatus]    Script Date: 2019/08/18 23:05:04 ******/
CREATE DATABASE [StaffStatus]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StaffStatus', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\StaffStatus.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StaffStatus_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\StaffStatus_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [StaffStatus] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StaffStatus].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StaffStatus] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StaffStatus] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StaffStatus] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StaffStatus] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StaffStatus] SET ARITHABORT OFF 
GO
ALTER DATABASE [StaffStatus] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StaffStatus] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StaffStatus] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StaffStatus] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StaffStatus] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StaffStatus] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StaffStatus] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StaffStatus] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StaffStatus] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StaffStatus] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StaffStatus] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StaffStatus] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StaffStatus] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StaffStatus] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StaffStatus] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StaffStatus] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StaffStatus] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StaffStatus] SET RECOVERY FULL 
GO
ALTER DATABASE [StaffStatus] SET  MULTI_USER 
GO
ALTER DATABASE [StaffStatus] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StaffStatus] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StaffStatus] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StaffStatus] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StaffStatus] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'StaffStatus', N'ON'
GO
ALTER DATABASE [StaffStatus] SET QUERY_STORE = OFF
GO
USE [StaffStatus]
GO
/****** Object:  Table [dbo].[InOutStatus]    Script Date: 2019/08/18 23:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InOutStatus](
	[InOutStatusID] [int] NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[InOutStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 2019/08/18 23:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[StaffID] [int] NOT NULL,
	[Lastname] [nvarchar](80) NOT NULL,
	[Firstname] [nvarchar](80) NOT NULL,
	[Nickname] [nvarchar](80) NOT NULL,
	[Username] [nvarchar](255) NOT NULL,
	[InOutStatusID] [int] NOT NULL,
	[TelephoneExtension] [nvarchar](50) NOT NULL,
	[FlagDeleted] [bit] NOT NULL,
	[ManagerID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffInOutHistory]    Script Date: 2019/08/18 23:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffInOutHistory](
	[StaffInOutHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[StaffID] [int] NOT NULL,
	[InOutStatusIDOld] [int] NOT NULL,
	[InOutStatusIDNew] [int] NOT NULL,
	[DateChanged] [datetime] NOT NULL,
	[ChangedByStaffID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StaffInOutHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD FOREIGN KEY([InOutStatusID])
REFERENCES [dbo].[InOutStatus] ([InOutStatusID])
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD FOREIGN KEY([ManagerID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[StaffInOutHistory]  WITH CHECK ADD FOREIGN KEY([ChangedByStaffID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[StaffInOutHistory]  WITH CHECK ADD FOREIGN KEY([InOutStatusIDOld])
REFERENCES [dbo].[InOutStatus] ([InOutStatusID])
GO
ALTER TABLE [dbo].[StaffInOutHistory]  WITH CHECK ADD FOREIGN KEY([InOutStatusIDNew])
REFERENCES [dbo].[InOutStatus] ([InOutStatusID])
GO
ALTER TABLE [dbo].[StaffInOutHistory]  WITH CHECK ADD FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmployee]    Script Date: 2019/08/18 23:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DeleteEmployee] @staffID int
as
delete StaffInOutHistory
where StaffID = @staffID
delete Staff
where StaffID = @staffID
GO
/****** Object:  StoredProcedure [dbo].[getEmployeeDetails]    Script Date: 2019/08/18 23:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getEmployeeDetails] @staffID int
as
select * from Staff
where StaffID = @staffID
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeHistory]    Script Date: 2019/08/18 23:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetEmployeeHistory] @StaffID int
as
select Nickname, 
s1.Description 'Status before change' ,
s2.Description 'status after change',
StaffInOutHistory.DateChanged,
StaffInOutHistory.ChangedByStaffID 'Status change by' 
from Staff
inner join StaffInOutHistory on Staff.StaffID = StaffInOutHistory.StaffID
inner join InOutStatus s1 on StaffInOutHistory.InOutStatusIDOld = s1.InOutStatusID
inner join InOutStatus s2 on StaffInOutHistory.InOutStatusIDNew = s2.InOutStatusID
where Staff.StaffID = @StaffID
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeList]    Script Date: 2019/08/18 23:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetEmployeeList]
as
select * from Staff
inner join InOutStatus on Staff.InOutStatusID = InOutStatus.InOutStatusID
order by InOutStatus.Description asc

GO
/****** Object:  StoredProcedure [dbo].[GetEmployees]    Script Date: 2019/08/18 23:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetEmployees]
as
select StaffID, Firstname, Lastname, TelephoneExtension 'Extension',InOutStatus.Description 'Status'
from Staff
inner join InOutStatus on Staff.InOutStatusID = InOutStatus.InOutStatusID
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeStatus]    Script Date: 2019/08/18 23:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[GetEmployeeStatus] @StaffID int
as
select * from Staff
inner join InOutStatus on Staff.InOutStatusID = InOutStatus.InOutStatusID
where Staff.StaffID = @StaffID

GO
/****** Object:  StoredProcedure [dbo].[insertEmployee]    Script Date: 2019/08/18 23:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[insertEmployee] @lastname varchar(80),@firstname varchar(80) ,@nickname varchar(80),@username varchar(80), @inoutstatusID int, @extension varchar(80),@flagDeleted bit, @managerid int,@changedBy int
as
declare
@staffid int = (select count(StaffID) + 1 from Staff)
INSERT INTO Staff
           ([StaffID]
           ,[Lastname]
           ,[Firstname]
           ,[Nickname]
           ,[Username]
           ,[InOutStatusID]
           ,[TelephoneExtension]
           ,[FlagDeleted]
           ,[ManagerID])
     VALUES
           (@staffid
           ,@lastname
           ,@firstname
           ,@nickname
           ,@username
           ,@inoutstatusID
           ,@extension
           ,@flagDeleted
           ,@managerid)
		   INSERT INTO [dbo].[StaffInOutHistory]
           ([StaffID]
           ,[InOutStatusIDOld]
           ,[InOutStatusIDNew]
           ,[DateChanged]
           ,[ChangedByStaffID])
     VALUES
           (@staffid
           ,@inoutstatusID
           ,@inoutstatusID
           ,GETDATE()
           ,@changedBy)
GO
/****** Object:  StoredProcedure [dbo].[Question1point3]    Script Date: 2019/08/18 23:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Question1point3] @StaffID int
as
select * from Staff
inner join InOutStatus on Staff.InOutStatusID = InOutStatus.InOutStatusID
where Staff.StaffID = @StaffID
GO
/****** Object:  StoredProcedure [dbo].[Question1point6]    Script Date: 2019/08/18 23:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Question1point6] @StaffID int
as
select Nickname, 
s1.Description 'Status before change' ,
s2.Description 'status after change',
StaffInOutHistory.DateChanged,
StaffInOutHistory.ChangedByStaffID 'Status change by' 
from Staff
inner join StaffInOutHistory on Staff.StaffID = StaffInOutHistory.StaffID
inner join InOutStatus s1 on StaffInOutHistory.InOutStatusIDOld = s1.InOutStatusID
inner join InOutStatus s2 on StaffInOutHistory.InOutStatusIDNew = s2.InOutStatusID
where Staff.StaffID = @StaffID



exec Question1point6 1
GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployeeDetails]    Script Date: 2019/08/18 23:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateEmployeeDetails] @staffID int ,@Lastname nvarchar(80) ,@firstname nvarchar(80) ,@nickname nvarchar(80), @username nvarchar(80) , @telephoneExtension nvarchar(80), @flagDeleted bit
as
UPDATE [dbo].[Staff]
   SET [Lastname] = @Lastname,[Firstname] = @firstname,[Nickname] = @nickname,[Username] = @username
      ,[TelephoneExtension] = @telephoneExtension,[FlagDeleted] = @flagDeleted
 WHERE StaffID = @staffID
GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployeeStatus]    Script Date: 2019/08/18 23:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateEmployeeStatus] @staffId int, @changedby int, @description int
as
begin
update Staff
set InOutStatusID = @description
where StaffID = @staffId
INSERT INTO [dbo].[StaffInOutHistory]
           ([StaffID]
           ,[InOutStatusIDOld]
           ,[InOutStatusIDNew]
           ,[DateChanged]
           ,[ChangedByStaffID])
     VALUES
           (@staffId
           ,(Select top 1 InOutStatusIDNew from StaffInOutHistory where StaffID = @staffId order by StaffInOutHistoryID desc )
           ,@description
           ,GETDATE()
           ,@changedby)
end
GO
USE [master]
GO
ALTER DATABASE [StaffStatus] SET  READ_WRITE 
GO
