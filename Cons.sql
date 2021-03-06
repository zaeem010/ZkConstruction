USE [Cons]
GO
/****** Object:  Table [dbo].[City]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[id] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Assignchild]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assignchild](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Assignid] [int] NOT NULL,
	[EmployeeAcc] [int] NOT NULL,
	[Designation] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [sql_variant] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountHead]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountHead](
	[id] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[HeadName] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AbsentUser]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AbsentUser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Employeeid] [int] NOT NULL,
	[Proid] [int] NOT NULL,
	[Start] [datetime2](7) NOT NULL,
	[End] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_AbsentUser] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Worksheet]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Worksheet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [nvarchar](max) NULL,
	[Proid] [int] NOT NULL,
	[Siteid] [int] NOT NULL,
	[CompanyName] [nvarchar](max) NULL,
	[SiteAddress] [nvarchar](max) NULL,
	[FloorSide] [nvarchar](max) NULL,
	[ProviderOrderNo] [nvarchar](max) NULL,
	[AccoummodationNo] [nvarchar](max) NULL,
	[EntranceNovi] [nvarchar](max) NULL,
	[EntranceMod] [nvarchar](max) NULL,
	[ClearenceNovi] [nvarchar](max) NULL,
	[ClearenceModi] [nvarchar](max) NULL,
	[BedNovi] [nvarchar](max) NULL,
	[BedMod] [nvarchar](max) NULL,
	[Room1Novi] [nvarchar](max) NULL,
	[Room1Mod] [nvarchar](max) NULL,
	[Room2Novi] [nvarchar](max) NULL,
	[Room2Mod] [nvarchar](max) NULL,
	[CellarNovi] [nvarchar](max) NULL,
	[CellarMod] [nvarchar](max) NULL,
	[CookNovi] [nvarchar](max) NULL,
	[CookMod] [nvarchar](max) NULL,
	[RoomBathNovi] [nvarchar](max) NULL,
	[RoomBathMod] [nvarchar](max) NULL,
	[FirmToiletNovi] [nvarchar](max) NULL,
	[FirmToiletMod] [nvarchar](max) NULL,
	[WCNovi] [nvarchar](max) NULL,
	[WCMod] [nvarchar](max) NULL,
	[Deatil1] [nvarchar](max) NULL,
	[EDL] [nvarchar](max) NULL,
	[LevelCompund] [nvarchar](max) NULL,
	[SILICONE] [nvarchar](max) NULL,
	[WoodPlinth10] [nvarchar](max) NULL,
	[WoodPlinth5] [nvarchar](max) NULL,
 CONSTRAINT [PK_Worksheet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThirdLevel]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThirdLevel](
	[id] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[AccountNo] [float] NOT NULL,
	[Headid] [float] NOT NULL,
	[SubHeadid] [float] NOT NULL,
	[SecondHeadid] [float] NOT NULL,
	[AccountTitle] [nvarchar](max) NULL,
	[AccountType] [nvarchar](max) NULL,
	[Dr] [float] NOT NULL,
	[Cr] [float] NOT NULL,
	[Comid] [float] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubSection]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubSection](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Sectionid] [int] NOT NULL,
	[Name] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STOMaster]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STOMaster](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateOrder] [nvarchar](max) NULL,
	[RequiredDate] [nvarchar](max) NULL,
	[DelieverPerson] [int] NOT NULL,
	[Siteid] [int] NOT NULL,
	[Invid] [int] NOT NULL,
	[Vtype] [nvarchar](max) NULL,
	[GTotal] [decimal](18, 2) NOT NULL,
	[Status] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STODetail]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STODetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Itemid] [int] NOT NULL,
	[itemName] [nvarchar](max) NULL,
	[Qty] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[Invid] [int] NOT NULL,
	[Vtype] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STDMaster]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STDMaster](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateDelivery] [nvarchar](max) NULL,
	[ReciverPerson] [int] NOT NULL,
	[Siteid] [int] NOT NULL,
	[Invid] [int] NOT NULL,
	[Vtype] [nvarchar](max) NULL,
	[GTotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_STDMaster] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STDDetail]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STDDetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Itemid] [int] NOT NULL,
	[itemName] [nvarchar](max) NULL,
	[Qty] [int] NOT NULL,
	[QtyDelievered] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[Invid] [int] NOT NULL,
	[Vtype] [nvarchar](max) NULL,
 CONSTRAINT [PK_STDDetail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SitevisitImage]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SitevisitImage](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Visitid] [int] NOT NULL,
	[Image] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sitevisit]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sitevisit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Projectid] [int] NOT NULL,
	[Siteid] [int] NOT NULL,
	[Surveyor] [int] NOT NULL,
	[Visitid] [int] NOT NULL,
	[Date] [nvarchar](max) NULL,
	[Area] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Site]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Site](
	[id] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Detail] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Section]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Section](
	[id] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Detail] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SecondLevel]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecondLevel](
	[id] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[Headid] [float] NOT NULL,
	[SubHeadid] [float] NOT NULL,
	[AccountNo] [float] NOT NULL,
	[Comid] [float] NOT NULL,
	[AccountTitle] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectAssign]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectAssign](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Projectid] [int] NOT NULL,
	[Secid] [nvarchar](max) NULL,
	[StDate] [nvarchar](max) NULL,
	[EnDate] [nvarchar](max) NULL,
	[SubSecid] [nvarchar](max) NULL,
	[Assignid] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CostPrice] [decimal](18, 2) NOT NULL,
	[SalePrice] [decimal](18, 2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Home]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Home](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[StDate] [nvarchar](max) NULL,
	[HandDate] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[Floor] [nvarchar](max) NULL,
	[Electricity] [nvarchar](max) NULL,
	[Manager] [int] NOT NULL,
	[site] [int] NOT NULL,
	[Proid] [int] NOT NULL,
	[Comid] [int] NOT NULL,
	[Customerid] [int] NOT NULL,
	[Sr] [nvarchar](max) NULL,
	[WorkHours] [nvarchar](max) NULL,
	[FlooringHours] [int] NULL,
	[PaintingHours] [int] NULL,
	[RemainingHours] [int] NULL,
	[StTime] [nvarchar](max) NULL,
	[FlooringRoom] [nvarchar](max) NULL,
	[StdateTimeFlooring] [nvarchar](max) NULL,
	[DelieveryStatus] [nvarchar](max) NULL,
 CONSTRAINT [PK_Home] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FirstLevel]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FirstLevel](
	[id] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[AccountNo] [float] NOT NULL,
	[Headid] [float] NOT NULL,
	[Comid] [float] NOT NULL,
	[AccountTitle] [decimal](18, 0) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EProject]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EProject](
	[id] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[StDate] [nvarchar](max) NULL,
	[HandDate] [nvarchar](max) NULL,
	[Manager] [int] NOT NULL,
	[site] [int] NOT NULL,
	[Proid] [int] NOT NULL,
	[Status] [nvarchar](max) NULL,
	[Comid] [int] NOT NULL,
	[Customerid] [int] NOT NULL,
	[Electricity] [nvarchar](max) NULL,
	[Floor] [nvarchar](max) NULL,
	[Sr] [nvarchar](max) NULL,
	[WorkHours] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EPchild]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EPchild](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Secid] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Proid] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeAttendance]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeAttendance](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EmpCode] [int] NOT NULL,
	[Status] [nvarchar](max) NULL,
	[CheckInOut] [datetime2](7) NOT NULL,
	[Reamark] [nvarchar](max) NULL,
 CONSTRAINT [PK_EmployeeAttendance] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeAssigned]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeAssigned](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Proid] [int] NOT NULL,
	[Employeeid] [int] NOT NULL,
	[Type] [nvarchar](max) NULL,
	[CloseDateTime] [nvarchar](max) NULL,
	[Siteid] [int] NOT NULL,
	[StartDateTime] [nvarchar](max) NULL,
 CONSTRAINT [PK_EmployeeAssigned] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpassignClose]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpassignClose](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Proid] [int] NOT NULL,
	[Employeeid] [int] NOT NULL,
	[Type] [nvarchar](max) NULL,
	[CloseDateTime] [nvarchar](max) NULL,
 CONSTRAINT [PK_EmpassignClose] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documents]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documents](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Proid] [int] NOT NULL,
	[Img] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
 CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DEmployee]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DEmployee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[AccountNo] [float] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Mobile] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Designation] [nvarchar](max) NULL,
	[DOB] [nvarchar](max) NULL,
	[DOJ] [nvarchar](max) NULL,
	[PerHourSalary] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[EnTime] [nvarchar](max) NULL,
	[StTime] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DailySheduleChild]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DailySheduleChild](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Sheduleid] [int] NOT NULL,
	[Sectionid] [int] NOT NULL,
	[Subsectionid] [int] NOT NULL,
	[Employeeid] [int] NOT NULL,
	[Status] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DailyShedule]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DailyShedule](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Projectid] [int] NOT NULL,
	[Siteid] [int] NOT NULL,
	[Date] [nvarchar](max) NULL,
	[Sheduleid] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Mobile] [nvarchar](max) NULL,
	[Tel] [nvarchar](max) NULL,
	[Cnic] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[AccountNo] [float] NOT NULL,
	[State] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contractor]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contractor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[AccountNo] [float] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Mobile] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 07/19/2021 11:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF__EmployeeA__Sitei__5629CD9C]    Script Date: 07/19/2021 11:23:45 ******/
ALTER TABLE [dbo].[EmployeeAssigned] ADD  DEFAULT ((0)) FOR [Siteid]
GO
/****** Object:  Default [DF__EProject__Comid__3E52440B]    Script Date: 07/19/2021 11:23:45 ******/
ALTER TABLE [dbo].[EProject] ADD  DEFAULT ((0)) FOR [Comid]
GO
/****** Object:  Default [DF__EProject__Custom__3F466844]    Script Date: 07/19/2021 11:23:45 ******/
ALTER TABLE [dbo].[EProject] ADD  DEFAULT ((0)) FOR [Customerid]
GO
/****** Object:  Default [DF__Home__FlooringHo__4222D4EF]    Script Date: 07/19/2021 11:23:45 ******/
ALTER TABLE [dbo].[Home] ADD  DEFAULT ((0)) FOR [FlooringHours]
GO
/****** Object:  Default [DF__Home__PaintingHo__4316F928]    Script Date: 07/19/2021 11:23:45 ******/
ALTER TABLE [dbo].[Home] ADD  DEFAULT ((0)) FOR [PaintingHours]
GO
/****** Object:  Default [DF__Home__RemainingH__440B1D61]    Script Date: 07/19/2021 11:23:45 ******/
ALTER TABLE [dbo].[Home] ADD  DEFAULT ((0)) FOR [RemainingHours]
GO
/****** Object:  Default [DF__Home__FlooringRo__44FF419A]    Script Date: 07/19/2021 11:23:45 ******/
ALTER TABLE [dbo].[Home] ADD  DEFAULT (N'None') FOR [FlooringRoom]
GO
