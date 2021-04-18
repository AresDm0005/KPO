USE [master]
GO
/****** Object:  Database [SDTreeView]    Script Date: 19.04.2021 1:07:07 ******/
CREATE DATABASE [SDTreeView]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SDTreeView', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SDTreeView.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SDTreeView_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SDTreeView_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SDTreeView] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SDTreeView].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SDTreeView] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SDTreeView] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SDTreeView] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SDTreeView] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SDTreeView] SET ARITHABORT OFF 
GO
ALTER DATABASE [SDTreeView] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SDTreeView] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SDTreeView] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SDTreeView] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SDTreeView] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SDTreeView] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SDTreeView] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SDTreeView] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SDTreeView] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SDTreeView] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SDTreeView] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SDTreeView] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SDTreeView] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SDTreeView] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SDTreeView] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SDTreeView] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SDTreeView] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SDTreeView] SET RECOVERY FULL 
GO
ALTER DATABASE [SDTreeView] SET  MULTI_USER 
GO
ALTER DATABASE [SDTreeView] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SDTreeView] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SDTreeView] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SDTreeView] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SDTreeView] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SDTreeView] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SDTreeView', N'ON'
GO
ALTER DATABASE [SDTreeView] SET QUERY_STORE = OFF
GO
USE [SDTreeView]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 19.04.2021 1:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 19.04.2021 1:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[color] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deals]    Script Date: 19.04.2021 1:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deals](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[client] [int] NOT NULL,
	[date_sign] [date] NOT NULL,
	[cost] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_Deals] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Format]    Script Date: 19.04.2021 1:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Format](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[width] [int] NOT NULL,
	[height] [int] NOT NULL,
 CONSTRAINT [PK_Format] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paper]    Script Date: 19.04.2021 1:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paper](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[density] [int] NOT NULL,
 CONSTRAINT [PK_Paper] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 19.04.2021 1:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[format] [int] NOT NULL,
	[paper] [int] NOT NULL,
	[color] [int] NOT NULL,
	[price] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSales]    Script Date: 19.04.2021 1:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSales](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[deal] [int] NOT NULL,
	[product] [int] NOT NULL,
	[copies] [int] NOT NULL,
	[cost] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_ProductSales] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 19.04.2021 1:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[price] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceSales]    Script Date: 19.04.2021 1:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceSales](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[psale_id] [int] NOT NULL,
	[service] [int] NOT NULL,
	[copies] [int] NOT NULL,
	[cost] [numeric](18, 2) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Deals]  WITH CHECK ADD  CONSTRAINT [FK_Deals_Clients] FOREIGN KEY([client])
REFERENCES [dbo].[Clients] ([id])
GO
ALTER TABLE [dbo].[Deals] CHECK CONSTRAINT [FK_Deals_Clients]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Color] FOREIGN KEY([color])
REFERENCES [dbo].[Color] ([id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Color]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Format] FOREIGN KEY([format])
REFERENCES [dbo].[Format] ([id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Format]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Paper] FOREIGN KEY([paper])
REFERENCES [dbo].[Paper] ([id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Paper]
GO
ALTER TABLE [dbo].[ProductSales]  WITH CHECK ADD  CONSTRAINT [FK_ProductSales_Deals] FOREIGN KEY([deal])
REFERENCES [dbo].[Deals] ([id])
GO
ALTER TABLE [dbo].[ProductSales] CHECK CONSTRAINT [FK_ProductSales_Deals]
GO
ALTER TABLE [dbo].[ProductSales]  WITH CHECK ADD  CONSTRAINT [FK_ProductSales_Products] FOREIGN KEY([product])
REFERENCES [dbo].[Products] ([id])
GO
ALTER TABLE [dbo].[ProductSales] CHECK CONSTRAINT [FK_ProductSales_Products]
GO
ALTER TABLE [dbo].[ServiceSales]  WITH CHECK ADD  CONSTRAINT [FK_ServiceSales_ProductSales] FOREIGN KEY([psale_id])
REFERENCES [dbo].[ProductSales] ([id])
GO
ALTER TABLE [dbo].[ServiceSales] CHECK CONSTRAINT [FK_ServiceSales_ProductSales]
GO
ALTER TABLE [dbo].[ServiceSales]  WITH CHECK ADD  CONSTRAINT [FK_ServiceSales_Services] FOREIGN KEY([service])
REFERENCES [dbo].[Services] ([id])
GO
ALTER TABLE [dbo].[ServiceSales] CHECK CONSTRAINT [FK_ServiceSales_Services]
GO
/****** Object:  StoredProcedure [dbo].[DeleteDeal]    Script Date: 19.04.2021 1:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteDeal] 
	@id int
AS
	DELETE FROM [ServiceSales]
	WHERE [ServiceSales].psale_id 
		IN
		(SELECT [ProductSales].id FROM [ProductSales]
		WHERE [ProductSales].deal = @id)

	DELETE FROM [ProductSales]
	WHERE [ProductSales].deal = @id

	DELETE FROM [Deals] WHERE [Deals].id = @id
GO
/****** Object:  StoredProcedure [dbo].[DeleteProductSale]    Script Date: 19.04.2021 1:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteProductSale]
	@id int
AS
	DELETE FROM [ServiceSales]
	WHERE [ServiceSales].psale_id = @id
		
	DELETE FROM [ProductSales]
	WHERE id = @id
GO
/****** Object:  StoredProcedure [dbo].[DeleteServiceSale]    Script Date: 19.04.2021 1:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteServiceSale]
	@id int
AS
	DELETE FROM [ServiceSales]
	WHERE id = @id
	
GO
/****** Object:  StoredProcedure [dbo].[InsertIntoDeals]    Script Date: 19.04.2021 1:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertIntoDeals] 
	@client int,
	@date_sign date,
	@cost numeric(18, 2)
	
AS
	DECLARE @id int

	INSERT INTO [Deals](client, date_sign, cost)
	VALUES(@client, @date_sign, @cost)

	SET @id = SCOPE_IDENTITY()

	RETURN @id
GO
/****** Object:  StoredProcedure [dbo].[InsertIntoProdSales]    Script Date: 19.04.2021 1:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertIntoProdSales]
	@deal int,
	@product int,
	@copies int,
	@cost numeric(18, 2)
AS
	DECLARE @id int

	INSERT INTO [ProductSales](deal, product, copies, cost)
	VALUES (@deal, @product, @copies, @cost)

	SET @id = SCOPE_IDENTITY()

	RETURN @id
GO
/****** Object:  StoredProcedure [dbo].[InsertIntoServSales]    Script Date: 19.04.2021 1:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertIntoServSales] 
	@psale int,
	@service int,
	@copies int,
	@cost numeric(18, 2)
AS
	DECLARE @id int

	INSERT INTO [ServiceSales](psale_id, service, copies, cost)
	VALUES(@psale, @service, @copies, @cost)

	SET @id = SCOPE_IDENTITY()

	RETURN @id
GO
/****** Object:  StoredProcedure [dbo].[UpdateDealsCost]    Script Date: 19.04.2021 1:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateDealsCost] 
	@id int
AS
	DECLARE @cost numeric(18, 2)

	SET @cost = (SELECT ISNULL(SUM([ProductSales].cost), 0)
		FROM [ProductSales] 
		WHERE deal = @id) 
		+ 
		(SELECT ISNULL(SUM([ServiceSales].cost), 0)
		FROM [ServiceSales] 
		WHERE psale_id IN (SELECT id FROM [ProductSales] WHERE deal = @id))

	UPDATE [Deals]
	SET cost = @cost
	WHERE id = @id
GO
/****** Object:  StoredProcedure [dbo].[UpdateDealsInfo]    Script Date: 19.04.2021 1:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateDealsInfo] 
	@id int,
	@client int,
	@date_sign date	
AS
	UPDATE [Deals]
	SET client = @client,
		date_sign = @date_sign
	WHERE id = @id
GO
/****** Object:  StoredProcedure [dbo].[UpdateProdSales]    Script Date: 19.04.2021 1:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateProdSales]
	@id int,
	@product int,
	@copies int,
	@cost numeric(18,2)
AS
	UPDATE [ProductSales]
	SET product = @product,
		copies = @copies,
		cost = @cost
	WHERE id = @id
GO
/****** Object:  StoredProcedure [dbo].[UpdateServSales]    Script Date: 19.04.2021 1:07:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateServSales]
	@id int,
	@service int,
	@copies int,
	@cost numeric(18,2)
AS
	UPDATE [ServiceSales]
	SET service = @service,
		copies = @copies,
		cost = @cost
	WHERE id = @id
GO
USE [master]
GO
ALTER DATABASE [SDTreeView] SET  READ_WRITE 
GO
