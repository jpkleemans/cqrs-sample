USE [master]
GO

/****** Object:  Database [ArbeidsverhoudingBeheer]    Script Date: 29-12-2014 09:07:46 ******/
CREATE DATABASE [ArbeidsverhoudingBeheer]
 CONTAINMENT = NONE
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ArbeidsverhoudingBeheer].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET ARITHABORT OFF 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET  DISABLE_BROKER 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET  MULTI_USER 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET DB_CHAINING OFF 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [ArbeidsverhoudingBeheer] SET  READ_WRITE 
GO

USE [ArbeidsverhoudingBeheer]
GO

/****** Object:  Table [dbo].[Klant]    Script Date: 29-12-2014 09:08:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Arbeidsverhouding](
	[Nummer] [nvarchar](50) NOT NULL,
	[DeelnemerNummer] [nvarchar](50) NOT NULL,
	[WerkgeverNummer] [nvarchar](50) NOT NULL,
	[Ingangsdatum] [datetime2](7) NOT NULL,
	[Einddatum] [datetime2](7) NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[Version] [int] NOT NULL,
 CONSTRAINT [PK_Arbeidsverhouding] PRIMARY KEY CLUSTERED 
(
	[Nummer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [master]
GO

/****** Object:  Login [ArbeidsverhoudingBeheerUser]    Script Date: 29-12-2014 09:12:05 ******/
CREATE LOGIN [ArbeidsverhoudingBeheerUser] WITH PASSWORD=0x0200E9C4DB32F27EBB492448BE076B9088122FA5810F439ED2C27BD0B238E631E36D970E33E75D39CC1CD793E5FC225C981F10B3CEBD25296D8BA3978EEFB6E413EC68377659 HASHED, 
DEFAULT_DATABASE=[ArbeidsverhoudingBeheer], 
DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

USE [ArbeidsverhoudingBeheer]
GO

/****** Object:  User [ArbeidsverhoudingBeheerUser]    Script Date: 29-12-2014 09:13:47 ******/
CREATE USER [ArbeidsverhoudingBeheerUser] FOR LOGIN [ArbeidsverhoudingBeheerUser] WITH DEFAULT_SCHEMA=[dbo]
GO

EXEC sp_addrolemember 'db_owner', 'ArbeidsverhoudingBeheerUser';