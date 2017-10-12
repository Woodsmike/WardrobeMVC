USE [master]
GO
/****** Object:  Database [MVCWardrobe]    Script Date: 8/7/2017 12:12:41 AM ******/
CREATE DATABASE [MVCWardrobe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MVCWardrobe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\MVCWardrobe.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MVCWardrobe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\MVCWardrobe_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MVCWardrobe] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MVCWardrobe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MVCWardrobe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MVCWardrobe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MVCWardrobe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MVCWardrobe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MVCWardrobe] SET ARITHABORT OFF 
GO
ALTER DATABASE [MVCWardrobe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MVCWardrobe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MVCWardrobe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MVCWardrobe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MVCWardrobe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MVCWardrobe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MVCWardrobe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MVCWardrobe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MVCWardrobe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MVCWardrobe] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MVCWardrobe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MVCWardrobe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MVCWardrobe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MVCWardrobe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MVCWardrobe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MVCWardrobe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MVCWardrobe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MVCWardrobe] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MVCWardrobe] SET  MULTI_USER 
GO
ALTER DATABASE [MVCWardrobe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MVCWardrobe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MVCWardrobe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MVCWardrobe] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MVCWardrobe] SET DELAYED_DURABILITY = DISABLED 
GO
USE [MVCWardrobe]
GO
/****** Object:  Table [dbo].[FormalAccessory]    Script Date: 8/7/2017 12:12:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormalAccessory](
	[FormalAccessoryID] [int] IDENTITY(1,1) NOT NULL,
	[FormalAccessoryName] [nvarchar](50) NOT NULL,
	[FormalAccessoryPhoto] [nvarchar](500) NOT NULL,
	[FormalAccessoryColor] [nvarchar](50) NOT NULL,
	[FormalAccessorySeason] [nvarchar](50) NULL,
	[FormalAccessoryOccasion] [nvarchar](50) NULL,
	[FormalAccessoryType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_FormalAccessory] PRIMARY KEY CLUSTERED 
(
	[FormalAccessoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FormalBottom]    Script Date: 8/7/2017 12:12:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormalBottom](
	[FormalBottomID] [int] IDENTITY(1,1) NOT NULL,
	[FormalBottomName] [nvarchar](50) NOT NULL,
	[FormalBottomPhoto] [nvarchar](500) NOT NULL,
	[FormalBottomColor] [nvarchar](50) NOT NULL,
	[FormalBottomSeason] [nvarchar](50) NULL,
	[FormalBottomOccasion] [nvarchar](50) NULL,
	[FormalBottomType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_FormalBottom] PRIMARY KEY CLUSTERED 
(
	[FormalBottomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FormalOutfit]    Script Date: 8/7/2017 12:12:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormalOutfit](
	[FormalOutfitID] [int] IDENTITY(1,1) NOT NULL,
	[MainOutfitID] [int] NOT NULL,
	[FormalTopID] [int] NOT NULL,
	[FormalBottomID] [int] NOT NULL,
	[FormalShoesID] [int] NOT NULL,
	[FormalAccessoryID] [int] NOT NULL,
 CONSTRAINT [PK_FormalOutfit] PRIMARY KEY CLUSTERED 
(
	[FormalOutfitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FormalShoes]    Script Date: 8/7/2017 12:12:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormalShoes](
	[FormalShoesID] [int] IDENTITY(1,1) NOT NULL,
	[FormalShoesName] [nvarchar](50) NOT NULL,
	[FormalShoesPhoto] [nvarchar](500) NOT NULL,
	[FormalShoesColor] [nvarchar](50) NOT NULL,
	[FormalShoesSeason] [nvarchar](50) NULL,
	[FormalShoesOccasion] [nvarchar](50) NULL,
	[FormalShoesType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_FormalShoes] PRIMARY KEY CLUSTERED 
(
	[FormalShoesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FormalTop]    Script Date: 8/7/2017 12:12:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormalTop](
	[FormalTopID] [int] IDENTITY(1,1) NOT NULL,
	[FormalTopName] [nvarchar](50) NOT NULL,
	[FormalTopPhoto] [nvarchar](500) NOT NULL,
	[FormalTopColor] [nvarchar](50) NOT NULL,
	[FormalTopSeason] [nvarchar](50) NULL,
	[FormalTopOccasion] [nvarchar](50) NULL,
	[FormalTopType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_FormalTop] PRIMARY KEY CLUSTERED 
(
	[FormalTopID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InformalAccessory]    Script Date: 8/7/2017 12:12:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InformalAccessory](
	[InformalAccessoryID] [int] IDENTITY(1,1) NOT NULL,
	[InformalAccessoryName] [nvarchar](50) NOT NULL,
	[InformalAccessoryPhoto] [nvarchar](500) NOT NULL,
	[InformalAccessoryColor] [nvarchar](50) NOT NULL,
	[InformalAccessorySeason] [nvarchar](50) NULL,
	[InformalAccessoryOccasion] [nvarchar](50) NULL,
	[InformalAccessoryType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_InformalAccessory] PRIMARY KEY CLUSTERED 
(
	[InformalAccessoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InformalBottom]    Script Date: 8/7/2017 12:12:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InformalBottom](
	[InformalBottomID] [int] IDENTITY(1,1) NOT NULL,
	[InformalBottomName] [nvarchar](50) NOT NULL,
	[InformalBottomPhoto] [nvarchar](500) NOT NULL,
	[InformalBottomColor] [nvarchar](50) NOT NULL,
	[InformalBottomSeason] [nvarchar](50) NULL,
	[InformalBottomOccasion] [nvarchar](50) NULL,
	[InformalBottomType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_InformalBottom] PRIMARY KEY CLUSTERED 
(
	[InformalBottomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InformalOutfit]    Script Date: 8/7/2017 12:12:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InformalOutfit](
	[InformalOutfitID] [int] IDENTITY(1,1) NOT NULL,
	[MainOutfitID] [int] NOT NULL,
	[InformalTopID] [int] NOT NULL,
	[InformalBottomID] [int] NOT NULL,
	[InformalShoesID] [int] NOT NULL,
	[InformalAccessoryID] [int] NOT NULL,
 CONSTRAINT [PK_InformalOutfit] PRIMARY KEY CLUSTERED 
(
	[InformalOutfitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InformalShoes]    Script Date: 8/7/2017 12:12:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InformalShoes](
	[InformalShoesID] [int] IDENTITY(1,1) NOT NULL,
	[InformalShoesName] [nvarchar](50) NOT NULL,
	[InformalShoesPhoto] [nvarchar](500) NOT NULL,
	[InformalShoesColor] [nvarchar](50) NOT NULL,
	[InformalShoesSeason] [nvarchar](50) NULL,
	[InformalShoesOccasion] [nvarchar](50) NULL,
	[InformalShoesType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_InformalShoes] PRIMARY KEY CLUSTERED 
(
	[InformalShoesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InformalTop]    Script Date: 8/7/2017 12:12:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InformalTop](
	[InformalTopID] [int] IDENTITY(1,1) NOT NULL,
	[InformalTopName] [nvarchar](50) NOT NULL,
	[InformalTopPhoto] [nvarchar](500) NOT NULL,
	[InformalTopColor] [nvarchar](50) NOT NULL,
	[InformalTopSeason] [nvarchar](50) NULL,
	[InformalTopOccasion] [nvarchar](50) NULL,
	[InformalTopType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_InformalTop] PRIMARY KEY CLUSTERED 
(
	[InformalTopID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeisureAccessory]    Script Date: 8/7/2017 12:12:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeisureAccessory](
	[LeisureAccessoryID] [int] IDENTITY(1,1) NOT NULL,
	[LeisureAccessoryName] [nvarchar](50) NOT NULL,
	[LeisureAccessoryPhoto] [nvarchar](500) NOT NULL,
	[LeisureAccessoryColor] [nvarchar](50) NOT NULL,
	[LeisureAccessorySeason] [nvarchar](50) NULL,
	[LeisureAccessoryOccasion] [nvarchar](50) NULL,
	[LeisureAccessoryType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LeisureAccessory] PRIMARY KEY CLUSTERED 
(
	[LeisureAccessoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeisureBottom]    Script Date: 8/7/2017 12:12:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeisureBottom](
	[LeisureBottomID] [int] IDENTITY(1,1) NOT NULL,
	[LeisureBottomName] [nvarchar](50) NOT NULL,
	[LeisureBottomPhoto] [nvarchar](500) NOT NULL,
	[LeisureBottomColor] [nvarchar](50) NOT NULL,
	[LeisureBottomSeason] [nvarchar](50) NULL,
	[LeisureBottomOccasion] [nvarchar](50) NULL,
	[LeisureBottomType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LeisureBottom] PRIMARY KEY CLUSTERED 
(
	[LeisureBottomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeisureOutfit]    Script Date: 8/7/2017 12:12:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeisureOutfit](
	[LeisureOutfitID] [int] IDENTITY(1,1) NOT NULL,
	[MainOutfitID] [int] NOT NULL,
	[LeisureTopID] [int] NOT NULL,
	[LeisureBottomID] [int] NOT NULL,
	[LeisureShoesID] [int] NOT NULL,
	[LeisureAccessoryID] [int] NOT NULL,
 CONSTRAINT [PK_LeisureOutfit] PRIMARY KEY CLUSTERED 
(
	[LeisureOutfitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeisureShoes]    Script Date: 8/7/2017 12:12:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeisureShoes](
	[LeisureShoesID] [int] IDENTITY(1,1) NOT NULL,
	[LeisureShoesName] [nvarchar](50) NOT NULL,
	[LeisureShoesPhoto] [nvarchar](500) NOT NULL,
	[LeisureShoesColor] [nvarchar](50) NOT NULL,
	[LeisureShoesSeason] [nvarchar](50) NULL,
	[LeisureShoesOccasion] [nvarchar](50) NULL,
	[LeisureShoesType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LeisureShoes] PRIMARY KEY CLUSTERED 
(
	[LeisureShoesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeisureTop]    Script Date: 8/7/2017 12:12:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeisureTop](
	[LeisureTopID] [int] IDENTITY(1,1) NOT NULL,
	[LeisureTopName] [nvarchar](50) NOT NULL,
	[LeisureTopPhoto] [nvarchar](500) NOT NULL,
	[LeisureTopColor] [nvarchar](50) NOT NULL,
	[LeisureTopSeason] [nvarchar](50) NULL,
	[LeisureTopOccasion] [nvarchar](50) NULL,
	[LeisureTopType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LeisureTop] PRIMARY KEY CLUSTERED 
(
	[LeisureTopID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Outfit]    Script Date: 8/7/2017 12:12:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Outfit](
	[MainOutfitID] [int] IDENTITY(1,1) NOT NULL,
	[OutfitName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Outfit] PRIMARY KEY CLUSTERED 
(
	[MainOutfitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkAccessory]    Script Date: 8/7/2017 12:12:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkAccessory](
	[WorkAccessoryID] [int] IDENTITY(1,1) NOT NULL,
	[WorkAccessoryName] [nvarchar](50) NOT NULL,
	[WorkAccessoryPhoto] [nvarchar](500) NOT NULL,
	[WorkAccessoryColor] [nvarchar](50) NOT NULL,
	[WorkAccessorySeason] [nvarchar](50) NULL,
	[WorkAccessoryOccasion] [nvarchar](50) NULL,
	[WorkAccessoryType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_WorkAccessory] PRIMARY KEY CLUSTERED 
(
	[WorkAccessoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkBottom]    Script Date: 8/7/2017 12:12:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkBottom](
	[WorkBottomID] [int] IDENTITY(1,1) NOT NULL,
	[WorkBottomName] [nvarchar](50) NOT NULL,
	[WorkBottomPhoto] [nvarchar](500) NOT NULL,
	[WorkBottomColor] [nvarchar](50) NOT NULL,
	[WorkBottomSeason] [nvarchar](50) NULL,
	[WorkBottomOccasion] [nvarchar](50) NULL,
	[WorkBottomType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_WorkBottom] PRIMARY KEY CLUSTERED 
(
	[WorkBottomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkOutfit]    Script Date: 8/7/2017 12:12:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkOutfit](
	[WorkOutfitID] [int] IDENTITY(1,1) NOT NULL,
	[MainOutfitID] [int] NOT NULL,
	[WorkTopID] [int] NOT NULL,
	[WorkBottomID] [int] NOT NULL,
	[WorkShoesID] [int] NOT NULL,
	[WorkAccessoryID] [int] NOT NULL,
 CONSTRAINT [PK_WorkOutfit] PRIMARY KEY CLUSTERED 
(
	[WorkOutfitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkShoes]    Script Date: 8/7/2017 12:12:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkShoes](
	[WorkShoesID] [int] IDENTITY(1,1) NOT NULL,
	[WorkShoesName] [nvarchar](50) NOT NULL,
	[WorkShoesPhoto] [nvarchar](500) NOT NULL,
	[WorkShoesColor] [nvarchar](50) NOT NULL,
	[WorkShoesSeason] [nvarchar](50) NULL,
	[WorkShoesOccasion] [nvarchar](50) NULL,
	[WorkShoesType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_WorkShoes] PRIMARY KEY CLUSTERED 
(
	[WorkShoesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkTop]    Script Date: 8/7/2017 12:12:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkTop](
	[WorkTopID] [int] IDENTITY(1,1) NOT NULL,
	[WorkTopName] [nvarchar](50) NOT NULL,
	[WorkTopPhoto] [nvarchar](500) NOT NULL,
	[WorkTopColor] [nvarchar](50) NOT NULL,
	[WorkTopSeason] [nvarchar](50) NULL,
	[WorkTopOccasion] [nvarchar](50) NULL,
	[WorkTopType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_WorkTop] PRIMARY KEY CLUSTERED 
(
	[WorkTopID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[FormalAccessory] ON 

INSERT [dbo].[FormalAccessory] ([FormalAccessoryID], [FormalAccessoryName], [FormalAccessoryPhoto], [FormalAccessoryColor], [FormalAccessorySeason], [FormalAccessoryOccasion], [FormalAccessoryType]) VALUES (1, N'Rolex', N'~/Content/Images/watchAccessory.jpg', N'Platinum', N'no', N'Black Tie', N'Formal')
SET IDENTITY_INSERT [dbo].[FormalAccessory] OFF
SET IDENTITY_INSERT [dbo].[FormalBottom] ON 

INSERT [dbo].[FormalBottom] ([FormalBottomID], [FormalBottomName], [FormalBottomPhoto], [FormalBottomColor], [FormalBottomSeason], [FormalBottomOccasion], [FormalBottomType]) VALUES (1, N'Burberry Modern', N'~/Content/Images/TuxedoSlacks.jpg', N'Black/White', N'No', N'Black Tie', N'Formal')
SET IDENTITY_INSERT [dbo].[FormalBottom] OFF
SET IDENTITY_INSERT [dbo].[FormalOutfit] ON 

INSERT [dbo].[FormalOutfit] ([FormalOutfitID], [MainOutfitID], [FormalTopID], [FormalBottomID], [FormalShoesID], [FormalAccessoryID]) VALUES (1, 7, 1, 1, 1, 1)
INSERT [dbo].[FormalOutfit] ([FormalOutfitID], [MainOutfitID], [FormalTopID], [FormalBottomID], [FormalShoesID], [FormalAccessoryID]) VALUES (2, 5, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[FormalOutfit] OFF
SET IDENTITY_INSERT [dbo].[FormalShoes] ON 

INSERT [dbo].[FormalShoes] ([FormalShoesID], [FormalShoesName], [FormalShoesPhoto], [FormalShoesColor], [FormalShoesSeason], [FormalShoesOccasion], [FormalShoesType]) VALUES (1, N'Hugo Boss', N'~/Content/Images/TuxedoShoes.jpg', N'Black', N'No', N'Black Tie', N'Formal')
SET IDENTITY_INSERT [dbo].[FormalShoes] OFF
SET IDENTITY_INSERT [dbo].[FormalTop] ON 

INSERT [dbo].[FormalTop] ([FormalTopID], [FormalTopName], [FormalTopPhoto], [FormalTopColor], [FormalTopSeason], [FormalTopOccasion], [FormalTopType]) VALUES (1, N'Burberry Modern', N'~/Content/Images/TuxedoCoat.jpg', N'Black/White', N'No', N'Black Tie', N'Formal')
SET IDENTITY_INSERT [dbo].[FormalTop] OFF
SET IDENTITY_INSERT [dbo].[InformalAccessory] ON 

INSERT [dbo].[InformalAccessory] ([InformalAccessoryID], [InformalAccessoryName], [InformalAccessoryPhoto], [InformalAccessoryColor], [InformalAccessorySeason], [InformalAccessoryOccasion], [InformalAccessoryType]) VALUES (1, N'Watch', N'~/Content/Images/beltAccessory.jpg', N'Brown', N'Yes', N'no', N'Informal')
INSERT [dbo].[InformalAccessory] ([InformalAccessoryID], [InformalAccessoryName], [InformalAccessoryPhoto], [InformalAccessoryColor], [InformalAccessorySeason], [InformalAccessoryOccasion], [InformalAccessoryType]) VALUES (2, N'Michael Kors Belt', N'~/Content/Images/beltAccessory.jpg', N'Brown', N'No', N'No', N'Informal')
SET IDENTITY_INSERT [dbo].[InformalAccessory] OFF
SET IDENTITY_INSERT [dbo].[InformalBottom] ON 

INSERT [dbo].[InformalBottom] ([InformalBottomID], [InformalBottomName], [InformalBottomPhoto], [InformalBottomColor], [InformalBottomSeason], [InformalBottomOccasion], [InformalBottomType]) VALUES (1, N'Levis Jeans', N'~/Content/Images/jeans.jpg', N'Blue', N'All', N'no', N'Informal')
INSERT [dbo].[InformalBottom] ([InformalBottomID], [InformalBottomName], [InformalBottomPhoto], [InformalBottomColor], [InformalBottomSeason], [InformalBottomOccasion], [InformalBottomType]) VALUES (2, N'Levis Jeans', N'~/Content/Images/jeans.jpg', N'Blue', N'Yes', N'No', N'Informal')
SET IDENTITY_INSERT [dbo].[InformalBottom] OFF
SET IDENTITY_INSERT [dbo].[InformalOutfit] ON 

INSERT [dbo].[InformalOutfit] ([InformalOutfitID], [MainOutfitID], [InformalTopID], [InformalBottomID], [InformalShoesID], [InformalAccessoryID]) VALUES (1, 4, 1, 1, 2, 1)
SET IDENTITY_INSERT [dbo].[InformalOutfit] OFF
SET IDENTITY_INSERT [dbo].[InformalShoes] ON 

INSERT [dbo].[InformalShoes] ([InformalShoesID], [InformalShoesName], [InformalShoesPhoto], [InformalShoesColor], [InformalShoesSeason], [InformalShoesOccasion], [InformalShoesType]) VALUES (1, N'Bass Loafers', N'~/Content/Images/boots.jpg', N'Brown', N'No', N'No', N'Informal')
INSERT [dbo].[InformalShoes] ([InformalShoesID], [InformalShoesName], [InformalShoesPhoto], [InformalShoesColor], [InformalShoesSeason], [InformalShoesOccasion], [InformalShoesType]) VALUES (2, N'Boots', N'~/Content/Images/boots.jpg', N'Brown', N'Winter', N'No', N'Informal')
SET IDENTITY_INSERT [dbo].[InformalShoes] OFF
SET IDENTITY_INSERT [dbo].[InformalTop] ON 

INSERT [dbo].[InformalTop] ([InformalTopID], [InformalTopName], [InformalTopPhoto], [InformalTopColor], [InformalTopSeason], [InformalTopOccasion], [InformalTopType]) VALUES (1, N'Oxford button down', N'~/Content/Images/MensInformalShirt.jpg', N'Blue', N'No', N'no', N'Informal')
SET IDENTITY_INSERT [dbo].[InformalTop] OFF
SET IDENTITY_INSERT [dbo].[LeisureAccessory] ON 

INSERT [dbo].[LeisureAccessory] ([LeisureAccessoryID], [LeisureAccessoryName], [LeisureAccessoryPhoto], [LeisureAccessoryColor], [LeisureAccessorySeason], [LeisureAccessoryOccasion], [LeisureAccessoryType]) VALUES (1, N'Sports watch', N'~/Content/Images/SunglassesAccessory.jpg', N'Blue', N'All', N'no', N'Leisure')
INSERT [dbo].[LeisureAccessory] ([LeisureAccessoryID], [LeisureAccessoryName], [LeisureAccessoryPhoto], [LeisureAccessoryColor], [LeisureAccessorySeason], [LeisureAccessoryOccasion], [LeisureAccessoryType]) VALUES (2, N'Ray Ban Sunglasses', N'~/Content/Images/SunglassesAccessory.jpg', N'Black', N'Summer', N'no', N'Leisure')
SET IDENTITY_INSERT [dbo].[LeisureAccessory] OFF
SET IDENTITY_INSERT [dbo].[LeisureBottom] ON 

INSERT [dbo].[LeisureBottom] ([LeisureBottomID], [LeisureBottomName], [LeisureBottomPhoto], [LeisureBottomColor], [LeisureBottomSeason], [LeisureBottomOccasion], [LeisureBottomType]) VALUES (1, N'Nike', N'~/Content/Images/athleticbottom.jpg', N'Black', N'Fall', N'yes', N'Leisure')
INSERT [dbo].[LeisureBottom] ([LeisureBottomID], [LeisureBottomName], [LeisureBottomPhoto], [LeisureBottomColor], [LeisureBottomSeason], [LeisureBottomOccasion], [LeisureBottomType]) VALUES (2, N'Nike', N'~/Content/Images/athleticbottom.jpg', N'Blue', N'Winter', N'yes', N'Leisure')
SET IDENTITY_INSERT [dbo].[LeisureBottom] OFF
SET IDENTITY_INSERT [dbo].[LeisureOutfit] ON 

INSERT [dbo].[LeisureOutfit] ([LeisureOutfitID], [MainOutfitID], [LeisureTopID], [LeisureBottomID], [LeisureShoesID], [LeisureAccessoryID]) VALUES (1, 2, 1, 1, 1, 2)
INSERT [dbo].[LeisureOutfit] ([LeisureOutfitID], [MainOutfitID], [LeisureTopID], [LeisureBottomID], [LeisureShoesID], [LeisureAccessoryID]) VALUES (2, 6, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[LeisureOutfit] OFF
SET IDENTITY_INSERT [dbo].[LeisureShoes] ON 

INSERT [dbo].[LeisureShoes] ([LeisureShoesID], [LeisureShoesName], [LeisureShoesPhoto], [LeisureShoesColor], [LeisureShoesSeason], [LeisureShoesOccasion], [LeisureShoesType]) VALUES (1, N'Nike', N'~/Content/Images/tennisshoes.jpg', N'Black', N'All', N'none', N'Leisure')
INSERT [dbo].[LeisureShoes] ([LeisureShoesID], [LeisureShoesName], [LeisureShoesPhoto], [LeisureShoesColor], [LeisureShoesSeason], [LeisureShoesOccasion], [LeisureShoesType]) VALUES (2, N'Nike', N'~/Content/Images/tennisshoes.jpg', N'Blue', N'YES', N'YES', N'Leisure')
SET IDENTITY_INSERT [dbo].[LeisureShoes] OFF
SET IDENTITY_INSERT [dbo].[LeisureTop] ON 

INSERT [dbo].[LeisureTop] ([LeisureTopID], [LeisureTopName], [LeisureTopPhoto], [LeisureTopColor], [LeisureTopSeason], [LeisureTopOccasion], [LeisureTopType]) VALUES (1, N'Tee Shirt', N'~/Content/Images/Athletictop.jpg', N'Blue', N'ALL', NULL, N'Leisure')
SET IDENTITY_INSERT [dbo].[LeisureTop] OFF
SET IDENTITY_INSERT [dbo].[Outfit] ON 

INSERT [dbo].[Outfit] ([MainOutfitID], [OutfitName]) VALUES (1, N'Favorite Formal')
INSERT [dbo].[Outfit] ([MainOutfitID], [OutfitName]) VALUES (2, N'Favorite Leisure')
INSERT [dbo].[Outfit] ([MainOutfitID], [OutfitName]) VALUES (3, N'Favorite Work')
INSERT [dbo].[Outfit] ([MainOutfitID], [OutfitName]) VALUES (4, N'Favorite Informal')
INSERT [dbo].[Outfit] ([MainOutfitID], [OutfitName]) VALUES (5, N'UpBeat Informal')
INSERT [dbo].[Outfit] ([MainOutfitID], [OutfitName]) VALUES (6, N'Ball Game Leisure')
INSERT [dbo].[Outfit] ([MainOutfitID], [OutfitName]) VALUES (7, N'Wedding Formal')
INSERT [dbo].[Outfit] ([MainOutfitID], [OutfitName]) VALUES (8, N'Picnic Leisure')
INSERT [dbo].[Outfit] ([MainOutfitID], [OutfitName]) VALUES (9, N'Formal Dance')
INSERT [dbo].[Outfit] ([MainOutfitID], [OutfitName]) VALUES (10, N'Date Night Informal')
INSERT [dbo].[Outfit] ([MainOutfitID], [OutfitName]) VALUES (11, N'Formal Date Night')
INSERT [dbo].[Outfit] ([MainOutfitID], [OutfitName]) VALUES (12, N'Hiking')
INSERT [dbo].[Outfit] ([MainOutfitID], [OutfitName]) VALUES (13, N'Work Casual')
SET IDENTITY_INSERT [dbo].[Outfit] OFF
SET IDENTITY_INSERT [dbo].[WorkAccessory] ON 

INSERT [dbo].[WorkAccessory] ([WorkAccessoryID], [WorkAccessoryName], [WorkAccessoryPhoto], [WorkAccessoryColor], [WorkAccessorySeason], [WorkAccessoryOccasion], [WorkAccessoryType]) VALUES (1, N'Watch', N'~/Content/Images/watchAccessory.jpg', N'Tan', N'Alll', N'All', N'Work')
INSERT [dbo].[WorkAccessory] ([WorkAccessoryID], [WorkAccessoryName], [WorkAccessoryPhoto], [WorkAccessoryColor], [WorkAccessorySeason], [WorkAccessoryOccasion], [WorkAccessoryType]) VALUES (2, N'Ray Ban Sunglasses', N'~/Content/Images/SunglassesAccessory.jpg', N'black', N'All', N'All', N'Work')
INSERT [dbo].[WorkAccessory] ([WorkAccessoryID], [WorkAccessoryName], [WorkAccessoryPhoto], [WorkAccessoryColor], [WorkAccessorySeason], [WorkAccessoryOccasion], [WorkAccessoryType]) VALUES (3, N'Gucci Sunglasses', N'~/Content/Images/SunglassesAccessory.jpg', N'Brown', N'All', N'All', N'Work')
INSERT [dbo].[WorkAccessory] ([WorkAccessoryID], [WorkAccessoryName], [WorkAccessoryPhoto], [WorkAccessoryColor], [WorkAccessorySeason], [WorkAccessoryOccasion], [WorkAccessoryType]) VALUES (4, N'Michael Kors Belt', N'~/Content/Images/beltAccessory.jpg', N'Brown', NULL, NULL, N'Work')
SET IDENTITY_INSERT [dbo].[WorkAccessory] OFF
SET IDENTITY_INSERT [dbo].[WorkBottom] ON 

INSERT [dbo].[WorkBottom] ([WorkBottomID], [WorkBottomName], [WorkBottomPhoto], [WorkBottomColor], [WorkBottomSeason], [WorkBottomOccasion], [WorkBottomType]) VALUES (6, N'Tommy H slacks', N'~/Content/Images/slacks.jpg', N'Blue', N'All', N'All', N'Work')
INSERT [dbo].[WorkBottom] ([WorkBottomID], [WorkBottomName], [WorkBottomPhoto], [WorkBottomColor], [WorkBottomSeason], [WorkBottomOccasion], [WorkBottomType]) VALUES (7, N'Ralph Loren', N'~/Content/Images/slacks.jpg', N'Black', N'All', N'All', N'Work')
SET IDENTITY_INSERT [dbo].[WorkBottom] OFF
SET IDENTITY_INSERT [dbo].[WorkOutfit] ON 

INSERT [dbo].[WorkOutfit] ([WorkOutfitID], [MainOutfitID], [WorkTopID], [WorkBottomID], [WorkShoesID], [WorkAccessoryID]) VALUES (1, 3, 1, 7, 2, 4)
INSERT [dbo].[WorkOutfit] ([WorkOutfitID], [MainOutfitID], [WorkTopID], [WorkBottomID], [WorkShoesID], [WorkAccessoryID]) VALUES (2, 13, 1, 7, 2, 4)
SET IDENTITY_INSERT [dbo].[WorkOutfit] OFF
SET IDENTITY_INSERT [dbo].[WorkShoes] ON 

INSERT [dbo].[WorkShoes] ([WorkShoesID], [WorkShoesName], [WorkShoesPhoto], [WorkShoesColor], [WorkShoesSeason], [WorkShoesOccasion], [WorkShoesType]) VALUES (1, N'Bass', N'~/Content/Images/MensDressShoes.jpg', N'Brown', N'All', N'All', N'Work')
INSERT [dbo].[WorkShoes] ([WorkShoesID], [WorkShoesName], [WorkShoesPhoto], [WorkShoesColor], [WorkShoesSeason], [WorkShoesOccasion], [WorkShoesType]) VALUES (2, N'Perry Ellis', N'~/Content/Images/MensDressShoes.jpg', N'Black', N'all', N'All', N'Work')
SET IDENTITY_INSERT [dbo].[WorkShoes] OFF
SET IDENTITY_INSERT [dbo].[WorkTop] ON 

INSERT [dbo].[WorkTop] ([WorkTopID], [WorkTopName], [WorkTopPhoto], [WorkTopColor], [WorkTopSeason], [WorkTopOccasion], [WorkTopType]) VALUES (1, N'Van Huesen ', N'~/Content/Images/SuitCoat.jpg', N'Blue', N'All', N'All', N'Work')
INSERT [dbo].[WorkTop] ([WorkTopID], [WorkTopName], [WorkTopPhoto], [WorkTopColor], [WorkTopSeason], [WorkTopOccasion], [WorkTopType]) VALUES (3, N'Clark', N'~/Content/Images/MensInformalShirt.jpg', N'Black', N'All', N'Any', N'Work')
SET IDENTITY_INSERT [dbo].[WorkTop] OFF
ALTER TABLE [dbo].[FormalOutfit]  WITH CHECK ADD  CONSTRAINT [FK_FormalOutfit_FormalAccessory] FOREIGN KEY([FormalAccessoryID])
REFERENCES [dbo].[FormalAccessory] ([FormalAccessoryID])
GO
ALTER TABLE [dbo].[FormalOutfit] CHECK CONSTRAINT [FK_FormalOutfit_FormalAccessory]
GO
ALTER TABLE [dbo].[FormalOutfit]  WITH CHECK ADD  CONSTRAINT [FK_FormalOutfit_FormalBottom] FOREIGN KEY([FormalBottomID])
REFERENCES [dbo].[FormalBottom] ([FormalBottomID])
GO
ALTER TABLE [dbo].[FormalOutfit] CHECK CONSTRAINT [FK_FormalOutfit_FormalBottom]
GO
ALTER TABLE [dbo].[FormalOutfit]  WITH CHECK ADD  CONSTRAINT [FK_FormalOutfit_FormalShoes] FOREIGN KEY([FormalShoesID])
REFERENCES [dbo].[FormalShoes] ([FormalShoesID])
GO
ALTER TABLE [dbo].[FormalOutfit] CHECK CONSTRAINT [FK_FormalOutfit_FormalShoes]
GO
ALTER TABLE [dbo].[FormalOutfit]  WITH CHECK ADD  CONSTRAINT [FK_FormalOutfit_FormalTop] FOREIGN KEY([FormalTopID])
REFERENCES [dbo].[FormalTop] ([FormalTopID])
GO
ALTER TABLE [dbo].[FormalOutfit] CHECK CONSTRAINT [FK_FormalOutfit_FormalTop]
GO
ALTER TABLE [dbo].[FormalOutfit]  WITH CHECK ADD  CONSTRAINT [FK_FormalOutfit_Outfit] FOREIGN KEY([MainOutfitID])
REFERENCES [dbo].[Outfit] ([MainOutfitID])
GO
ALTER TABLE [dbo].[FormalOutfit] CHECK CONSTRAINT [FK_FormalOutfit_Outfit]
GO
ALTER TABLE [dbo].[InformalOutfit]  WITH CHECK ADD  CONSTRAINT [FK_InformalOutfit_InformalAccessory] FOREIGN KEY([InformalAccessoryID])
REFERENCES [dbo].[InformalAccessory] ([InformalAccessoryID])
GO
ALTER TABLE [dbo].[InformalOutfit] CHECK CONSTRAINT [FK_InformalOutfit_InformalAccessory]
GO
ALTER TABLE [dbo].[InformalOutfit]  WITH CHECK ADD  CONSTRAINT [FK_InformalOutfit_InformalBottom] FOREIGN KEY([InformalBottomID])
REFERENCES [dbo].[InformalBottom] ([InformalBottomID])
GO
ALTER TABLE [dbo].[InformalOutfit] CHECK CONSTRAINT [FK_InformalOutfit_InformalBottom]
GO
ALTER TABLE [dbo].[InformalOutfit]  WITH CHECK ADD  CONSTRAINT [FK_InformalOutfit_InformalShoes] FOREIGN KEY([InformalShoesID])
REFERENCES [dbo].[InformalShoes] ([InformalShoesID])
GO
ALTER TABLE [dbo].[InformalOutfit] CHECK CONSTRAINT [FK_InformalOutfit_InformalShoes]
GO
ALTER TABLE [dbo].[InformalOutfit]  WITH CHECK ADD  CONSTRAINT [FK_InformalOutfit_InformalTop] FOREIGN KEY([InformalTopID])
REFERENCES [dbo].[InformalTop] ([InformalTopID])
GO
ALTER TABLE [dbo].[InformalOutfit] CHECK CONSTRAINT [FK_InformalOutfit_InformalTop]
GO
ALTER TABLE [dbo].[InformalOutfit]  WITH CHECK ADD  CONSTRAINT [FK_InformalOutfit_Outfit] FOREIGN KEY([MainOutfitID])
REFERENCES [dbo].[Outfit] ([MainOutfitID])
GO
ALTER TABLE [dbo].[InformalOutfit] CHECK CONSTRAINT [FK_InformalOutfit_Outfit]
GO
ALTER TABLE [dbo].[LeisureOutfit]  WITH CHECK ADD  CONSTRAINT [FK_LeisureOutfit_LeisureAccessory] FOREIGN KEY([LeisureAccessoryID])
REFERENCES [dbo].[LeisureAccessory] ([LeisureAccessoryID])
GO
ALTER TABLE [dbo].[LeisureOutfit] CHECK CONSTRAINT [FK_LeisureOutfit_LeisureAccessory]
GO
ALTER TABLE [dbo].[LeisureOutfit]  WITH CHECK ADD  CONSTRAINT [FK_LeisureOutfit_LeisureBottom] FOREIGN KEY([LeisureBottomID])
REFERENCES [dbo].[LeisureBottom] ([LeisureBottomID])
GO
ALTER TABLE [dbo].[LeisureOutfit] CHECK CONSTRAINT [FK_LeisureOutfit_LeisureBottom]
GO
ALTER TABLE [dbo].[LeisureOutfit]  WITH CHECK ADD  CONSTRAINT [FK_LeisureOutfit_LeisureShoes] FOREIGN KEY([LeisureShoesID])
REFERENCES [dbo].[LeisureShoes] ([LeisureShoesID])
GO
ALTER TABLE [dbo].[LeisureOutfit] CHECK CONSTRAINT [FK_LeisureOutfit_LeisureShoes]
GO
ALTER TABLE [dbo].[LeisureOutfit]  WITH CHECK ADD  CONSTRAINT [FK_LeisureOutfit_LeisureTop] FOREIGN KEY([LeisureTopID])
REFERENCES [dbo].[LeisureTop] ([LeisureTopID])
GO
ALTER TABLE [dbo].[LeisureOutfit] CHECK CONSTRAINT [FK_LeisureOutfit_LeisureTop]
GO
ALTER TABLE [dbo].[LeisureOutfit]  WITH CHECK ADD  CONSTRAINT [FK_LeisureOutfit_Outfit] FOREIGN KEY([MainOutfitID])
REFERENCES [dbo].[Outfit] ([MainOutfitID])
GO
ALTER TABLE [dbo].[LeisureOutfit] CHECK CONSTRAINT [FK_LeisureOutfit_Outfit]
GO
ALTER TABLE [dbo].[WorkOutfit]  WITH CHECK ADD  CONSTRAINT [FK_WorkOutfit_Outfit] FOREIGN KEY([MainOutfitID])
REFERENCES [dbo].[Outfit] ([MainOutfitID])
GO
ALTER TABLE [dbo].[WorkOutfit] CHECK CONSTRAINT [FK_WorkOutfit_Outfit]
GO
ALTER TABLE [dbo].[WorkOutfit]  WITH CHECK ADD  CONSTRAINT [FK_WorkOutfit_WorkAccessory] FOREIGN KEY([WorkAccessoryID])
REFERENCES [dbo].[WorkAccessory] ([WorkAccessoryID])
GO
ALTER TABLE [dbo].[WorkOutfit] CHECK CONSTRAINT [FK_WorkOutfit_WorkAccessory]
GO
ALTER TABLE [dbo].[WorkOutfit]  WITH CHECK ADD  CONSTRAINT [FK_WorkOutfit_WorkBottom] FOREIGN KEY([WorkBottomID])
REFERENCES [dbo].[WorkBottom] ([WorkBottomID])
GO
ALTER TABLE [dbo].[WorkOutfit] CHECK CONSTRAINT [FK_WorkOutfit_WorkBottom]
GO
ALTER TABLE [dbo].[WorkOutfit]  WITH CHECK ADD  CONSTRAINT [FK_WorkOutfit_WorkShoes] FOREIGN KEY([WorkShoesID])
REFERENCES [dbo].[WorkShoes] ([WorkShoesID])
GO
ALTER TABLE [dbo].[WorkOutfit] CHECK CONSTRAINT [FK_WorkOutfit_WorkShoes]
GO
ALTER TABLE [dbo].[WorkOutfit]  WITH CHECK ADD  CONSTRAINT [FK_WorkOutfit_WorkTop] FOREIGN KEY([WorkTopID])
REFERENCES [dbo].[WorkTop] ([WorkTopID])
GO
ALTER TABLE [dbo].[WorkOutfit] CHECK CONSTRAINT [FK_WorkOutfit_WorkTop]
GO
USE [master]
GO
ALTER DATABASE [MVCWardrobe] SET  READ_WRITE 
GO
