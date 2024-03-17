﻿// <auto-generated />
using System;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(TiendaContext))]
    [Migration("20240317224131_Modifico-Estados-Venta-Pago-Comp")]
    partial class ModificoEstadosVentaPagoComp
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Admin.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Domicilio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdCondicionTributaria")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NroDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.HasIndex("IdCondicionTributaria");

                    b.ToTable("Cliente", "Admin");
                });

            modelBuilder.Entity("Domain.Models.Admin.CondicionTributaria", b =>
                {
                    b.Property<int>("IdCondicionTributaria")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCondicionTributaria");

                    b.ToTable("CondicionTributaria", "Admin");

                    b.HasData(
                        new
                        {
                            IdCondicionTributaria = 0,
                            Nombre = "ResponsableInscripto"
                        },
                        new
                        {
                            IdCondicionTributaria = 1,
                            Nombre = "Monotributista"
                        },
                        new
                        {
                            IdCondicionTributaria = 2,
                            Nombre = "Exento"
                        },
                        new
                        {
                            IdCondicionTributaria = 3,
                            Nombre = "NoResponsable"
                        },
                        new
                        {
                            IdCondicionTributaria = 4,
                            Nombre = "ConsumidorFinal"
                        });
                });

            modelBuilder.Entity("Domain.Models.Admin.Empleado", b =>
                {
                    b.Property<int>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmpleado"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Domicilio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdSucursal")
                        .HasColumnType("int");

                    b.Property<int>("Legajo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEmpleado");

                    b.HasIndex("IdSucursal");

                    b.ToTable("Empleado", "Admin");
                });

            modelBuilder.Entity("Domain.Models.Admin.PuntoDeVenta", b =>
                {
                    b.Property<int>("IdPuntoDeVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPuntoDeVenta"));

                    b.Property<bool>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<int>("IdSucursal")
                        .HasColumnType("int");

                    b.Property<int>("NumeroPtoVenta")
                        .HasColumnType("int");

                    b.HasKey("IdPuntoDeVenta");

                    b.HasIndex("IdSucursal");

                    b.ToTable("PuntoDeVenta", "Admin");
                });

            modelBuilder.Entity("Domain.Models.Admin.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRol");

                    b.ToTable("Rol", "Admin");
                });

            modelBuilder.Entity("Domain.Models.Admin.Sesion", b =>
                {
                    b.Property<int>("IdSesion")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPuntoDeVenta")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdSesion");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Sesion", "Admin");
                });

            modelBuilder.Entity("Domain.Models.Admin.Sucursal", b =>
                {
                    b.Property<int>("IdSucursal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSucursal"));

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Domicilio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdTienda")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSucursal");

                    b.HasIndex("IdTienda");

                    b.ToTable("Sucursal", "Admin");
                });

            modelBuilder.Entity("Domain.Models.Admin.Tienda", b =>
                {
                    b.Property<int>("IdTienda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTienda"));

                    b.Property<string>("Cuit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCondicionTributaria")
                        .HasColumnType("int");

                    b.HasKey("IdTienda");

                    b.HasIndex("IdCondicionTributaria")
                        .IsUnique();

                    b.ToTable("Tienda", "Admin");
                });

            modelBuilder.Entity("Domain.Models.Admin.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<int?>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdEmpleado")
                        .IsUnique();

                    b.HasIndex("IdRol");

                    b.ToTable("Usuario", "Admin");
                });

            modelBuilder.Entity("Domain.Models.Articulo.Articulo", b =>
                {
                    b.Property<int>("IdArticulo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArticulo"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Costo")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int?>("IdMarca")
                        .HasColumnType("int");

                    b.Property<int?>("IdTipoTalle")
                        .HasColumnType("int");

                    b.Property<decimal>("MargenGanancia")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PorcentajeIVA")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdArticulo");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdMarca");

                    b.HasIndex("IdTipoTalle");

                    b.ToTable("Articulo", "Articulo");
                });

            modelBuilder.Entity("Domain.Models.Articulo.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categoria", "Articulo");
                });

            modelBuilder.Entity("Domain.Models.Articulo.Color", b =>
                {
                    b.Property<int>("IdColor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdColor"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdColor");

                    b.ToTable("Color", "Articulo");
                });

            modelBuilder.Entity("Domain.Models.Articulo.Inventario", b =>
                {
                    b.Property<int>("IdInventario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInventario"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IdArticulo")
                        .HasColumnType("int");

                    b.Property<int>("IdColor")
                        .HasColumnType("int");

                    b.Property<int>("IdSucursal")
                        .HasColumnType("int");

                    b.Property<int>("IdTalle")
                        .HasColumnType("int");

                    b.HasKey("IdInventario");

                    b.HasIndex("IdArticulo");

                    b.HasIndex("IdColor");

                    b.HasIndex("IdSucursal");

                    b.HasIndex("IdTalle");

                    b.ToTable("Inventario", "Articulo");
                });

            modelBuilder.Entity("Domain.Models.Articulo.Marca", b =>
                {
                    b.Property<int>("IdMarca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMarca"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMarca");

                    b.ToTable("Marca", "Articulo");
                });

            modelBuilder.Entity("Domain.Models.Articulo.Talle", b =>
                {
                    b.Property<int>("IdTalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTalle"));

                    b.Property<int?>("IdTipoTalle")
                        .HasColumnType("int");

                    b.Property<string>("Medida")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTalle");

                    b.HasIndex("IdTipoTalle");

                    b.ToTable("Talle", "Articulo");
                });

            modelBuilder.Entity("Domain.Models.Articulo.TipoTalle", b =>
                {
                    b.Property<int>("IdTipoTalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoTalle"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoTalle");

                    b.ToTable("TipoTalle", "Articulo");
                });

            modelBuilder.Entity("Domain.Models.Ventas.Comprobante", b =>
                {
                    b.Property<int>("IdComprobante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdComprobante"));

                    b.Property<int>("IdVenta")
                        .HasColumnType("int");

                    b.Property<long>("NroComprobante")
                        .HasColumnType("bigint");

                    b.Property<string>("NroTicket")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdComprobante");

                    b.HasIndex("IdVenta")
                        .IsUnique();

                    b.ToTable("Comprobante", "Ventas");
                });

            modelBuilder.Entity("Domain.Models.Ventas.LineaDeVenta", b =>
                {
                    b.Property<int>("IdLineaDeVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLineaDeVenta"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IdInventario")
                        .HasColumnType("int");

                    b.Property<int>("IdVenta")
                        .HasColumnType("int");

                    b.Property<decimal>("MontoIVA")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetoGravado")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Subtotal")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdLineaDeVenta");

                    b.HasIndex("IdInventario");

                    b.HasIndex("IdVenta");

                    b.ToTable("LineaDeVenta", "Ventas");
                });

            modelBuilder.Entity("Domain.Models.Ventas.Pago", b =>
                {
                    b.Property<int>("IdPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPago"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdVenta")
                        .HasColumnType("int");

                    b.Property<decimal>("MontoTotal")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NroCae")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPago");

                    b.HasIndex("IdVenta")
                        .IsUnique();

                    b.ToTable("Pago", "Ventas");
                });

            modelBuilder.Entity("Domain.Models.Ventas.TipoDeComprobante", b =>
                {
                    b.Property<int>("IdTipoDeComprobante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoDeComprobante"));

                    b.Property<int>("IdCondicionTributariaEmisor")
                        .HasColumnType("int");

                    b.Property<int>("IdCondicionTributariaReceptor")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoDeComprobante");

                    b.HasIndex("IdCondicionTributariaEmisor");

                    b.HasIndex("IdCondicionTributariaReceptor");

                    b.ToTable("TipoDeComprobante", "Ventas");
                });

            modelBuilder.Entity("Domain.Models.Ventas.Venta", b =>
                {
                    b.Property<int>("IdVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVenta"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdPuntoVenta")
                        .HasColumnType("int");

                    b.Property<int?>("IdTipoDeComprobante")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdVenta");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdPuntoVenta");

                    b.HasIndex("IdTipoDeComprobante");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Venta", "Ventas");
                });

            modelBuilder.Entity("Domain.Models.Admin.Cliente", b =>
                {
                    b.HasOne("Domain.Models.Admin.CondicionTributaria", "CondicionTributaria")
                        .WithMany("Clientes")
                        .HasForeignKey("IdCondicionTributaria");

                    b.Navigation("CondicionTributaria");
                });

            modelBuilder.Entity("Domain.Models.Admin.Empleado", b =>
                {
                    b.HasOne("Domain.Models.Admin.Sucursal", "Sucursal")
                        .WithMany("Empleados")
                        .HasForeignKey("IdSucursal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sucursal");
                });

            modelBuilder.Entity("Domain.Models.Admin.PuntoDeVenta", b =>
                {
                    b.HasOne("Domain.Models.Admin.Sucursal", "Sucursal")
                        .WithMany("PuntosDeVentas")
                        .HasForeignKey("IdSucursal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sucursal");
                });

            modelBuilder.Entity("Domain.Models.Admin.Sesion", b =>
                {
                    b.HasOne("Domain.Models.Admin.PuntoDeVenta", "PuntoDeVenta")
                        .WithMany("Sesiones")
                        .HasForeignKey("IdSesion")
                        .IsRequired();

                    b.HasOne("Domain.Models.Admin.Usuario", "Usuario")
                        .WithMany("Sesiones")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PuntoDeVenta");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Models.Admin.Sucursal", b =>
                {
                    b.HasOne("Domain.Models.Admin.Tienda", "Tienda")
                        .WithMany("Sucursales")
                        .HasForeignKey("IdTienda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tienda");
                });

            modelBuilder.Entity("Domain.Models.Admin.Tienda", b =>
                {
                    b.HasOne("Domain.Models.Admin.CondicionTributaria", "CondicionTributaria")
                        .WithOne("Tienda")
                        .HasForeignKey("Domain.Models.Admin.Tienda", "IdCondicionTributaria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CondicionTributaria");
                });

            modelBuilder.Entity("Domain.Models.Admin.Usuario", b =>
                {
                    b.HasOne("Domain.Models.Admin.Empleado", "Empleado")
                        .WithOne("Usuario")
                        .HasForeignKey("Domain.Models.Admin.Usuario", "IdEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Admin.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdRol");

                    b.Navigation("Empleado");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Domain.Models.Articulo.Articulo", b =>
                {
                    b.HasOne("Domain.Models.Articulo.Categoria", "Categoria")
                        .WithMany("Articulos")
                        .HasForeignKey("IdCategoria");

                    b.HasOne("Domain.Models.Articulo.Marca", "Marca")
                        .WithMany("Articulos")
                        .HasForeignKey("IdMarca");

                    b.HasOne("Domain.Models.Articulo.TipoTalle", "TipoTalle")
                        .WithMany("Articulos")
                        .HasForeignKey("IdTipoTalle");

                    b.Navigation("Categoria");

                    b.Navigation("Marca");

                    b.Navigation("TipoTalle");
                });

            modelBuilder.Entity("Domain.Models.Articulo.Inventario", b =>
                {
                    b.HasOne("Domain.Models.Articulo.Articulo", "Articulo")
                        .WithMany("Inventarios")
                        .HasForeignKey("IdArticulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Articulo.Color", "Color")
                        .WithMany("Inventarios")
                        .HasForeignKey("IdColor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Admin.Sucursal", "Sucursal")
                        .WithMany("Inventarios")
                        .HasForeignKey("IdSucursal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Articulo.Talle", "Talle")
                        .WithMany("Inventarios")
                        .HasForeignKey("IdTalle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Color");

                    b.Navigation("Sucursal");

                    b.Navigation("Talle");
                });

            modelBuilder.Entity("Domain.Models.Articulo.Talle", b =>
                {
                    b.HasOne("Domain.Models.Articulo.TipoTalle", "TipoTalle")
                        .WithMany("Talles")
                        .HasForeignKey("IdTipoTalle");

                    b.Navigation("TipoTalle");
                });

            modelBuilder.Entity("Domain.Models.Ventas.Comprobante", b =>
                {
                    b.HasOne("Domain.Models.Ventas.Venta", "Venta")
                        .WithOne("Comprobante")
                        .HasForeignKey("Domain.Models.Ventas.Comprobante", "IdVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("Domain.Models.Ventas.LineaDeVenta", b =>
                {
                    b.HasOne("Domain.Models.Articulo.Inventario", "Inventario")
                        .WithMany("LineasDeVentas")
                        .HasForeignKey("IdInventario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Ventas.Venta", "Venta")
                        .WithMany("LineasDeVentas")
                        .HasForeignKey("IdVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventario");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("Domain.Models.Ventas.Pago", b =>
                {
                    b.HasOne("Domain.Models.Ventas.Venta", "Venta")
                        .WithOne("Pago")
                        .HasForeignKey("Domain.Models.Ventas.Pago", "IdVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("Domain.Models.Ventas.TipoDeComprobante", b =>
                {
                    b.HasOne("Domain.Models.Admin.CondicionTributaria", "CondicionTributariaEmisor")
                        .WithMany()
                        .HasForeignKey("IdCondicionTributariaEmisor")
                        .IsRequired();

                    b.HasOne("Domain.Models.Admin.CondicionTributaria", "CondicionTributariaReceptor")
                        .WithMany()
                        .HasForeignKey("IdCondicionTributariaReceptor")
                        .IsRequired();

                    b.Navigation("CondicionTributariaEmisor");

                    b.Navigation("CondicionTributariaReceptor");
                });

            modelBuilder.Entity("Domain.Models.Ventas.Venta", b =>
                {
                    b.HasOne("Domain.Models.Admin.Cliente", "Cliente")
                        .WithMany("Ventas")
                        .HasForeignKey("IdCliente");

                    b.HasOne("Domain.Models.Admin.PuntoDeVenta", "PuntoDeVenta")
                        .WithMany("Ventas")
                        .HasForeignKey("IdPuntoVenta")
                        .IsRequired();

                    b.HasOne("Domain.Models.Ventas.TipoDeComprobante", "TipoDeComprobante")
                        .WithMany("Ventas")
                        .HasForeignKey("IdTipoDeComprobante");

                    b.HasOne("Domain.Models.Admin.Usuario", "Usuario")
                        .WithMany("Ventas")
                        .HasForeignKey("IdUsuario")
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("PuntoDeVenta");

                    b.Navigation("TipoDeComprobante");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Models.Admin.Cliente", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("Domain.Models.Admin.CondicionTributaria", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Tienda");
                });

            modelBuilder.Entity("Domain.Models.Admin.Empleado", b =>
                {
                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Models.Admin.PuntoDeVenta", b =>
                {
                    b.Navigation("Sesiones");

                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("Domain.Models.Admin.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Domain.Models.Admin.Sucursal", b =>
                {
                    b.Navigation("Empleados");

                    b.Navigation("Inventarios");

                    b.Navigation("PuntosDeVentas");
                });

            modelBuilder.Entity("Domain.Models.Admin.Tienda", b =>
                {
                    b.Navigation("Sucursales");
                });

            modelBuilder.Entity("Domain.Models.Admin.Usuario", b =>
                {
                    b.Navigation("Sesiones");

                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("Domain.Models.Articulo.Articulo", b =>
                {
                    b.Navigation("Inventarios");
                });

            modelBuilder.Entity("Domain.Models.Articulo.Categoria", b =>
                {
                    b.Navigation("Articulos");
                });

            modelBuilder.Entity("Domain.Models.Articulo.Color", b =>
                {
                    b.Navigation("Inventarios");
                });

            modelBuilder.Entity("Domain.Models.Articulo.Inventario", b =>
                {
                    b.Navigation("LineasDeVentas");
                });

            modelBuilder.Entity("Domain.Models.Articulo.Marca", b =>
                {
                    b.Navigation("Articulos");
                });

            modelBuilder.Entity("Domain.Models.Articulo.Talle", b =>
                {
                    b.Navigation("Inventarios");
                });

            modelBuilder.Entity("Domain.Models.Articulo.TipoTalle", b =>
                {
                    b.Navigation("Articulos");

                    b.Navigation("Talles");
                });

            modelBuilder.Entity("Domain.Models.Ventas.TipoDeComprobante", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("Domain.Models.Ventas.Venta", b =>
                {
                    b.Navigation("Comprobante");

                    b.Navigation("LineasDeVentas");

                    b.Navigation("Pago");
                });
#pragma warning restore 612, 618
        }
    }
}
