USE [master]
GO
/****** Object:  Database [dbSeguros]    Script Date: 29/06/2020 11:26:09 a. m. ******/
CREATE DATABASE [dbSeguros]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbSeguros', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLDEVELOPER\MSSQL\DATA\dbSeguros.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbSeguros_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLDEVELOPER\MSSQL\DATA\dbSeguros_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [dbSeguros] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbSeguros].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbSeguros] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbSeguros] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbSeguros] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbSeguros] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbSeguros] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbSeguros] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbSeguros] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbSeguros] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbSeguros] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbSeguros] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbSeguros] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbSeguros] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbSeguros] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbSeguros] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbSeguros] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbSeguros] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbSeguros] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbSeguros] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbSeguros] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbSeguros] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbSeguros] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbSeguros] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbSeguros] SET RECOVERY FULL 
GO
ALTER DATABASE [dbSeguros] SET  MULTI_USER 
GO
ALTER DATABASE [dbSeguros] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbSeguros] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbSeguros] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbSeguros] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbSeguros] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbSeguros', N'ON'
GO
ALTER DATABASE [dbSeguros] SET QUERY_STORE = OFF
GO
USE [dbSeguros]
GO
/****** Object:  Schema [seguro]    Script Date: 29/06/2020 11:26:09 a. m. ******/
CREATE SCHEMA [seguro]
GO
/****** Object:  Schema [usr]    Script Date: 29/06/2020 11:26:09 a. m. ******/
CREATE SCHEMA [usr]
GO
/****** Object:  Table [seguro].[tbCliente]    Script Date: 29/06/2020 11:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [seguro].[tbCliente](
	[clienteId] [int] IDENTITY(1,1) NOT NULL,
	[nombreCompleto] [varchar](500) NULL,
	[documento] [varchar](50) NULL,
	[tipoDoc] [int] NULL,
	[direccrion] [varchar](max) NULL,
	[telefono] [varchar](20) NULL,
 CONSTRAINT [PK_seguroTbCliente] PRIMARY KEY CLUSTERED 
(
	[clienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [seguro].[tbPoliza]    Script Date: 29/06/2020 11:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [seguro].[tbPoliza](
	[polizaId] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](500) NULL,
	[descriocion] [varchar](max) NULL,
	[tipoCubrimiento] [int] NULL,
	[cubrimiento] [decimal](18, 0) NULL,
	[inicioVigencia] [datetime] NULL,
	[periodoCobertura] [int] NULL,
	[precio] [money] NULL,
	[tipoRiesgo] [int] NULL,
 CONSTRAINT [PK_seguroTbPoliza] PRIMARY KEY CLUSTERED 
(
	[polizaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [seguro].[tbPolizaPorCliente]    Script Date: 29/06/2020 11:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [seguro].[tbPolizaPorCliente](
	[PolizaPorClienteId] [int] IDENTITY(1,1) NOT NULL,
	[clientreId] [int] NULL,
	[polizaId] [int] NULL,
	[fechaInicio] [datetime] NULL,
	[fechaIFinal] [datetime] NULL,
 CONSTRAINT [PK_seguroTbPolizaPorCliente] PRIMARY KEY CLUSTERED 
(
	[PolizaPorClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [seguro].[tbTipoCubrimiento]    Script Date: 29/06/2020 11:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [seguro].[tbTipoCubrimiento](
	[tipoCubrimientoId] [int] IDENTITY(1,1) NOT NULL,
	[tipoCubrimiento] [varchar](50) NULL,
 CONSTRAINT [PK_seguroTbTipoCubrimiento] PRIMARY KEY CLUSTERED 
(
	[tipoCubrimientoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [seguro].[tbTipoDoc]    Script Date: 29/06/2020 11:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [seguro].[tbTipoDoc](
	[tipoDocId] [int] IDENTITY(1,1) NOT NULL,
	[tipoDocumento] [varchar](50) NULL,
 CONSTRAINT [PK_seguroTbTipoDoc] PRIMARY KEY CLUSTERED 
(
	[tipoDocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [seguro].[tbTipoRiesgo]    Script Date: 29/06/2020 11:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [seguro].[tbTipoRiesgo](
	[tipoRiesgoId] [int] IDENTITY(1,1) NOT NULL,
	[tipoRiesgo] [varchar](50) NULL,
 CONSTRAINT [PK_seguroTbTipoRiesgo] PRIMARY KEY CLUSTERED 
(
	[tipoRiesgoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [usr].[tbPermisoPorRol]    Script Date: 29/06/2020 11:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [usr].[tbPermisoPorRol](
	[permisoPorRolId] [int] IDENTITY(1,1) NOT NULL,
	[rolId] [int] NULL,
	[titulo] [varchar](50) NULL,
	[accion] [varchar](50) NULL,
	[controlador] [varchar](50) NULL,
	[nivel] [int] NULL,
 CONSTRAINT [PK_usrTbPermisoPorRol] PRIMARY KEY CLUSTERED 
(
	[permisoPorRolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [usr].[tbRol]    Script Date: 29/06/2020 11:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [usr].[tbRol](
	[rolId] [int] IDENTITY(1,1) NOT NULL,
	[rol] [varchar](50) NULL,
 CONSTRAINT [PK_usrTbRol] PRIMARY KEY CLUSTERED 
(
	[rolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [usr].[tbUsuario]    Script Date: 29/06/2020 11:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [usr].[tbUsuario](
	[usuarioId] [int] IDENTITY(1,1) NOT NULL,
	[login] [varchar](50) NULL,
	[nombres] [varchar](150) NULL,
	[contrasena] [varchar](200) NULL,
	[rolId] [int] NULL,
 CONSTRAINT [PK_usrTbUsuario] PRIMARY KEY CLUSTERED 
(
	[usuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [seguro].[tbCliente] ON 

INSERT [seguro].[tbCliente] ([clienteId], [nombreCompleto], [documento], [tipoDoc], [direccrion], [telefono]) VALUES (2, N'Cliente 33r', N'5678', 1, N'calle y carrera', NULL)
INSERT [seguro].[tbCliente] ([clienteId], [nombreCompleto], [documento], [tipoDoc], [direccrion], [telefono]) VALUES (5, N'Cliente 3', N'56789', 1, N'calle y carrera 2', N'123456')
INSERT [seguro].[tbCliente] ([clienteId], [nombreCompleto], [documento], [tipoDoc], [direccrion], [telefono]) VALUES (1004, N'Cliente 4', N'567899', 1, N'calle y carrera 2', N'123456')
INSERT [seguro].[tbCliente] ([clienteId], [nombreCompleto], [documento], [tipoDoc], [direccrion], [telefono]) VALUES (1006, N'Cliente 33', N'567800', 1, N'calle y carrera 2', N'123456')
SET IDENTITY_INSERT [seguro].[tbCliente] OFF
GO
SET IDENTITY_INSERT [seguro].[tbPoliza] ON 

INSERT [seguro].[tbPoliza] ([polizaId], [nombre], [descriocion], [tipoCubrimiento], [cubrimiento], [inicioVigencia], [periodoCobertura], [precio], [tipoRiesgo]) VALUES (3, N'Poliza 3', N'Poliza de prueba 3', 2, CAST(40 AS Decimal(18, 0)), CAST(N'2020-06-27T00:00:00.000' AS DateTime), 12, 660000.0000, 4)
INSERT [seguro].[tbPoliza] ([polizaId], [nombre], [descriocion], [tipoCubrimiento], [cubrimiento], [inicioVigencia], [periodoCobertura], [precio], [tipoRiesgo]) VALUES (4, N'Poliza 4', N'Poliza de prueba 4', 3, CAST(90 AS Decimal(18, 0)), CAST(N'2020-06-27T00:00:00.000' AS DateTime), 12, 780000.0000, 1)
INSERT [seguro].[tbPoliza] ([polizaId], [nombre], [descriocion], [tipoCubrimiento], [cubrimiento], [inicioVigencia], [periodoCobertura], [precio], [tipoRiesgo]) VALUES (5, N'Poliza 5', N'Poliza de prueba 5', 1, CAST(90 AS Decimal(18, 0)), CAST(N'2020-06-27T00:00:00.000' AS DateTime), 12, 660000.0000, 1)
INSERT [seguro].[tbPoliza] ([polizaId], [nombre], [descriocion], [tipoCubrimiento], [cubrimiento], [inicioVigencia], [periodoCobertura], [precio], [tipoRiesgo]) VALUES (7, N'Poliza 6', N'Poliza de prueba 6', 1, CAST(90 AS Decimal(18, 0)), CAST(N'2020-06-27T00:00:00.000' AS DateTime), 12, 660000.0000, 1)
INSERT [seguro].[tbPoliza] ([polizaId], [nombre], [descriocion], [tipoCubrimiento], [cubrimiento], [inicioVigencia], [periodoCobertura], [precio], [tipoRiesgo]) VALUES (1002, N'Poliza 8', N'Poliza de prueba 8', 1, CAST(90 AS Decimal(18, 0)), CAST(N'2020-06-27T00:00:00.000' AS DateTime), 12, 780000.0000, 3)
SET IDENTITY_INSERT [seguro].[tbPoliza] OFF
GO
SET IDENTITY_INSERT [seguro].[tbPolizaPorCliente] ON 

INSERT [seguro].[tbPolizaPorCliente] ([PolizaPorClienteId], [clientreId], [polizaId], [fechaInicio], [fechaIFinal]) VALUES (8, 1004, 3, CAST(N'2020-06-28T00:00:00.000' AS DateTime), CAST(N'2021-06-28T00:00:00.000' AS DateTime))
INSERT [seguro].[tbPolizaPorCliente] ([PolizaPorClienteId], [clientreId], [polizaId], [fechaInicio], [fechaIFinal]) VALUES (9, 1004, 4, CAST(N'2020-06-28T00:00:00.000' AS DateTime), CAST(N'2021-06-28T00:00:00.000' AS DateTime))
INSERT [seguro].[tbPolizaPorCliente] ([PolizaPorClienteId], [clientreId], [polizaId], [fechaInicio], [fechaIFinal]) VALUES (10, 2, 4, CAST(N'2020-06-28T00:00:00.000' AS DateTime), CAST(N'2021-06-28T00:00:00.000' AS DateTime))
INSERT [seguro].[tbPolizaPorCliente] ([PolizaPorClienteId], [clientreId], [polizaId], [fechaInicio], [fechaIFinal]) VALUES (11, 1004, 1002, CAST(N'2020-06-28T00:00:00.000' AS DateTime), CAST(N'2021-06-28T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [seguro].[tbPolizaPorCliente] OFF
GO
SET IDENTITY_INSERT [seguro].[tbTipoCubrimiento] ON 

INSERT [seguro].[tbTipoCubrimiento] ([tipoCubrimientoId], [tipoCubrimiento]) VALUES (1, N'Terremoto')
INSERT [seguro].[tbTipoCubrimiento] ([tipoCubrimientoId], [tipoCubrimiento]) VALUES (2, N'Incendio')
INSERT [seguro].[tbTipoCubrimiento] ([tipoCubrimientoId], [tipoCubrimiento]) VALUES (3, N'Robo')
INSERT [seguro].[tbTipoCubrimiento] ([tipoCubrimientoId], [tipoCubrimiento]) VALUES (4, N'Perdida')
INSERT [seguro].[tbTipoCubrimiento] ([tipoCubrimientoId], [tipoCubrimiento]) VALUES (5, N'Vida')
SET IDENTITY_INSERT [seguro].[tbTipoCubrimiento] OFF
GO
SET IDENTITY_INSERT [seguro].[tbTipoDoc] ON 

INSERT [seguro].[tbTipoDoc] ([tipoDocId], [tipoDocumento]) VALUES (1, N'Cédula Ciudadanía')
INSERT [seguro].[tbTipoDoc] ([tipoDocId], [tipoDocumento]) VALUES (2, N'Tarjeta Identidad')
INSERT [seguro].[tbTipoDoc] ([tipoDocId], [tipoDocumento]) VALUES (3, N'Registro CIvil')
INSERT [seguro].[tbTipoDoc] ([tipoDocId], [tipoDocumento]) VALUES (4, N'Pasaporte')
INSERT [seguro].[tbTipoDoc] ([tipoDocId], [tipoDocumento]) VALUES (5, N'Cédula Extrangería')
SET IDENTITY_INSERT [seguro].[tbTipoDoc] OFF
GO
SET IDENTITY_INSERT [seguro].[tbTipoRiesgo] ON 

INSERT [seguro].[tbTipoRiesgo] ([tipoRiesgoId], [tipoRiesgo]) VALUES (1, N'Bajo')
INSERT [seguro].[tbTipoRiesgo] ([tipoRiesgoId], [tipoRiesgo]) VALUES (2, N'Medio')
INSERT [seguro].[tbTipoRiesgo] ([tipoRiesgoId], [tipoRiesgo]) VALUES (3, N'Medio Alto')
INSERT [seguro].[tbTipoRiesgo] ([tipoRiesgoId], [tipoRiesgo]) VALUES (4, N'Alto')
SET IDENTITY_INSERT [seguro].[tbTipoRiesgo] OFF
GO
SET IDENTITY_INSERT [usr].[tbPermisoPorRol] ON 

INSERT [usr].[tbPermisoPorRol] ([permisoPorRolId], [rolId], [titulo], [accion], [controlador], [nivel]) VALUES (1, 1, N'Gestiona Seguros', N'Index', N'Poliza', 1)
INSERT [usr].[tbPermisoPorRol] ([permisoPorRolId], [rolId], [titulo], [accion], [controlador], [nivel]) VALUES (2, 1, N'Usuarios', N'Index', N'Usuario', 1)
INSERT [usr].[tbPermisoPorRol] ([permisoPorRolId], [rolId], [titulo], [accion], [controlador], [nivel]) VALUES (3, 2, N'Gestiona Seguros', N'Index', N'Poliza', 1)
INSERT [usr].[tbPermisoPorRol] ([permisoPorRolId], [rolId], [titulo], [accion], [controlador], [nivel]) VALUES (4, 1, N'Crear Poliza', N'Create', N'Poliza', 3)
INSERT [usr].[tbPermisoPorRol] ([permisoPorRolId], [rolId], [titulo], [accion], [controlador], [nivel]) VALUES (5, 1, N'Polizas', N'ListaPolizas', N'Poliza', 2)
INSERT [usr].[tbPermisoPorRol] ([permisoPorRolId], [rolId], [titulo], [accion], [controlador], [nivel]) VALUES (6, 1, N'Polizas Por Cliente', N'PolizasCiente', N'Cliente', 2)
INSERT [usr].[tbPermisoPorRol] ([permisoPorRolId], [rolId], [titulo], [accion], [controlador], [nivel]) VALUES (7, 1, N'Clientes', N'ListaClientes', N'Cliente', 2)
INSERT [usr].[tbPermisoPorRol] ([permisoPorRolId], [rolId], [titulo], [accion], [controlador], [nivel]) VALUES (8, 2, N'Polizas', N'ListaPolizas', N'Poliza', 2)
INSERT [usr].[tbPermisoPorRol] ([permisoPorRolId], [rolId], [titulo], [accion], [controlador], [nivel]) VALUES (9, 2, N'Polizas Por Ciente', N'PolizasCiente', N'Poliza', 2)
INSERT [usr].[tbPermisoPorRol] ([permisoPorRolId], [rolId], [titulo], [accion], [controlador], [nivel]) VALUES (10, 2, N'Clientes', N'ListaClientes', N'Cliente', 2)
INSERT [usr].[tbPermisoPorRol] ([permisoPorRolId], [rolId], [titulo], [accion], [controlador], [nivel]) VALUES (11, 1, N'Actualizar', N'Edit', N'Poliza', 3)
INSERT [usr].[tbPermisoPorRol] ([permisoPorRolId], [rolId], [titulo], [accion], [controlador], [nivel]) VALUES (12, 1, N'Eliminar', N'Delete', N'Poliza', 3)
INSERT [usr].[tbPermisoPorRol] ([permisoPorRolId], [rolId], [titulo], [accion], [controlador], [nivel]) VALUES (13, 2, N'Actualizar', N'Edit', N'Poliza', 3)
INSERT [usr].[tbPermisoPorRol] ([permisoPorRolId], [rolId], [titulo], [accion], [controlador], [nivel]) VALUES (15, 1, N'Detalle', N'Details', N'Poliza', 3)
INSERT [usr].[tbPermisoPorRol] ([permisoPorRolId], [rolId], [titulo], [accion], [controlador], [nivel]) VALUES (16, 1, N'Crear Cliente', N'Create', N'Cliente', 4)
INSERT [usr].[tbPermisoPorRol] ([permisoPorRolId], [rolId], [titulo], [accion], [controlador], [nivel]) VALUES (17, 1, N'Actualizar', N'Edit', N'Cliente', 4)
INSERT [usr].[tbPermisoPorRol] ([permisoPorRolId], [rolId], [titulo], [accion], [controlador], [nivel]) VALUES (18, 1, N'Eliminar', N'Delete', N'Cliente', 4)
INSERT [usr].[tbPermisoPorRol] ([permisoPorRolId], [rolId], [titulo], [accion], [controlador], [nivel]) VALUES (19, 2, N'Actualizar', N'Edit', N'Cliente', 4)
INSERT [usr].[tbPermisoPorRol] ([permisoPorRolId], [rolId], [titulo], [accion], [controlador], [nivel]) VALUES (20, 2, N'Eliminar', N'Delete', N'Cliente', 4)
INSERT [usr].[tbPermisoPorRol] ([permisoPorRolId], [rolId], [titulo], [accion], [controlador], [nivel]) VALUES (21, 2, N'Crear Cliente', N'Create', N'Cliente', 4)
SET IDENTITY_INSERT [usr].[tbPermisoPorRol] OFF
GO
SET IDENTITY_INSERT [usr].[tbRol] ON 

INSERT [usr].[tbRol] ([rolId], [rol]) VALUES (1, N'administrador')
INSERT [usr].[tbRol] ([rolId], [rol]) VALUES (2, N'usuario')
SET IDENTITY_INSERT [usr].[tbRol] OFF
GO
SET IDENTITY_INSERT [usr].[tbUsuario] ON 

INSERT [usr].[tbUsuario] ([usuarioId], [login], [nombres], [contrasena], [rolId]) VALUES (1, N'admin', N'Administrador Aplicación', N'MQAyADMANAA1ADYA', 1)
INSERT [usr].[tbUsuario] ([usuarioId], [login], [nombres], [contrasena], [rolId]) VALUES (2, N'usuario', N'Usuario Aplicación', N'MQAyADMANAA1ADYA', 2)
SET IDENTITY_INSERT [usr].[tbUsuario] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [AK_DocumentoUser]    Script Date: 29/06/2020 11:26:09 a. m. ******/
ALTER TABLE [seguro].[tbCliente] ADD  CONSTRAINT [AK_DocumentoUser] UNIQUE NONCLUSTERED 
(
	[documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [AK_usrLogin]    Script Date: 29/06/2020 11:26:09 a. m. ******/
ALTER TABLE [usr].[tbUsuario] ADD  CONSTRAINT [AK_usrLogin] UNIQUE NONCLUSTERED 
(
	[login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [seguro].[tbCliente]  WITH CHECK ADD  CONSTRAINT [FK_tbCliente_tbTipoDoc] FOREIGN KEY([tipoDoc])
REFERENCES [seguro].[tbTipoDoc] ([tipoDocId])
GO
ALTER TABLE [seguro].[tbCliente] CHECK CONSTRAINT [FK_tbCliente_tbTipoDoc]
GO
ALTER TABLE [seguro].[tbPoliza]  WITH CHECK ADD  CONSTRAINT [FK_tbPoliza_tbTipoCubrimiento] FOREIGN KEY([tipoCubrimiento])
REFERENCES [seguro].[tbTipoCubrimiento] ([tipoCubrimientoId])
GO
ALTER TABLE [seguro].[tbPoliza] CHECK CONSTRAINT [FK_tbPoliza_tbTipoCubrimiento]
GO
ALTER TABLE [seguro].[tbPoliza]  WITH CHECK ADD  CONSTRAINT [FK_tbPoliza_tbTipoRiesgo] FOREIGN KEY([tipoRiesgo])
REFERENCES [seguro].[tbTipoRiesgo] ([tipoRiesgoId])
GO
ALTER TABLE [seguro].[tbPoliza] CHECK CONSTRAINT [FK_tbPoliza_tbTipoRiesgo]
GO
ALTER TABLE [seguro].[tbPolizaPorCliente]  WITH CHECK ADD  CONSTRAINT [FK_tbPolizaPorCliente_tbCliente] FOREIGN KEY([clientreId])
REFERENCES [seguro].[tbCliente] ([clienteId])
GO
ALTER TABLE [seguro].[tbPolizaPorCliente] CHECK CONSTRAINT [FK_tbPolizaPorCliente_tbCliente]
GO
ALTER TABLE [seguro].[tbPolizaPorCliente]  WITH CHECK ADD  CONSTRAINT [FK_tbPolizaPorCliente_tbPoliza] FOREIGN KEY([polizaId])
REFERENCES [seguro].[tbPoliza] ([polizaId])
GO
ALTER TABLE [seguro].[tbPolizaPorCliente] CHECK CONSTRAINT [FK_tbPolizaPorCliente_tbPoliza]
GO
ALTER TABLE [usr].[tbPermisoPorRol]  WITH CHECK ADD  CONSTRAINT [FK_tbPermisoPorRol_tbRol] FOREIGN KEY([rolId])
REFERENCES [usr].[tbRol] ([rolId])
GO
ALTER TABLE [usr].[tbPermisoPorRol] CHECK CONSTRAINT [FK_tbPermisoPorRol_tbRol]
GO
ALTER TABLE [usr].[tbUsuario]  WITH CHECK ADD  CONSTRAINT [FK_tbUsuario_tbRol] FOREIGN KEY([rolId])
REFERENCES [usr].[tbRol] ([rolId])
GO
ALTER TABLE [usr].[tbUsuario] CHECK CONSTRAINT [FK_tbUsuario_tbRol]
GO
USE [master]
GO
ALTER DATABASE [dbSeguros] SET  READ_WRITE 
GO
