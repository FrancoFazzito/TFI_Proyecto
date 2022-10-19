USE [SmartAssemblyDB]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 2/10/2022 22:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[Apellido] [varchar](30) NOT NULL,
	[FechaNacimiento] [varchar](30) NOT NULL,
	[Telefono] [varchar](30) NOT NULL,
	[Correo] [varchar](50) NOT NULL,
	[Provincia] [varchar](30) NOT NULL,
	[Barrio] [varchar](30) NOT NULL,
	[Contrasena] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Componente]    Script Date: 2/10/2022 22:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Componente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[Perfomance] [int] NOT NULL,
	[Tipo] [varchar](20) NOT NULL,
	[TipoFormato] [varchar](20) NULL,
	[TipoMemoria] [varchar](20) NULL,
	[Socket] [varchar](50) NULL,
	[TieneVideoIntegrado] [bit] NULL,
	[Canales] [int] NULL,
	[NivelVideoIntegrado] [int] NULL,
	[NivelFanIntegrado] [int] NULL,
	[NecesitaAltaFrecuencia] [bit] NULL,
	[Capacidad] [int] NULL,
	[TamanoFan] [int] NULL,
	[MaximaFrecuencia] [int] NULL,
	[Stock] [int] NOT NULL,
	[ConsumoEnWatts] [int] NOT NULL,
	[StockLimite] [int] NOT NULL,
 CONSTRAINT [PK_Component] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComponenteComputadora]    Script Date: 2/10/2022 22:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComponenteComputadora](
	[Id_Component] [int] NOT NULL,
	[Id_Computer] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Computadora]    Script Date: 2/10/2022 22:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Computadora](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Pedido] [int] NOT NULL,
	[TipoUso] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Computer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 2/10/2022 22:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [varchar](30) NOT NULL,
	[Correo] [varchar](50) NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[Apellido] [varchar](30) NOT NULL,
	[Contrasena] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 2/10/2022 22:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[FechaPedido] [datetime] NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoUso]    Script Date: 2/10/2022 22:49:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoUso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[Cpu] [int] NOT NULL,
	[Ram] [int] NOT NULL,
	[Gpu] [int] NOT NULL,
	[Hdd] [int] NOT NULL,
	[Ssd] [int] NOT NULL,
 CONSTRAINT [PK_Especificacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [FechaNacimiento], [Telefono], [Correo], [Provincia], [Barrio], [Contrasena]) VALUES (2, N'pablo', N'1', N'10/05/2000', N'1', N'test', N'1', N'1', N'9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08')
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Componente] ON 

INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (1, N'INTEL I3X 11TH', CAST(28800.00 AS Decimal(10, 2)), 30, N'CPU', NULL, N'DDR4', N'1200', 1, 2, 10, 10, 0, NULL, NULL, 2633, 1000, 50, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (3, N'INTEL I5 11TH', CAST(36000.00 AS Decimal(10, 2)), 50, N'CPU', NULL, N'DDR4', N'1200', 1, 2, 10, 10, 0, NULL, NULL, 2933, 1000, 70, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (5, N'INTEL I9 11TH', CAST(60000.00 AS Decimal(10, 2)), 90, N'CPU', NULL, N'DDR4', N'1200', 0, 4, NULL, 20, 1, NULL, NULL, 3600, 1000, 150, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (6, N'RYZEN 3 5100', CAST(28800.00 AS Decimal(10, 2)), 30, N'CPU', NULL, N'DDR4', N'AM4', 0, 2, NULL, 35, 1, NULL, NULL, 3200, 1000, 60, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (8, N'RYZEN 5 5300', CAST(36000.00 AS Decimal(10, 2)), 50, N'CPU', NULL, N'DDR4', N'AM4', 0, 2, NULL, 35, 1, NULL, NULL, 3200, 1000, 80, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (9, N'RYZEN 7 5700', CAST(48000.00 AS Decimal(10, 2)), 75, N'CPU', NULL, N'DDR4', N'AM4', 0, 2, NULL, 35, 1, NULL, NULL, 3200, 1000, 100, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (10, N'RYZEN 5400G', CAST(38000.00 AS Decimal(10, 2)), 45, N'CPU', NULL, N'DDR4', N'AM4', 1, 2, 35, 30, 0, NULL, NULL, 2633, 1000, 50, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (11, N'RYZEN 3600G', CAST(32000.00 AS Decimal(10, 2)), 35, N'CPU', NULL, N'DDR4', N'AM4', 1, 2, 35, 30, 0, NULL, NULL, 2933, 1000, 60, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (13, N'ASUS H510 Super', CAST(14500.00 AS Decimal(10, 2)), 20, N'MOTHER', N'MATX', N'DDR4', N'1200', 1, 2, NULL, NULL, 0, NULL, NULL, 2633, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (14, N'ASUS B560 Extreme', CAST(16500.00 AS Decimal(10, 2)), 30, N'MOTHER', N'ATX', N'DDR4', N'1200', 1, 2, NULL, NULL, 0, NULL, NULL, 2933, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (16, N'ASUS H470 Gaming', CAST(19000.00 AS Decimal(10, 2)), 40, N'MOTHER', N'ATX', N'DDR4', N'1200', 1, 4, NULL, NULL, 0, NULL, NULL, 3200, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (17, N'ASROCK B450X AS-Gaming', CAST(22000.00 AS Decimal(10, 2)), 50, N'MOTHER', N'ITX', N'DDR4', N'AM4', 0, 2, NULL, NULL, 0, NULL, NULL, 2633, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (19, N'ASROCK B550 Gaming', CAST(27000.00 AS Decimal(10, 2)), 60, N'MOTHER', N'ATX', N'DDR4', N'AM4', 0, 4, NULL, NULL, 0, NULL, NULL, 2933, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (20, N'ASROCK B560 Extreme', CAST(30500.00 AS Decimal(10, 2)), 70, N'MOTHER', N'ATX', N'DDR4', N'AM4', 0, 4, NULL, NULL, 0, NULL, NULL, 3500, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (21, N'GIGABYTE B670 Gaming sdv20', CAST(31000.00 AS Decimal(10, 2)), 80, N'MOTHER', N'ITX', N'DDR4', N'AM4', 1, 4, NULL, NULL, 0, NULL, NULL, 2933, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (22, N'GIGABYTE B670X ExtremeGaming', CAST(33000.00 AS Decimal(10, 2)), 85, N'MOTHER', N'MATX', N'DDR4', N'AM4', 1, 2, NULL, NULL, 0, NULL, NULL, 2933, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (23, N'FAN Noctua UltraCooling', CAST(31200.00 AS Decimal(10, 2)), 70, N'FAN', NULL, NULL, N'AM4-1200', 0, NULL, NULL, 30, 0, NULL, 240, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (24, N'FAN Aerocool freeze', CAST(28800.00 AS Decimal(10, 2)), 60, N'FAN', NULL, NULL, N'AM4-1200', 0, NULL, NULL, 60, 0, NULL, 120, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (27, N'FAN EVGA ultimate gaming', CAST(37200.00 AS Decimal(10, 2)), 85, N'FAN', NULL, NULL, N'1200', 0, NULL, NULL, 30, 0, NULL, 360, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (28, N'RAM CRUCIAL 4GB fgh12', CAST(9600.00 AS Decimal(10, 2)), 30, N'RAM', NULL, N'DDR4', NULL, 0, NULL, NULL, NULL, 0, 4, NULL, 2633, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (29, N'RAM CRUCIAL 8GB fgh14', CAST(16800.00 AS Decimal(10, 2)), 30, N'RAM', NULL, N'DDR4', NULL, 0, NULL, NULL, NULL, 0, 8, NULL, 2633, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (30, N'RAM CORSAIR 4GB Vengance', CAST(12000.00 AS Decimal(10, 2)), 50, N'RAM', NULL, N'DDR4', NULL, 0, NULL, NULL, NULL, 0, 4, NULL, 3200, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (31, N'RAM CORSAIR 8GB Vengance', CAST(17500.00 AS Decimal(10, 2)), 50, N'RAM', NULL, N'DDR4', NULL, 0, NULL, NULL, NULL, 0, 8, NULL, 3200, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (32, N'SEAGATE 1000GB HDD', CAST(10320.00 AS Decimal(10, 2)), 40, N'HDD', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, 1000, NULL, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (33, N'SSD SAMSUNG EVO 240GB', CAST(15120.00 AS Decimal(10, 2)), 60, N'SSD', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, 240, NULL, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (35, N'SSD SAMSUNG EVO 480GB', CAST(24000.00 AS Decimal(10, 2)), 60, N'SSD', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, 480, NULL, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (36, N'ASUS GTX 1060 OC', CAST(104400.00 AS Decimal(10, 2)), 30, N'GPU', NULL, NULL, NULL, 0, NULL, 45, NULL, 0, NULL, NULL, NULL, 1000, 40, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (37, N'ASROCK RTX 2060 GAMING-OC', CAST(120000.00 AS Decimal(10, 2)), 50, N'GPU', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, NULL, NULL, NULL, 1000, 110, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (38, N'GIGABYTE RTX 3070 ARGB GAMING', CAST(192000.00 AS Decimal(10, 2)), 75, N'GPU', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, NULL, NULL, NULL, 1000, 140, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (39, N'GIGABYTE RTX 5600 GAMING-ULTRAOC', CAST(90000.00 AS Decimal(10, 2)), 50, N'GPU', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, NULL, NULL, NULL, 1000, 120, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (40, N'ASROCK RX 6700 DUAL FAN OC', CAST(150000.00 AS Decimal(10, 2)), 70, N'GPU', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, NULL, NULL, NULL, 1000, 120, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (41, N'EVGA RX 6800XT ULTIMATE GAMING', CAST(225000.00 AS Decimal(10, 2)), 85, N'GPU', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, NULL, NULL, NULL, 1000, 150, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (42, N'NZXT h510', CAST(22800.00 AS Decimal(10, 2)), 70, N'TOWER', N'ATX', NULL, NULL, 0, NULL, NULL, NULL, 0, NULL, 360, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (43, N'FRACTAL DESIGN Define 7', CAST(28800.00 AS Decimal(10, 2)), 75, N'TOWER', N'ATX', NULL, NULL, 0, NULL, NULL, NULL, 0, NULL, 360, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (44, N'REDRAGON 1000 asfg1200', CAST(13200.00 AS Decimal(10, 2)), 50, N'PSU', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, 1000, NULL, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (45, N'SEASONIC 1000 klj800', CAST(14400.00 AS Decimal(10, 2)), 60, N'PSU', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, 1000, NULL, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (46, N'ADATA 1000 stu120', CAST(24000.00 AS Decimal(10, 2)), 70, N'PSU', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, 1000, NULL, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (48, N'RAM STRIX 4GB Gaming', CAST(14400.00 AS Decimal(10, 2)), 60, N'RAM', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, 4, NULL, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (49, N'RAM STRIX 8GB Gaming', CAST(25200.00 AS Decimal(10, 2)), 60, N'RAM', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, 8, NULL, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (50, N'RYZEN 7 5600G', CAST(55800.00 AS Decimal(10, 2)), 60, N'CPU', NULL, N'DDR4', N'AM4', 1, 2, 35, 25, 0, NULL, NULL, 2933, 1000, 60, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (51, N'RYZEN 3 3400G', CAST(32400.00 AS Decimal(10, 2)), 40, N'CPU', NULL, N'DDR4', N'AM4', 1, 2, 30, 25, 0, NULL, NULL, 2633, 1000, 50, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (52, N'RYZEN 5 3600G', CAST(39600.00 AS Decimal(10, 2)), 60, N'CPU', NULL, N'DDR4', N'AM4', 1, 2, 30, 25, 0, NULL, NULL, 2933, 1000, 60, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (55, N'FAN THERMALTAKE Freeze', CAST(14400.00 AS Decimal(10, 2)), 30, N'FAN', NULL, NULL, N'AM4-1200', 0, NULL, NULL, 30, 0, NULL, 120, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (56, N'FAN EVGA Ultracooling', CAST(28800.00 AS Decimal(10, 2)), 60, N'FAN', NULL, NULL, N'AM4-1200', 0, NULL, NULL, 60, 0, NULL, 120, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (57, N'FAN THERMALTAKE ARGB ux100', CAST(13200.00 AS Decimal(10, 2)), 30, N'FAN', NULL, NULL, N'1151', 0, NULL, NULL, 30, 0, NULL, 240, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (58, N'INTEL I7 11TH', CAST(45600.00 AS Decimal(10, 2)), 70, N'CPU', NULL, N'DDR4', N'1151', 1, 2, 10, 10, 1, NULL, NULL, 3200, 1000, 120, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (59, N'RAM ADATA 4GB Rampage', CAST(12000.00 AS Decimal(10, 2)), 30, N'RAM', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, 4, NULL, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (60, N'RAM ADATA 8GB Rampage', CAST(22800.00 AS Decimal(10, 2)), 30, N'RAM', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, 8, NULL, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (61, N'RAM STRIX 16GB GamingOC', CAST(38400.00 AS Decimal(10, 2)), 60, N'RAM', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, 16, NULL, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (62, N'WD 1000GB HDD Black', CAST(13500.00 AS Decimal(10, 2)), 45, N'HDD', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, 1000, NULL, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (63, N'REDRAGON 500 ', CAST(13200.00 AS Decimal(10, 2)), 35, N'PSU', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, 500, NULL, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (64, N'GAMEMAX 600', CAST(14400.00 AS Decimal(10, 2)), 40, N'PSU', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, 600, NULL, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (65, N'ADATA 750', CAST(24000.00 AS Decimal(10, 2)), 45, N'PSU', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, 750, NULL, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (66, N'SENTEY F10', CAST(10800.00 AS Decimal(10, 2)), 30, N'TOWER', N'MATX', NULL, NULL, 0, NULL, NULL, NULL, 0, NULL, 180, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (67, N'KOLONK F', CAST(16800.00 AS Decimal(10, 2)), 40, N'TOWER', N'ATX', NULL, NULL, 0, NULL, NULL, NULL, 0, NULL, 240, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (68, N'THERMALTAKE V250', CAST(36000.00 AS Decimal(10, 2)), 80, N'TOWER', N'ATX', NULL, NULL, 0, NULL, NULL, NULL, 0, NULL, 360, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (69, N'SSD KINGSTON 240GB', CAST(10320.00 AS Decimal(10, 2)), 35, N'SSD', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, 240, NULL, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (70, N'SSD KINGSTON 480GB', CAST(19200.00 AS Decimal(10, 2)), 35, N'SSD', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, 480, NULL, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (71, N'SSD SAMSUNG EVO 1000GB', CAST(36000.00 AS Decimal(10, 2)), 60, N'SSD', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, 1000, NULL, NULL, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (72, N'ASUS RX 550 OC', CAST(28800.00 AS Decimal(10, 2)), 30, N'GPU', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, NULL, NULL, NULL, 1000, 110, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (73, N'ASUS RX 570 OC', CAST(104400.00 AS Decimal(10, 2)), 45, N'GPU', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, NULL, NULL, NULL, 1000, 130, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (74, N'ASUS RX 5500 OC RGB', CAST(225600.00 AS Decimal(10, 2)), 50, N'GPU', NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, NULL, NULL, NULL, 1000, 120, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (75, N'ASUS ULTRAGAMING-OC 11TH', CAST(43200.00 AS Decimal(10, 2)), 80, N'MOTHER', N'ATX', N'DDR4', N'1200', 0, 4, NULL, NULL, 0, NULL, NULL, 3200, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (76, N'ASUS H510 Super', CAST(16800.00 AS Decimal(10, 2)), 30, N'MOTHER', N'MATX', N'DDR4', N'1200', 1, 2, 0, 0, 0, 0, 0, 2633, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (77, N'ASUS B560 Extreme', CAST(21600.00 AS Decimal(10, 2)), 40, N'MOTHER', N'ATX', N'DDR4', N'1200', 1, 2, 0, 0, 0, 0, 0, 2933, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (78, N'ASUS H470 Gaming', CAST(28800.00 AS Decimal(10, 2)), 60, N'MOTHER', N'ATX', N'DDR4', N'1200', 1, 4, 0, 0, 0, 0, 0, 3200, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (79, N'ASROCK B350 AS-Gaming', CAST(21600.00 AS Decimal(10, 2)), 30, N'MOTHER', N'ITX', N'DDR4', N'AM4', 0, 2, 0, 0, 0, 0, 0, 2633, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (80, N'ASROCK B450 Gaming', CAST(26400.00 AS Decimal(10, 2)), 50, N'MOTHER', N'ATX', N'DDR4', N'AM4', 0, 4, 0, 0, 0, 0, 0, 2933, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (81, N'ASROCK B560 Extreme', CAST(31200.00 AS Decimal(10, 2)), 70, N'MOTHER', N'ATX', N'DDR4', N'AM4', 0, 4, 0, 0, 0, 0, 0, 3500, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (82, N'GIGABYTE B450 Gaming sdv20', CAST(19000.00 AS Decimal(10, 2)), 40, N'MOTHER', N'ITX', N'DDR4', N'AM4', 1, 4, 0, 0, 0, 0, 0, 2933, 1000, 20, 10)
INSERT [dbo].[Componente] ([Id], [Nombre], [Precio], [Perfomance], [Tipo], [TipoFormato], [TipoMemoria], [Socket], [TieneVideoIntegrado], [Canales], [NivelVideoIntegrado], [NivelFanIntegrado], [NecesitaAltaFrecuencia], [Capacidad], [TamanoFan], [MaximaFrecuencia], [Stock], [ConsumoEnWatts], [StockLimite]) VALUES (83, N'GIGABYTE B560 ExtremeGaming', CAST(21600.00 AS Decimal(10, 2)), 40, N'MOTHER', N'MATX', N'DDR4', N'AM4', 1, 2, 0, 0, 0, 0, 0, 2933, 1000, 20, 10)
SET IDENTITY_INSERT [dbo].[Componente] OFF
GO
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (9, 5932)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (19, 5932)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5932)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5932)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5932)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5932)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (71, 5932)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (67, 5932)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5932)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (9, 5933)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (19, 5933)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5933)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5933)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5933)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5933)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (71, 5933)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (67, 5933)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5933)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (9, 5934)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (19, 5934)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5934)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5934)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5934)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5934)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (71, 5934)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (67, 5934)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5934)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (9, 5935)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (19, 5935)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5935)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5935)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5935)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5935)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (71, 5935)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (67, 5935)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5935)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (9, 5936)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (19, 5936)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5936)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5936)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5936)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5936)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (71, 5936)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (67, 5936)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5936)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (9, 5937)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (19, 5937)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5937)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5937)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5937)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5937)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (71, 5937)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (67, 5937)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5937)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (9, 5938)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (19, 5938)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5938)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5938)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5938)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5938)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (71, 5938)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (67, 5938)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5938)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (9, 5939)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (19, 5939)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5939)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5939)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5939)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5939)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (71, 5939)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (67, 5939)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5939)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (9, 5940)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (19, 5940)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5940)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5940)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5940)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5940)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (71, 5940)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (67, 5940)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5940)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (9, 5941)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (19, 5941)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5941)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5941)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5941)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5941)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (71, 5941)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (67, 5941)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5941)
GO
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (9, 5942)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (19, 5942)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5942)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5942)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5942)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5942)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (71, 5942)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (67, 5942)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5942)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (9, 5943)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (19, 5943)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5943)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5943)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5943)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5943)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (71, 5943)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (67, 5943)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5943)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (52, 5944)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (17, 5944)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5944)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5944)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (39, 5944)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5944)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (70, 5944)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5944)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5944)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (52, 5945)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (17, 5945)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5945)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5945)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (39, 5945)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5945)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (70, 5945)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5945)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5945)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (52, 5946)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (17, 5946)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5946)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5946)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (39, 5946)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5946)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (70, 5946)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5946)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5946)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (52, 5947)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (17, 5947)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5947)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5947)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (39, 5947)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5947)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (70, 5947)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5947)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5947)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (52, 5948)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (17, 5948)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5948)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5948)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (39, 5948)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5948)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (70, 5948)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5948)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5948)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (52, 5949)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (17, 5949)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5949)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5949)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (39, 5949)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5949)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (70, 5949)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5949)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5949)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (52, 5950)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (17, 5950)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5950)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5950)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (39, 5950)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5950)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (70, 5950)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5950)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5950)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (52, 5951)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (17, 5951)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5951)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5951)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (39, 5951)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5951)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (70, 5951)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5951)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5951)
GO
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (52, 5952)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (17, 5952)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5952)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5952)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (39, 5952)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5952)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (70, 5952)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5952)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5952)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (8, 5953)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5953)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5953)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5953)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5953)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5953)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (70, 5953)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5953)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5953)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (8, 5954)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5954)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5954)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5954)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5954)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5954)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (70, 5954)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5954)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5954)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (8, 5955)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5955)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5955)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5955)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5955)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5955)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (70, 5955)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5955)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5955)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (8, 5956)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5956)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (29, 5956)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5956)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5956)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5956)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (70, 5956)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5956)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5956)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (5, 5957)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (16, 5957)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5957)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5957)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5957)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5957)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (70, 5957)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (67, 5957)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5957)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (5, 5958)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (16, 5958)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5958)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5958)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5958)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5958)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (70, 5958)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (67, 5958)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5958)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (5, 5959)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (16, 5959)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5959)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5959)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5959)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5959)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (70, 5959)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (67, 5959)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5959)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (5, 5960)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (16, 5960)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5960)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5960)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5960)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5960)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (70, 5960)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (67, 5960)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5960)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (5, 5961)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (16, 5961)
GO
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5961)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5961)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5961)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5961)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (70, 5961)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (67, 5961)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5961)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (5, 5962)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (16, 5962)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5962)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5962)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5962)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5962)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (70, 5962)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (67, 5962)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5962)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (5, 5963)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (16, 5963)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5963)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5963)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5963)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5963)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (70, 5963)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (67, 5963)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5963)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (5, 5964)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (16, 5964)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5964)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (24, 5964)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (40, 5964)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5964)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (70, 5964)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (67, 5964)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5964)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (11, 5909)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5909)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5909)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5909)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (69, 5909)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5909)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5909)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (11, 5911)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5911)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5911)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5911)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (69, 5911)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5911)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5911)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (11, 5912)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5912)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5912)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5912)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (69, 5912)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5912)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5912)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (11, 5913)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5913)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5913)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5913)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (69, 5913)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5913)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5913)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (11, 5914)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5914)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5914)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5914)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (69, 5914)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5914)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5914)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (11, 5915)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5915)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5915)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5915)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (69, 5915)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5915)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5915)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (11, 5916)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5916)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5916)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5916)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (69, 5916)
GO
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5916)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5916)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (11, 5917)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5917)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5917)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5917)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (69, 5917)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5917)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5917)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (11, 5918)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5918)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5918)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5918)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (69, 5918)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5918)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5918)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (11, 5919)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5919)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5919)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5919)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (69, 5919)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5919)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5919)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (11, 5920)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5920)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5920)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5920)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (69, 5920)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5920)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5920)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (11, 5921)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5921)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5921)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5921)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (69, 5921)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5921)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5921)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (11, 5922)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5922)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5922)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5922)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (69, 5922)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5922)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5922)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (11, 5923)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5923)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5923)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5923)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (69, 5923)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5923)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5923)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (11, 5924)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5924)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5924)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5924)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (69, 5924)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5924)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5924)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (11, 5925)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5925)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5925)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5925)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (69, 5925)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5925)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5925)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (11, 5926)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5926)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5926)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5926)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (69, 5926)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5926)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5926)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (11, 5927)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5927)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5927)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5927)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (69, 5927)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5927)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5927)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (11, 5928)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5928)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5928)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5928)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (69, 5928)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5928)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5928)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (11, 5929)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5929)
GO
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5929)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5929)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (69, 5929)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5929)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5929)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (11, 5930)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5930)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5930)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5930)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (69, 5930)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5930)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5930)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (11, 5931)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (82, 5931)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (28, 5931)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (32, 5931)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (69, 5931)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (66, 5931)
INSERT [dbo].[ComponenteComputadora] ([Id_Component], [Id_Computer]) VALUES (44, 5931)
GO
SET IDENTITY_INSERT [dbo].[Computadora] ON 

INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5909, 14, N'Gaming juegos competitivos')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5911, 5, N'Gaming juegos competitivos')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5912, 6, N'Gaming juegos competitivos')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5913, 7, N'Gaming juegos competitivos')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5914, 8, N'Gaming juegos competitivos')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5915, 9, N'Gaming juegos competitivos')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5916, 10, N'Gaming juegos competitivos')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5917, 11, N'Gaming juegos competitivos')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5918, 12, N'Gaming juegos competitivos')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5919, 13, N'Gaming juegos competitivos')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5920, 16, N'Gaming juegos competitivos')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5921, 17, N'Gaming juegos competitivos')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5922, 18, N'Gaming juegos competitivos')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5923, 19, N'Gaming juegos competitivos')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5924, 20, N'Gaming juegos competitivos')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5925, 21, N'Gaming juegos competitivos')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5926, 22, N'Gaming juegos competitivos')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5927, 23, N'Gaming juegos competitivos')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5928, 24, N'Gaming juegos competitivos')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5929, 25, N'Gaming juegos competitivos')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5930, 26, N'Gaming juegos competitivos')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5931, 27, N'Gaming juegos competitivos')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5932, 28, N'Edicion de video')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5933, 29, N'Edicion de video')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5934, 30, N'Edicion de video')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5935, 31, N'Edicion de video')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5936, 32, N'Edicion de video')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5937, 33, N'Edicion de video')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5938, 34, N'Edicion de video')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5939, 35, N'Edicion de video')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5940, 36, N'Edicion de video')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5941, 37, N'Edicion de video')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5942, 38, N'Edicion de video')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5943, 39, N'Edicion de video')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5944, 40, N'Arquitectura')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5945, 41, N'Arquitectura')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5946, 42, N'Arquitectura')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5947, 43, N'Arquitectura')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5948, 44, N'Arquitectura')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5949, 45, N'Arquitectura')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5950, 46, N'Arquitectura')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5951, 47, N'Arquitectura')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5952, 48, N'Arquitectura')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5953, 49, N'Gaming juegos AAA')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5954, 50, N'Gaming juegos AAA')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5955, 51, N'Gaming juegos AAA')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5956, 52, N'Gaming juegos AAA')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5957, 53, N'Gaming juegos AAA')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5958, 54, N'Gaming juegos AAA')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5959, 55, N'Gaming juegos AAA')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5960, 56, N'Gaming juegos AAA')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5961, 57, N'Gaming juegos AAA')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5962, 58, N'Gaming juegos AAA')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5963, 59, N'Gaming juegos AAA')
INSERT [dbo].[Computadora] ([Id], [Id_Pedido], [TipoUso]) VALUES (5964, 60, N'Gaming juegos AAA')
SET IDENTITY_INSERT [dbo].[Computadora] OFF
GO
SET IDENTITY_INSERT [dbo].[Empleado] ON 

INSERT [dbo].[Empleado] ([Id], [NombreUsuario], [Correo], [Nombre], [Apellido], [Contrasena]) VALUES (1, N'test', N'test', N'pablo', N'test', N'9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08')
SET IDENTITY_INSERT [dbo].[Empleado] OFF
GO
SET IDENTITY_INSERT [dbo].[Pedido] ON 

INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (5, 2, CAST(N'2022-01-15T22:16:50.080' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (6, 2, CAST(N'2022-01-15T22:16:50.080' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (7, 2, CAST(N'2022-01-15T22:16:50.080' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (8, 2, CAST(N'2022-02-15T22:16:50.080' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (9, 2, CAST(N'2022-03-15T22:16:50.080' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (10, 2, CAST(N'2022-04-15T22:16:50.080' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (11, 2, CAST(N'2022-05-15T22:16:50.080' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (12, 2, CAST(N'2022-06-23T00:16:13.780' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (13, 2, CAST(N'2022-07-23T00:18:13.000' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (14, 2, CAST(N'2022-07-23T00:21:58.280' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (15, 2, CAST(N'2022-08-23T13:42:57.143' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (16, 2, CAST(N'2022-08-23T13:42:57.143' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (17, 2, CAST(N'2022-08-23T13:42:57.143' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (18, 2, CAST(N'2022-09-23T13:42:57.143' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (19, 2, CAST(N'2022-09-23T13:42:57.143' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (20, 2, CAST(N'2022-10-23T13:42:57.143' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (21, 2, CAST(N'2022-10-23T13:42:57.143' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (22, 2, CAST(N'2022-10-23T13:42:57.143' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (23, 2, CAST(N'2022-11-23T13:42:57.143' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (24, 2, CAST(N'2022-11-23T13:42:57.143' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (25, 2, CAST(N'2022-11-23T13:42:57.143' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (26, 2, CAST(N'2022-12-23T13:42:57.143' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (27, 2, CAST(N'2022-12-23T13:42:57.143' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (28, 2, CAST(N'2022-02-23T22:31:45.483' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (29, 2, CAST(N'2022-02-23T22:31:46.243' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (30, 2, CAST(N'2022-02-23T22:31:47.000' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (31, 2, CAST(N'2022-03-23T22:31:47.670' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (32, 2, CAST(N'2022-03-23T22:31:48.370' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (33, 2, CAST(N'2022-03-23T22:31:49.070' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (34, 2, CAST(N'2022-04-23T22:31:49.787' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (35, 2, CAST(N'2022-04-23T22:31:50.490' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (36, 2, CAST(N'2022-04-23T22:31:51.210' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (37, 2, CAST(N'2022-05-23T22:31:51.923' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (38, 2, CAST(N'2022-05-23T22:31:52.680' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (39, 2, CAST(N'2022-05-23T22:31:53.410' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (40, 2, CAST(N'2022-09-23T22:32:08.170' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (41, 2, CAST(N'2022-06-23T22:32:09.013' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (42, 2, CAST(N'2022-06-23T22:32:09.750' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (43, 2, CAST(N'2022-06-23T22:32:10.497' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (44, 2, CAST(N'2022-06-23T22:32:11.233' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (45, 2, CAST(N'2022-07-23T22:32:12.000' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (46, 2, CAST(N'2022-07-23T22:32:12.680' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (47, 2, CAST(N'2022-02-23T22:32:13.250' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (48, 2, CAST(N'2022-12-23T22:32:13.993' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (49, 2, CAST(N'2022-11-23T22:32:31.660' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (50, 2, CAST(N'2022-09-23T22:32:32.470' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (51, 2, CAST(N'2022-09-23T22:32:33.277' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (52, 2, CAST(N'2022-01-23T22:32:34.027' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (53, 2, CAST(N'2022-05-23T22:32:41.360' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (54, 2, CAST(N'2022-10-23T22:32:42.170' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (55, 2, CAST(N'2022-09-23T22:32:42.900' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (56, 2, CAST(N'2022-09-23T22:32:43.680' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (57, 2, CAST(N'2022-09-23T22:32:44.437' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (58, 2, CAST(N'2022-08-23T22:32:45.180' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (59, 2, CAST(N'2022-10-23T22:32:46.020' AS DateTime))
INSERT [dbo].[Pedido] ([Id], [IdCliente], [FechaPedido]) VALUES (60, 2, CAST(N'2022-08-23T22:32:46.717' AS DateTime))
SET IDENTITY_INSERT [dbo].[Pedido] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoUso] ON 

INSERT [dbo].[TipoUso] ([Id], [Nombre], [Cpu], [Ram], [Gpu], [Hdd], [Ssd]) VALUES (2, N'Gaming juegos AAA', 50, 16, 60, 1000, 480)
INSERT [dbo].[TipoUso] ([Id], [Nombre], [Cpu], [Ram], [Gpu], [Hdd], [Ssd]) VALUES (3, N'Edicion de video', 70, 16, 70, 1000, 1000)
INSERT [dbo].[TipoUso] ([Id], [Nombre], [Cpu], [Ram], [Gpu], [Hdd], [Ssd]) VALUES (4, N'Arquitectura', 60, 16, 50, 1000, 480)
INSERT [dbo].[TipoUso] ([Id], [Nombre], [Cpu], [Ram], [Gpu], [Hdd], [Ssd]) VALUES (5, N'Gaming juegos competitivos', 30, 8, 30, 1000, 240)
INSERT [dbo].[TipoUso] ([Id], [Nombre], [Cpu], [Ram], [Gpu], [Hdd], [Ssd]) VALUES (7, N'Oficina', 20, 4, 10, 1000, 0)
SET IDENTITY_INSERT [dbo].[TipoUso] OFF
GO
ALTER TABLE [dbo].[Componente] ADD  CONSTRAINT [DF_Component_TypeFormat]  DEFAULT ('___') FOR [TipoFormato]
GO
ALTER TABLE [dbo].[Componente] ADD  CONSTRAINT [DF_Component_TypeMemory]  DEFAULT ('___') FOR [TipoMemoria]
GO
ALTER TABLE [dbo].[Componente] ADD  CONSTRAINT [DF_Component_Socket]  DEFAULT ('___') FOR [Socket]
GO
ALTER TABLE [dbo].[Componente] ADD  CONSTRAINT [DF_Component_HasIntegratedVideo]  DEFAULT ((0)) FOR [TieneVideoIntegrado]
GO
ALTER TABLE [dbo].[Componente] ADD  CONSTRAINT [DF_Component_Channels]  DEFAULT ((0)) FOR [Canales]
GO
ALTER TABLE [dbo].[Componente] ADD  CONSTRAINT [DF_Component_VideoLevel]  DEFAULT ((0)) FOR [NivelVideoIntegrado]
GO
ALTER TABLE [dbo].[Componente] ADD  CONSTRAINT [DF_Component_FanLevel]  DEFAULT ((0)) FOR [NivelFanIntegrado]
GO
ALTER TABLE [dbo].[Componente] ADD  CONSTRAINT [DF_Component_NeedHighFrecuency]  DEFAULT ((0)) FOR [NecesitaAltaFrecuencia]
GO
ALTER TABLE [dbo].[Componente] ADD  CONSTRAINT [DF_Component_Capacity]  DEFAULT ((0)) FOR [Capacidad]
GO
ALTER TABLE [dbo].[Componente] ADD  CONSTRAINT [DF_Component_Size]  DEFAULT ((0)) FOR [TamanoFan]
GO
ALTER TABLE [dbo].[Componente] ADD  CONSTRAINT [DF_Component_MaxFrecuency]  DEFAULT ((0)) FOR [MaximaFrecuencia]
GO
ALTER TABLE [dbo].[Componente] ADD  CONSTRAINT [DF_Component_Stock]  DEFAULT ((10)) FOR [Stock]
GO
ALTER TABLE [dbo].[Componente] ADD  CONSTRAINT [DF_Component_Watts]  DEFAULT ((20)) FOR [ConsumoEnWatts]
GO
ALTER TABLE [dbo].[Componente] ADD  CONSTRAINT [DF_Component_Stock_Limit]  DEFAULT ((1)) FOR [StockLimite]
GO
ALTER TABLE [dbo].[ComponenteComputadora]  WITH CHECK ADD  CONSTRAINT [FK_Component_Computer_Component] FOREIGN KEY([Id_Component])
REFERENCES [dbo].[Componente] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ComponenteComputadora] CHECK CONSTRAINT [FK_Component_Computer_Component]
GO
ALTER TABLE [dbo].[ComponenteComputadora]  WITH CHECK ADD  CONSTRAINT [FK_Component_Computer_Computer] FOREIGN KEY([Id_Computer])
REFERENCES [dbo].[Computadora] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ComponenteComputadora] CHECK CONSTRAINT [FK_Component_Computer_Computer]
GO
ALTER TABLE [dbo].[Computadora]  WITH CHECK ADD  CONSTRAINT [FK_Computadora_Pedido] FOREIGN KEY([Id_Pedido])
REFERENCES [dbo].[Pedido] ([Id])
GO
ALTER TABLE [dbo].[Computadora] CHECK CONSTRAINT [FK_Computadora_Pedido]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Cliente]
GO
