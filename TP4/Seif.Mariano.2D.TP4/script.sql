USE [master]
GO
/****** Object:  Database [SeifMariano2dTp4]    Script Date: 22/11/2020 22:01:33 ******/
CREATE DATABASE [SeifMariano2dTp4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SeifMariano2dTp4', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SeifMariano2dTp4.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SeifMariano2dTp4_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SeifMariano2dTp4_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SeifMariano2dTp4] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SeifMariano2dTp4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SeifMariano2dTp4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SeifMariano2dTp4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SeifMariano2dTp4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SeifMariano2dTp4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SeifMariano2dTp4] SET ARITHABORT OFF 
GO
ALTER DATABASE [SeifMariano2dTp4] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SeifMariano2dTp4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SeifMariano2dTp4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SeifMariano2dTp4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SeifMariano2dTp4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SeifMariano2dTp4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SeifMariano2dTp4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SeifMariano2dTp4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SeifMariano2dTp4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SeifMariano2dTp4] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SeifMariano2dTp4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SeifMariano2dTp4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SeifMariano2dTp4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SeifMariano2dTp4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SeifMariano2dTp4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SeifMariano2dTp4] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SeifMariano2dTp4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SeifMariano2dTp4] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SeifMariano2dTp4] SET  MULTI_USER 
GO
ALTER DATABASE [SeifMariano2dTp4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SeifMariano2dTp4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SeifMariano2dTp4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SeifMariano2dTp4] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SeifMariano2dTp4] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SeifMariano2dTp4] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SeifMariano2dTp4] SET QUERY_STORE = OFF
GO
USE [SeifMariano2dTp4]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 22/11/2020 22:01:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemsventa]    Script Date: 22/11/2020 22:01:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itemsventa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idVenta] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[cantidad] [nchar](10) NOT NULL,
 CONSTRAINT [PK_itemsventa] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 22/11/2020 22:01:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [text] NOT NULL,
	[precio] [decimal](10, 2) NOT NULL,
	[stock] [int] NOT NULL,
 CONSTRAINT [PK_productos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ventas]    Script Date: 22/11/2020 22:01:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NOT NULL,
 CONSTRAINT [PK_ventas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[clientes] ON 

INSERT [dbo].[clientes] ([id], [nombre]) VALUES (1, N'Juan Pepe')
INSERT [dbo].[clientes] ([id], [nombre]) VALUES (2, N'Pedro Perez')
INSERT [dbo].[clientes] ([id], [nombre]) VALUES (3, N'Carlos Lopez')
SET IDENTITY_INSERT [dbo].[clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[itemsventa] ON 

INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (1, 1, 103, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (2, 1, 7, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (3, 2, 5, N'2         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (4, 3, 2, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (5, 4, 5, N'2         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (6, 4, 5, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (7, 5, 4, N'2         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (8, 5, 103, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (9, 6, 7, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (10, 7, 5, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (11, 8, 4, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (12, 8, 3, N'2         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (13, 9, 105, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (14, 10, 106, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (15, 10, 103, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (16, 11, 2, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (17, 11, 105, N'2         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (18, 12, 1, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (19, 13, 5, N'2         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (20, 13, 106, N'2         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (21, 14, 103, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (22, 14, 2, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (23, 15, 5, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (24, 16, 4, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (25, 17, 107, N'2         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (26, 18, 107, N'2         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (27, 19, 2, N'2         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (28, 20, 103, N'2         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (29, 20, 106, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (30, 21, 2, N'2         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (31, 22, 108, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (32, 23, 3, N'2         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (33, 23, 3, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (34, 24, 2, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (35, 25, 105, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (36, 26, 5, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (37, 26, 106, N'2         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (38, 27, 106, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (39, 27, 3, N'1         ')
INSERT [dbo].[itemsventa] ([id], [idVenta], [idProducto], [cantidad]) VALUES (40, 28, 1, N'1         ')
SET IDENTITY_INSERT [dbo].[itemsventa] OFF
GO
SET IDENTITY_INSERT [dbo].[productos] ON 

INSERT [dbo].[productos] ([id], [descripcion], [precio], [stock]) VALUES (1, N'Fideos', CAST(56.00 AS Decimal(10, 2)), 23)
INSERT [dbo].[productos] ([id], [descripcion], [precio], [stock]) VALUES (2, N'Pan', CAST(120.00 AS Decimal(10, 2)), 8)
INSERT [dbo].[productos] ([id], [descripcion], [precio], [stock]) VALUES (3, N'Cafe', CAST(250.00 AS Decimal(10, 2)), 36)
INSERT [dbo].[productos] ([id], [descripcion], [precio], [stock]) VALUES (4, N'Birra', CAST(150.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[productos] ([id], [descripcion], [precio], [stock]) VALUES (5, N'Te de vainilla', CAST(89.00 AS Decimal(10, 2)), 58)
INSERT [dbo].[productos] ([id], [descripcion], [precio], [stock]) VALUES (6, N'Azucar', CAST(65.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[productos] ([id], [descripcion], [precio], [stock]) VALUES (7, N'Yerba', CAST(128.00 AS Decimal(10, 2)), 72)
INSERT [dbo].[productos] ([id], [descripcion], [precio], [stock]) VALUES (8, N'Jugo', CAST(21.00 AS Decimal(10, 2)), 0)
INSERT [dbo].[productos] ([id], [descripcion], [precio], [stock]) VALUES (49, N'Jabon', CAST(43.00 AS Decimal(10, 2)), 0)
SET IDENTITY_INSERT [dbo].[productos] OFF
GO
SET IDENTITY_INSERT [dbo].[ventas] ON 

INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (1, 2)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (2, 1)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (3, 2)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (4, 2)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (5, 1)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (6, 1)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (7, 1)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (8, 1)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (9, 2)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (10, 2)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (11, 1)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (12, 2)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (13, 1)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (14, 2)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (15, 2)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (16, 2)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (17, 2)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (18, 1)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (19, 1)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (20, 1)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (21, 1)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (22, 1)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (23, 2)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (24, 2)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (25, 1)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (26, 1)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (27, 1)
INSERT [dbo].[ventas] ([id], [idCliente]) VALUES (28, 2)
SET IDENTITY_INSERT [dbo].[ventas] OFF
GO
USE [master]
GO
ALTER DATABASE [SeifMariano2dTp4] SET  READ_WRITE 
GO
