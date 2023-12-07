USE [PraxedesBD]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 7/12/2023 12:19:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[PostId] [bigint] NULL,
	[Id] [bigint] NULL,
	[Name] [varchar](200) NULL,
	[Email] [varchar](200) NULL,
	[Body] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 7/12/2023 12:19:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[UserId] [bigint] NULL,
	[Id] [bigint] NULL,
	[Title] [varchar](200) NULL,
	[Body] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
