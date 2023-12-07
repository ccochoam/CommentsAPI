USE [master]
GO
/****** Object:  Database [PraxedesBD]    Script Date: 7/12/2023 12:31:48 p. m. ******/
CREATE DATABASE [PraxedesBD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PraxedesBD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\PraxedesBD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PraxedesBD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\PraxedesBD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PraxedesBD] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PraxedesBD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PraxedesBD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PraxedesBD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PraxedesBD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PraxedesBD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PraxedesBD] SET ARITHABORT OFF 
GO
ALTER DATABASE [PraxedesBD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PraxedesBD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PraxedesBD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PraxedesBD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PraxedesBD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PraxedesBD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PraxedesBD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PraxedesBD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PraxedesBD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PraxedesBD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PraxedesBD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PraxedesBD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PraxedesBD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PraxedesBD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PraxedesBD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PraxedesBD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PraxedesBD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PraxedesBD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PraxedesBD] SET  MULTI_USER 
GO
ALTER DATABASE [PraxedesBD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PraxedesBD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PraxedesBD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PraxedesBD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PraxedesBD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PraxedesBD] SET QUERY_STORE = OFF
GO
USE [PraxedesBD]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 7/12/2023 12:31:48 p. m. ******/
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
/****** Object:  Table [dbo].[Posts]    Script Date: 7/12/2023 12:31:48 p. m. ******/
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
USE [master]
GO
ALTER DATABASE [PraxedesBD] SET  READ_WRITE 
GO
