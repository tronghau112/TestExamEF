USE [master]
GO
/****** Object:  Database [TestExam]    Script Date: 8/28/2021 5:16:23 PM ******/
CREATE DATABASE [TestExam]
 CONTAINMENT = NONE
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestExam].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestExam] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestExam] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestExam] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestExam] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestExam] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestExam] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TestExam] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestExam] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestExam] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestExam] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestExam] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestExam] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestExam] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestExam] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestExam] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TestExam] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestExam] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestExam] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestExam] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestExam] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestExam] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TestExam] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestExam] SET RECOVERY FULL 
GO
ALTER DATABASE [TestExam] SET  MULTI_USER 
GO
ALTER DATABASE [TestExam] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestExam] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestExam] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestExam] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TestExam] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TestExam', N'ON'
GO
USE [TestExam]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/28/2021 5:16:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 8/28/2021 5:16:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[UpdatedBy] [int] NULL,
	[Status] [int] NULL,
	[UserId] [int] NOT NULL,
	[ArticleId] [int] NOT NULL,
	[Content] [nvarchar](max) NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 8/28/2021 5:16:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[UpdatedBy] [int] NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210828100847_Initial', N'3.1.18')
GO
SET IDENTITY_INSERT [dbo].[Comment] ON 
GO
INSERT [dbo].[Comment] ([Id], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Status], [UserId], [ArticleId], [Content]) VALUES (1, CAST(N'2021-08-28T17:12:12.7377352' AS DateTime2), 1, NULL, NULL, NULL, 1, 1, N'test cmt 1')
GO
INSERT [dbo].[Comment] ([Id], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Status], [UserId], [ArticleId], [Content]) VALUES (2, CAST(N'2021-08-28T17:12:52.1612371' AS DateTime2), 1, NULL, NULL, NULL, 1, 1, N'test cmt 2')
GO
SET IDENTITY_INSERT [dbo].[Comment] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [UserName], [Email], [FirstName], [LastName], [Status]) VALUES (1, CAST(N'2021-08-28T17:09:37.4566667' AS DateTime2), 0, NULL, NULL, N'haudt', N'tronghau112@gmail.com', N'Hau', N'Dinh', NULL)
GO
INSERT [dbo].[User] ([Id], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [UserName], [Email], [FirstName], [LastName], [Status]) VALUES (2, CAST(N'2021-08-28T17:09:49.5633333' AS DateTime2), 1, NULL, NULL, N'haudt01', N'tronghau112@gmail.com', N'Hau', N'Dinh', NULL)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Comment] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
USE [master]
GO
ALTER DATABASE [TestExam] SET  READ_WRITE 
GO
