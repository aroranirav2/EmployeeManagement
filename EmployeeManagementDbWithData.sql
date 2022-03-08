USE [master]
GO
/****** Object:  Database [EmployeeSystem]    Script Date: 3/8/2022 2:21:00 PM ******/
CREATE DATABASE [EmployeeSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmployeeSystem', FILENAME = N'/var/opt/mssql/data/EmployeeSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmployeeSystem_log', FILENAME = N'/var/opt/mssql/data/EmployeeSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EmployeeSystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeeSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmployeeSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmployeeSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmployeeSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmployeeSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmployeeSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmployeeSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmployeeSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmployeeSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeeSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmployeeSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmployeeSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmployeeSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmployeeSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmployeeSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmployeeSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmployeeSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmployeeSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmployeeSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmployeeSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmployeeSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmployeeSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmployeeSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmployeeSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [EmployeeSystem] SET  MULTI_USER 
GO
ALTER DATABASE [EmployeeSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmployeeSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmployeeSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmployeeSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmployeeSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmployeeSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EmployeeSystem', N'ON'
GO
ALTER DATABASE [EmployeeSystem] SET QUERY_STORE = OFF
GO
USE [EmployeeSystem]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 3/8/2022 2:21:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressId] [uniqueidentifier] NOT NULL,
	[EmployeeId] [uniqueidentifier] NULL,
	[StreetAddress] [nvarchar](max) NOT NULL,
	[SecondLine] [nvarchar](max) NULL,
	[City] [nvarchar](50) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[ZipCode] [nvarchar](6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 3/8/2022 2:21:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [uniqueidentifier] NOT NULL,
	[DepartmentName] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 3/8/2022 2:21:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DepartmentId] [uniqueidentifier] NULL,
	[Gender] [nvarchar](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phone]    Script Date: 3/8/2022 2:21:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phone](
	[PhoneId] [uniqueidentifier] NOT NULL,
	[EmployeeId] [uniqueidentifier] NULL,
	[PhoneNumber] [nvarchar](11) NOT NULL,
	[PhoneType] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PhoneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (N'd46c9a7a-66f6-452e-501a-08d93d60a82d', N'Accounting')
GO
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (N'39ee9d5a-05ec-4dfc-ebd2-08d9e734ffe4', N'Management')
GO
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (N'd84dc3fc-49b9-4754-b500-08da007cd463', N'Human Resources')
GO
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (N'1043573e-0ade-4323-9df8-144237dd57ea', N'Engineering')
GO
INSERT [dbo].[Employee] ([EmployeeId], [FirstName], [LastName], [DepartmentId], [Gender]) VALUES (N'16973d71-cabf-43f9-ecd7-08da007cd45c', N'Amber', N'Nungesser', N'd84dc3fc-49b9-4754-b500-08da007cd463', N'F')
GO
INSERT [dbo].[Employee] ([EmployeeId], [FirstName], [LastName], [DepartmentId], [Gender]) VALUES (N'f4ab45b4-5e0e-4eef-b75f-08da0084ceba', N'Matthew', N'Robidoux', N'1043573e-0ade-4323-9df8-144237dd57ea', N'M')
GO
INSERT [dbo].[Employee] ([EmployeeId], [FirstName], [LastName], [DepartmentId], [Gender]) VALUES (N'1cbec334-de73-43ef-aaaa-158454fd5633', N'Nirav', N'Arora', N'1043573e-0ade-4323-9df8-144237dd57ea', N'M')
GO
INSERT [dbo].[Employee] ([EmployeeId], [FirstName], [LastName], [DepartmentId], [Gender]) VALUES (N'57b5a51f-6184-43ca-a5ea-456e0d95f8cd', N'Eric', N'Hepler', N'1043573e-0ade-4323-9df8-144237dd57ea', N'M')
GO
INSERT [dbo].[Phone] ([PhoneId], [EmployeeId], [PhoneNumber], [PhoneType]) VALUES (N'019de2c2-9be5-4b07-9029-debb3b525aaf', N'1cbec334-de73-43ef-aaaa-158454fd5633', N'9176222019', N'Mobile')
GO
ALTER TABLE [dbo].[Address] ADD  DEFAULT (newid()) FOR [AddressId]
GO
ALTER TABLE [dbo].[Department] ADD  DEFAULT (newid()) FOR [DepartmentId]
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT (newid()) FOR [EmployeeId]
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT ('M') FOR [Gender]
GO
ALTER TABLE [dbo].[Phone] ADD  DEFAULT (newid()) FOR [PhoneId]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Phone]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [check_gender] CHECK  (([Gender]='O' OR [Gender]='F' OR [Gender]='M'))
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [check_gender]
GO
ALTER TABLE [dbo].[Phone]  WITH CHECK ADD  CONSTRAINT [check_phone_type] CHECK  (([PhoneType]='Other' OR [PhoneType]='Home' OR [PhoneType]='Office' OR [PhoneType]='Mobile'))
GO
ALTER TABLE [dbo].[Phone] CHECK CONSTRAINT [check_phone_type]
GO
USE [master]
GO
ALTER DATABASE [EmployeeSystem] SET  READ_WRITE 
GO
