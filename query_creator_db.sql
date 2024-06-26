USE [TIENDADB]
GO
/****** Object:  Schema [Admin]    Script Date: 31/5/2024 21:35:14 ******/
CREATE SCHEMA [Admin]
GO
/****** Object:  Schema [Articulo]    Script Date: 31/5/2024 21:35:14 ******/
CREATE SCHEMA [Articulo]
GO
/****** Object:  Schema [Ventas]    Script Date: 31/5/2024 21:35:14 ******/
CREATE SCHEMA [Ventas]
GO
/****** Object:  Table [Admin].[Cliente]    Script Date: 31/5/2024 21:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Admin].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[TipoDocumento] [nvarchar](max) NOT NULL,
	[NroDocumento] [nvarchar](max) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Apellido] [nvarchar](max) NOT NULL,
	[Telefono] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Domicilio] [nvarchar](max) NOT NULL,
	[IdCondicionTributaria] [int] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Admin].[CondicionTributaria]    Script Date: 31/5/2024 21:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Admin].[CondicionTributaria](
	[IdCondicionTributaria] [int] NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_CondicionTributaria] PRIMARY KEY CLUSTERED 
(
	[IdCondicionTributaria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Admin].[Empleado]    Script Date: 31/5/2024 21:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Admin].[Empleado](
	[IdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[Legajo] [int] NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Apellido] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Domicilio] [nvarchar](max) NULL,
	[IdSucursal] [int] NOT NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Admin].[PuntoDeVenta]    Script Date: 31/5/2024 21:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Admin].[PuntoDeVenta](
	[IdPuntoDeVenta] [int] IDENTITY(1,1) NOT NULL,
	[NumeroPtoVenta] [int] NOT NULL,
	[Habilitado] [bit] NOT NULL,
	[IdSucursal] [int] NOT NULL,
 CONSTRAINT [PK_PuntoDeVenta] PRIMARY KEY CLUSTERED 
(
	[IdPuntoDeVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Admin].[Rol]    Script Date: 31/5/2024 21:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Admin].[Rol](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Admin].[Sesion]    Script Date: 31/5/2024 21:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Admin].[Sesion](
	[IdSesion] [int] IDENTITY(1,1) NOT NULL,
	[FechaInicio] [datetime2](7) NOT NULL,
	[FechaFin] [datetime2](7) NULL,
	[IdUsuario] [int] NOT NULL,
	[IdPuntoDeVenta] [int] NOT NULL,
 CONSTRAINT [PK_Sesion] PRIMARY KEY CLUSTERED 
(
	[IdSesion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Admin].[Sucursal]    Script Date: 31/5/2024 21:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Admin].[Sucursal](
	[IdSucursal] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Telefono] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Domicilio] [nvarchar](max) NOT NULL,
	[Ciudad] [nvarchar](max) NOT NULL,
	[IdTienda] [int] NOT NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Admin].[Tienda]    Script Date: 31/5/2024 21:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Admin].[Tienda](
	[IdTienda] [int] IDENTITY(1,1) NOT NULL,
	[Cuit] [nvarchar](max) NOT NULL,
	[IdCondicionTributaria] [int] NOT NULL,
 CONSTRAINT [PK_Tienda] PRIMARY KEY CLUSTERED 
(
	[IdTienda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Admin].[Usuario]    Script Date: 31/5/2024 21:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Admin].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](max) NOT NULL,
	[Contraseña] [nvarchar](max) NOT NULL,
	[IdRol] [int] NULL,
	[IdEmpleado] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Articulo].[Articulo]    Script Date: 31/5/2024 21:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Articulo].[Articulo](
	[IdArticulo] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](max) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[Costo] [decimal](18, 2) NOT NULL,
	[MargenGanancia] [decimal](18, 2) NOT NULL,
	[IdCategoria] [int] NULL,
	[IdMarca] [int] NULL,
	[IdTipoTalle] [int] NULL,
	[PorcentajeIVA] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Articulo] PRIMARY KEY CLUSTERED 
(
	[IdArticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Articulo].[Categoria]    Script Date: 31/5/2024 21:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Articulo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Articulo].[Color]    Script Date: 31/5/2024 21:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Articulo].[Color](
	[IdColor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[IdColor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Articulo].[Inventario]    Script Date: 31/5/2024 21:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Articulo].[Inventario](
	[IdInventario] [int] IDENTITY(1,1) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[IdSucursal] [int] NOT NULL,
	[IdColor] [int] NOT NULL,
	[IdTalle] [int] NOT NULL,
	[IdArticulo] [int] NOT NULL,
 CONSTRAINT [PK_Inventario] PRIMARY KEY CLUSTERED 
(
	[IdInventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Articulo].[Marca]    Script Date: 31/5/2024 21:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Articulo].[Marca](
	[IdMarca] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[IdMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Articulo].[Talle]    Script Date: 31/5/2024 21:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Articulo].[Talle](
	[IdTalle] [int] IDENTITY(1,1) NOT NULL,
	[Medida] [nvarchar](max) NOT NULL,
	[IdTipoTalle] [int] NULL,
 CONSTRAINT [PK_Talle] PRIMARY KEY CLUSTERED 
(
	[IdTalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Articulo].[TipoTalle]    Script Date: 31/5/2024 21:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Articulo].[TipoTalle](
	[IdTipoTalle] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TipoTalle] PRIMARY KEY CLUSTERED 
(
	[IdTipoTalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 31/5/2024 21:35:14 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Ventas].[Comprobante]    Script Date: 31/5/2024 21:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Ventas].[Comprobante](
	[IdComprobante] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NOT NULL,
	[NroComprobante] [bigint] NOT NULL,
	[NroTicket] [nvarchar](max) NULL,
 CONSTRAINT [PK_Comprobante] PRIMARY KEY CLUSTERED 
(
	[IdComprobante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Ventas].[LineaDeVenta]    Script Date: 31/5/2024 21:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Ventas].[LineaDeVenta](
	[IdLineaDeVenta] [int] IDENTITY(1,1) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[IdInventario] [int] NOT NULL,
	[IdVenta] [int] NOT NULL,
	[MontoIVA] [decimal](18, 2) NOT NULL,
	[NetoGravado] [decimal](18, 2) NOT NULL,
	[Subtotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_LineaDeVenta] PRIMARY KEY CLUSTERED 
(
	[IdLineaDeVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Ventas].[Pago]    Script Date: 31/5/2024 21:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Ventas].[Pago](
	[IdPago] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[Estado] [nvarchar](max) NOT NULL,
	[Observaciones] [nvarchar](max) NULL,
	[IdVenta] [int] NOT NULL,
	[MontoTotal] [decimal](18, 2) NOT NULL,
	[NroCae] [nvarchar](max) NULL,
 CONSTRAINT [PK_Pago] PRIMARY KEY CLUSTERED 
(
	[IdPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Ventas].[TipoDeComprobante]    Script Date: 31/5/2024 21:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Ventas].[TipoDeComprobante](
	[IdTipoDeComprobante] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[IdCondicionTributariaEmisor] [int] NOT NULL,
	[IdCondicionTributariaReceptor] [int] NOT NULL,
 CONSTRAINT [PK_TipoDeComprobante] PRIMARY KEY CLUSTERED 
(
	[IdTipoDeComprobante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Ventas].[Venta]    Script Date: 31/5/2024 21:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Ventas].[Venta](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[Estado] [nvarchar](max) NOT NULL,
	[Observaciones] [nvarchar](max) NULL,
	[IdCliente] [int] NULL,
	[IdUsuario] [int] NOT NULL,
	[IdTipoDeComprobante] [int] NULL,
	[IdPuntoVenta] [int] NOT NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [Admin].[CondicionTributaria] ADD  DEFAULT ('Default value') FOR [Nombre]
GO
ALTER TABLE [Admin].[Sesion] ADD  DEFAULT ((0)) FOR [IdPuntoDeVenta]
GO
ALTER TABLE [Admin].[Tienda] ADD  DEFAULT ((0)) FOR [IdCondicionTributaria]
GO
ALTER TABLE [Articulo].[Articulo] ADD  DEFAULT ((0.0)) FOR [PorcentajeIVA]
GO
ALTER TABLE [Articulo].[Talle] ADD  DEFAULT (N'') FOR [Medida]
GO
ALTER TABLE [Ventas].[Comprobante] ADD  DEFAULT (CONVERT([bigint],(0))) FOR [NroComprobante]
GO
ALTER TABLE [Ventas].[LineaDeVenta] ADD  DEFAULT ((0.0)) FOR [MontoIVA]
GO
ALTER TABLE [Ventas].[LineaDeVenta] ADD  DEFAULT ((0.0)) FOR [NetoGravado]
GO
ALTER TABLE [Ventas].[LineaDeVenta] ADD  DEFAULT ((0.0)) FOR [Subtotal]
GO
ALTER TABLE [Ventas].[Pago] ADD  DEFAULT (N'') FOR [Estado]
GO
ALTER TABLE [Ventas].[Pago] ADD  DEFAULT ((0.0)) FOR [MontoTotal]
GO
ALTER TABLE [Ventas].[TipoDeComprobante] ADD  DEFAULT ((0)) FOR [IdCondicionTributariaEmisor]
GO
ALTER TABLE [Ventas].[TipoDeComprobante] ADD  DEFAULT ((0)) FOR [IdCondicionTributariaReceptor]
GO
ALTER TABLE [Admin].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_CondicionTributaria_IdCondicionTributaria] FOREIGN KEY([IdCondicionTributaria])
REFERENCES [Admin].[CondicionTributaria] ([IdCondicionTributaria])
GO
ALTER TABLE [Admin].[Cliente] CHECK CONSTRAINT [FK_Cliente_CondicionTributaria_IdCondicionTributaria]
GO
ALTER TABLE [Admin].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Sucursal_IdSucursal] FOREIGN KEY([IdSucursal])
REFERENCES [Admin].[Sucursal] ([IdSucursal])
ON DELETE CASCADE
GO
ALTER TABLE [Admin].[Empleado] CHECK CONSTRAINT [FK_Empleado_Sucursal_IdSucursal]
GO
ALTER TABLE [Admin].[PuntoDeVenta]  WITH CHECK ADD  CONSTRAINT [FK_PuntoDeVenta_Sucursal_IdSucursal] FOREIGN KEY([IdSucursal])
REFERENCES [Admin].[Sucursal] ([IdSucursal])
ON DELETE CASCADE
GO
ALTER TABLE [Admin].[PuntoDeVenta] CHECK CONSTRAINT [FK_PuntoDeVenta_Sucursal_IdSucursal]
GO
ALTER TABLE [Admin].[Sesion]  WITH CHECK ADD  CONSTRAINT [FK_Sesion_Usuario_IdUsuario] FOREIGN KEY([IdUsuario])
REFERENCES [Admin].[Usuario] ([IdUsuario])
ON DELETE CASCADE
GO
ALTER TABLE [Admin].[Sesion] CHECK CONSTRAINT [FK_Sesion_Usuario_IdUsuario]
GO
ALTER TABLE [Admin].[Sucursal]  WITH CHECK ADD  CONSTRAINT [FK_Sucursal_Tienda_IdTienda] FOREIGN KEY([IdTienda])
REFERENCES [Admin].[Tienda] ([IdTienda])
ON DELETE CASCADE
GO
ALTER TABLE [Admin].[Sucursal] CHECK CONSTRAINT [FK_Sucursal_Tienda_IdTienda]
GO
ALTER TABLE [Admin].[Tienda]  WITH CHECK ADD  CONSTRAINT [FK_Tienda_CondicionTributaria_IdCondicionTributaria] FOREIGN KEY([IdCondicionTributaria])
REFERENCES [Admin].[CondicionTributaria] ([IdCondicionTributaria])
ON DELETE CASCADE
GO
ALTER TABLE [Admin].[Tienda] CHECK CONSTRAINT [FK_Tienda_CondicionTributaria_IdCondicionTributaria]
GO
ALTER TABLE [Admin].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Empleado_IdEmpleado] FOREIGN KEY([IdEmpleado])
REFERENCES [Admin].[Empleado] ([IdEmpleado])
ON DELETE CASCADE
GO
ALTER TABLE [Admin].[Usuario] CHECK CONSTRAINT [FK_Usuario_Empleado_IdEmpleado]
GO
ALTER TABLE [Admin].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol_IdRol] FOREIGN KEY([IdRol])
REFERENCES [Admin].[Rol] ([IdRol])
GO
ALTER TABLE [Admin].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol_IdRol]
GO
ALTER TABLE [Articulo].[Articulo]  WITH CHECK ADD  CONSTRAINT [FK_Articulo_Categoria_IdCategoria] FOREIGN KEY([IdCategoria])
REFERENCES [Articulo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [Articulo].[Articulo] CHECK CONSTRAINT [FK_Articulo_Categoria_IdCategoria]
GO
ALTER TABLE [Articulo].[Articulo]  WITH CHECK ADD  CONSTRAINT [FK_Articulo_Marca_IdMarca] FOREIGN KEY([IdMarca])
REFERENCES [Articulo].[Marca] ([IdMarca])
GO
ALTER TABLE [Articulo].[Articulo] CHECK CONSTRAINT [FK_Articulo_Marca_IdMarca]
GO
ALTER TABLE [Articulo].[Articulo]  WITH CHECK ADD  CONSTRAINT [FK_Articulo_TipoTalle_IdTipoTalle] FOREIGN KEY([IdTipoTalle])
REFERENCES [Articulo].[TipoTalle] ([IdTipoTalle])
GO
ALTER TABLE [Articulo].[Articulo] CHECK CONSTRAINT [FK_Articulo_TipoTalle_IdTipoTalle]
GO
ALTER TABLE [Articulo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Articulo_IdArticulo] FOREIGN KEY([IdArticulo])
REFERENCES [Articulo].[Articulo] ([IdArticulo])
ON DELETE CASCADE
GO
ALTER TABLE [Articulo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Articulo_IdArticulo]
GO
ALTER TABLE [Articulo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Color_IdColor] FOREIGN KEY([IdColor])
REFERENCES [Articulo].[Color] ([IdColor])
ON DELETE CASCADE
GO
ALTER TABLE [Articulo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Color_IdColor]
GO
ALTER TABLE [Articulo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Sucursal_IdSucursal] FOREIGN KEY([IdSucursal])
REFERENCES [Admin].[Sucursal] ([IdSucursal])
ON DELETE CASCADE
GO
ALTER TABLE [Articulo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Sucursal_IdSucursal]
GO
ALTER TABLE [Articulo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Talle_IdTalle] FOREIGN KEY([IdTalle])
REFERENCES [Articulo].[Talle] ([IdTalle])
ON DELETE CASCADE
GO
ALTER TABLE [Articulo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Talle_IdTalle]
GO
ALTER TABLE [Articulo].[Talle]  WITH CHECK ADD  CONSTRAINT [FK_Talle_TipoTalle_IdTipoTalle] FOREIGN KEY([IdTipoTalle])
REFERENCES [Articulo].[TipoTalle] ([IdTipoTalle])
GO
ALTER TABLE [Articulo].[Talle] CHECK CONSTRAINT [FK_Talle_TipoTalle_IdTipoTalle]
GO
ALTER TABLE [Ventas].[Comprobante]  WITH CHECK ADD  CONSTRAINT [FK_Comprobante_Venta_IdVenta] FOREIGN KEY([IdVenta])
REFERENCES [Ventas].[Venta] ([IdVenta])
ON DELETE CASCADE
GO
ALTER TABLE [Ventas].[Comprobante] CHECK CONSTRAINT [FK_Comprobante_Venta_IdVenta]
GO
ALTER TABLE [Ventas].[LineaDeVenta]  WITH CHECK ADD  CONSTRAINT [FK_LineaDeVenta_Inventario_IdInventario] FOREIGN KEY([IdInventario])
REFERENCES [Articulo].[Inventario] ([IdInventario])
ON DELETE CASCADE
GO
ALTER TABLE [Ventas].[LineaDeVenta] CHECK CONSTRAINT [FK_LineaDeVenta_Inventario_IdInventario]
GO
ALTER TABLE [Ventas].[LineaDeVenta]  WITH CHECK ADD  CONSTRAINT [FK_LineaDeVenta_Venta_IdVenta] FOREIGN KEY([IdVenta])
REFERENCES [Ventas].[Venta] ([IdVenta])
ON DELETE CASCADE
GO
ALTER TABLE [Ventas].[LineaDeVenta] CHECK CONSTRAINT [FK_LineaDeVenta_Venta_IdVenta]
GO
ALTER TABLE [Ventas].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_Venta_IdVenta] FOREIGN KEY([IdVenta])
REFERENCES [Ventas].[Venta] ([IdVenta])
ON DELETE CASCADE
GO
ALTER TABLE [Ventas].[Pago] CHECK CONSTRAINT [FK_Pago_Venta_IdVenta]
GO
ALTER TABLE [Ventas].[TipoDeComprobante]  WITH CHECK ADD  CONSTRAINT [FK_TipoDeComprobante_CondicionTributaria_IdCondicionTributariaEmisor] FOREIGN KEY([IdCondicionTributariaEmisor])
REFERENCES [Admin].[CondicionTributaria] ([IdCondicionTributaria])
GO
ALTER TABLE [Ventas].[TipoDeComprobante] CHECK CONSTRAINT [FK_TipoDeComprobante_CondicionTributaria_IdCondicionTributariaEmisor]
GO
ALTER TABLE [Ventas].[TipoDeComprobante]  WITH CHECK ADD  CONSTRAINT [FK_TipoDeComprobante_CondicionTributaria_IdCondicionTributariaReceptor] FOREIGN KEY([IdCondicionTributariaReceptor])
REFERENCES [Admin].[CondicionTributaria] ([IdCondicionTributaria])
GO
ALTER TABLE [Ventas].[TipoDeComprobante] CHECK CONSTRAINT [FK_TipoDeComprobante_CondicionTributaria_IdCondicionTributariaReceptor]
GO
ALTER TABLE [Ventas].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Cliente_IdCliente] FOREIGN KEY([IdCliente])
REFERENCES [Admin].[Cliente] ([IdCliente])
GO
ALTER TABLE [Ventas].[Venta] CHECK CONSTRAINT [FK_Venta_Cliente_IdCliente]
GO
ALTER TABLE [Ventas].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_PuntoDeVenta_IdPuntoVenta] FOREIGN KEY([IdPuntoVenta])
REFERENCES [Admin].[PuntoDeVenta] ([IdPuntoDeVenta])
GO
ALTER TABLE [Ventas].[Venta] CHECK CONSTRAINT [FK_Venta_PuntoDeVenta_IdPuntoVenta]
GO
ALTER TABLE [Ventas].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_TipoDeComprobante_IdTipoDeComprobante] FOREIGN KEY([IdTipoDeComprobante])
REFERENCES [Ventas].[TipoDeComprobante] ([IdTipoDeComprobante])
GO
ALTER TABLE [Ventas].[Venta] CHECK CONSTRAINT [FK_Venta_TipoDeComprobante_IdTipoDeComprobante]
GO
ALTER TABLE [Ventas].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Usuario_IdUsuario] FOREIGN KEY([IdUsuario])
REFERENCES [Admin].[Usuario] ([IdUsuario])
GO
ALTER TABLE [Ventas].[Venta] CHECK CONSTRAINT [FK_Venta_Usuario_IdUsuario]
GO
