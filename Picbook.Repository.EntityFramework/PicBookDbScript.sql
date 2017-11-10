USE master
GO

IF EXISTS(SELECT name FROM sys.databases WHERE name = 'PicBook')
    DROP DATABASE [PicBook]
GO

CREATE DATABASE [PicBook]
GO

USE [PicBook]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('dbo.Account', 'U') IS NOT NULL 
  DROP TABLE dbo.Account; 
GO
CREATE TABLE [dbo].[Account](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [varchar](24) NOT NULL,
	[Email] [varchar](256) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [varchar](128) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](128) NULL,
	[Deleted] [bit] NOT NULL,
	[MobilNumber] [varchar] (21) NULL,
	[FirstName] [varchar](256) NULL,
	[LastName] [varchar](256) NULL,
	[ProfileImageUrl] [nvarchar](1024) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Account] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (newid()) for [Id]
GO



IF OBJECT_ID('dbo.Album', 'U') IS NOT NULL 
  DROP TABLE dbo.Album; 
GO
CREATE TABLE [dbo].[Album](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [varchar](128) NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](128) NULL,
	[Deleted] [bit] NOT NULL,
	[Name] [nvarchar](512) NOT NULL,
	[Description] [ntext] NULL,
	[AccountID] [uniqueidentifier] NOT NULL,
	CONSTRAINT [FK_Album_Account] FOREIGN KEY (AccountID) REFERENCES [dbo].[Account](Id),
 CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Album] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Album] ADD  DEFAULT (getdate()) FOR [ModifiedDate]
GO


IF OBJECT_ID('dbo.Image', 'U') IS NOT NULL 
  DROP TABLE dbo.Image; 
GO
CREATE TABLE [dbo].[Image](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](512) NOT NULL,
	[OriginalSizeURL] [nvarchar](1024) NOT NULL,
	[WebSizeURL] [nvarchar](1024) NULL,
	[MobileSizeURL] [nvarchar](1024) NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
	[AlbumId] [bigint] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [varchar](128) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](128) NULL,
	[Public] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	CONSTRAINT [FK_Image_Album] FOREIGN KEY (AlbumId) REFERENCES [dbo].[Album](id),
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Image] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Image] ADD  DEFAULT (getdate()) FOR [ModifiedDate]
GO


IF OBJECT_ID('dbo.Rating', 'U') IS NOT NULL 
  DROP TABLE dbo.Rating; 
GO
CREATE TABLE [dbo].[Rating](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [uniqueidentifier] NOT NULL,
	[ImageId] [bigint] NOT NULL,
	[Comment] [ntext] NOT NULL,
	[Value] [float] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [varchar](128) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](128) NULL,
	[Deleted] [bit] NOT NULL,
	CONSTRAINT [FK_Rating_Account] FOREIGN KEY (AccountID) REFERENCES [dbo].[Account](Id),
	CONSTRAINT [FK_Rating_Image] FOREIGN KEY (ImageId) REFERENCES [dbo].[Image](id),
 CONSTRAINT [PK_ProductRating] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Rating] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Rating] ADD  DEFAULT (getdate()) FOR [ModifiedDate]
GO

