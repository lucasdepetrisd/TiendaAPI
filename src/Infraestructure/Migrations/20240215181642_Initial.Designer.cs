﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Data;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(TiendaContext))]
    [Migration("20240215181642_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TiendaAPI.Models.Articulo", b =>
                {
                    b.Property<int>("IdArticulo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArticulo"));

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

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

                    b.Property<int>("MargenGanancia")
                        .HasColumnType("int");

                    b.Property<int>("PorcentajeIVA")
                        .HasColumnType("int");

                    b.HasKey("IdArticulo");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdMarca");

                    b.HasIndex("IdTipoTalle");

                    b.ToTable("Articulo", "Articulo");
                });

            modelBuilder.Entity("TiendaAPI.Models.Categoria", b =>
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

            modelBuilder.Entity("TiendaAPI.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cuil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dni")
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

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.HasIndex("IdCondicionTributaria");

                    b.ToTable("Cliente", "Admin");
                });

            modelBuilder.Entity("TiendaAPI.Models.Color", b =>
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

            modelBuilder.Entity("TiendaAPI.Models.Comprobante", b =>
                {
                    b.Property<int>("IdComprobante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdComprobante"));

                    b.Property<int>("IdVenta")
                        .HasColumnType("int");

                    b.HasKey("IdComprobante");

                    b.HasIndex("IdVenta")
                        .IsUnique();

                    b.ToTable("Comprobante", "Ventas");
                });

            modelBuilder.Entity("TiendaAPI.Models.CondicionTributaria", b =>
                {
                    b.Property<int>("IdCondicionTributaria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCondicionTributaria"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdTipoDeComprobante")
                        .HasColumnType("int");

                    b.HasKey("IdCondicionTributaria");

                    b.HasIndex("IdTipoDeComprobante");

                    b.ToTable("CondicionTributaria", "Admin");
                });

            modelBuilder.Entity("TiendaAPI.Models.Empleado", b =>
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

            modelBuilder.Entity("TiendaAPI.Models.Inventario", b =>
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

            modelBuilder.Entity("TiendaAPI.Models.LineaDeVenta", b =>
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

                    b.Property<decimal>("PorcentajeIVA")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdLineaDeVenta");

                    b.HasIndex("IdInventario");

                    b.HasIndex("IdVenta");

                    b.ToTable("LineaDeVenta", "Ventas");
                });

            modelBuilder.Entity("TiendaAPI.Models.Marca", b =>
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

            modelBuilder.Entity("TiendaAPI.Models.Pago", b =>
                {
                    b.Property<int>("IdPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPago"));

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdVenta")
                        .HasColumnType("int");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ticket")
                        .HasColumnType("int");

                    b.HasKey("IdPago");

                    b.HasIndex("IdVenta")
                        .IsUnique();

                    b.ToTable("Pago", "Ventas");
                });

            modelBuilder.Entity("TiendaAPI.Models.PuntoDeVenta", b =>
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

            modelBuilder.Entity("TiendaAPI.Models.Rol", b =>
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

            modelBuilder.Entity("TiendaAPI.Models.Sesion", b =>
                {
                    b.Property<int>("IdSesion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSesion"));

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdPuntoDeVenta")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdSesion");

                    b.HasIndex("IdPuntoDeVenta");

                    b.HasIndex("IdUsuario")
                        .IsUnique();

                    b.ToTable("Sesion", "Admin");
                });

            modelBuilder.Entity("TiendaAPI.Models.Sucursal", b =>
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

            modelBuilder.Entity("TiendaAPI.Models.Talle", b =>
                {
                    b.Property<int>("IdTalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTalle"));

                    b.Property<int?>("IdTipoTalle")
                        .HasColumnType("int");

                    b.Property<string>("Medida")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTalle");

                    b.HasIndex("IdTipoTalle");

                    b.ToTable("Talle", "Articulo");
                });

            modelBuilder.Entity("TiendaAPI.Models.Tienda", b =>
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

            modelBuilder.Entity("TiendaAPI.Models.TipoDeComprobante", b =>
                {
                    b.Property<int>("IdTipoDeComprobante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoDeComprobante"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoDeComprobante");

                    b.ToTable("TipoDeComprobante", "Ventas");
                });

            modelBuilder.Entity("TiendaAPI.Models.TipoTalle", b =>
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

            modelBuilder.Entity("TiendaAPI.Models.Usuario", b =>
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

            modelBuilder.Entity("TiendaAPI.Models.Venta", b =>
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

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdPuntoVenta")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoDeComprobante")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<decimal>("Monto")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdVenta");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdPuntoVenta");

                    b.HasIndex("IdTipoDeComprobante");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Venta", "Ventas");
                });

            modelBuilder.Entity("TiendaAPI.Models.Articulo", b =>
                {
                    b.HasOne("TiendaAPI.Models.Categoria", "Categoria")
                        .WithMany("Articulos")
                        .HasForeignKey("IdCategoria");

                    b.HasOne("TiendaAPI.Models.Marca", "Marca")
                        .WithMany("Articulos")
                        .HasForeignKey("IdMarca");

                    b.HasOne("TiendaAPI.Models.TipoTalle", "TipoTalle")
                        .WithMany("Articulos")
                        .HasForeignKey("IdTipoTalle");

                    b.Navigation("Categoria");

                    b.Navigation("Marca");

                    b.Navigation("TipoTalle");
                });

            modelBuilder.Entity("TiendaAPI.Models.Cliente", b =>
                {
                    b.HasOne("TiendaAPI.Models.CondicionTributaria", "CondicionTributaria")
                        .WithMany("Clientes")
                        .HasForeignKey("IdCondicionTributaria");

                    b.Navigation("CondicionTributaria");
                });

            modelBuilder.Entity("TiendaAPI.Models.Comprobante", b =>
                {
                    b.HasOne("TiendaAPI.Models.Venta", "Venta")
                        .WithOne("Comprobante")
                        .HasForeignKey("TiendaAPI.Models.Comprobante", "IdVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("TiendaAPI.Models.CondicionTributaria", b =>
                {
                    b.HasOne("TiendaAPI.Models.TipoDeComprobante", "TipoDeComprobante")
                        .WithMany("CondicionesTributarias")
                        .HasForeignKey("IdTipoDeComprobante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoDeComprobante");
                });

            modelBuilder.Entity("TiendaAPI.Models.Empleado", b =>
                {
                    b.HasOne("TiendaAPI.Models.Sucursal", "Sucursal")
                        .WithMany("Empleados")
                        .HasForeignKey("IdSucursal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sucursal");
                });

            modelBuilder.Entity("TiendaAPI.Models.Inventario", b =>
                {
                    b.HasOne("TiendaAPI.Models.Articulo", "Articulo")
                        .WithMany("Inventarios")
                        .HasForeignKey("IdArticulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TiendaAPI.Models.Color", "Color")
                        .WithMany("Inventarios")
                        .HasForeignKey("IdColor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TiendaAPI.Models.Sucursal", "Sucursal")
                        .WithMany("Inventarios")
                        .HasForeignKey("IdSucursal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TiendaAPI.Models.Talle", "Talle")
                        .WithMany("Inventarios")
                        .HasForeignKey("IdTalle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Color");

                    b.Navigation("Sucursal");

                    b.Navigation("Talle");
                });

            modelBuilder.Entity("TiendaAPI.Models.LineaDeVenta", b =>
                {
                    b.HasOne("TiendaAPI.Models.Inventario", "Inventario")
                        .WithMany("LineasDeVentas")
                        .HasForeignKey("IdInventario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TiendaAPI.Models.Venta", "Venta")
                        .WithMany("LineasDeVentas")
                        .HasForeignKey("IdVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventario");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("TiendaAPI.Models.Pago", b =>
                {
                    b.HasOne("TiendaAPI.Models.Venta", "Venta")
                        .WithOne("Pago")
                        .HasForeignKey("TiendaAPI.Models.Pago", "IdVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("TiendaAPI.Models.PuntoDeVenta", b =>
                {
                    b.HasOne("TiendaAPI.Models.Sucursal", "Sucursal")
                        .WithMany("PuntosDeVentas")
                        .HasForeignKey("IdSucursal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sucursal");
                });

            modelBuilder.Entity("TiendaAPI.Models.Sesion", b =>
                {
                    b.HasOne("TiendaAPI.Models.PuntoDeVenta", "PuntoDeVenta")
                        .WithMany("Sesiones")
                        .HasForeignKey("IdPuntoDeVenta");

                    b.HasOne("TiendaAPI.Models.Usuario", "Usuario")
                        .WithOne("Sesion")
                        .HasForeignKey("TiendaAPI.Models.Sesion", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PuntoDeVenta");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TiendaAPI.Models.Sucursal", b =>
                {
                    b.HasOne("TiendaAPI.Models.Tienda", "Tienda")
                        .WithMany("Sucursales")
                        .HasForeignKey("IdTienda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tienda");
                });

            modelBuilder.Entity("TiendaAPI.Models.Talle", b =>
                {
                    b.HasOne("TiendaAPI.Models.TipoTalle", "TipoTalle")
                        .WithMany("Talles")
                        .HasForeignKey("IdTipoTalle");

                    b.Navigation("TipoTalle");
                });

            modelBuilder.Entity("TiendaAPI.Models.Tienda", b =>
                {
                    b.HasOne("TiendaAPI.Models.CondicionTributaria", "CondicionTributaria")
                        .WithOne("Tienda")
                        .HasForeignKey("TiendaAPI.Models.Tienda", "IdCondicionTributaria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CondicionTributaria");
                });

            modelBuilder.Entity("TiendaAPI.Models.Usuario", b =>
                {
                    b.HasOne("TiendaAPI.Models.Empleado", "Empleado")
                        .WithOne("Usuario")
                        .HasForeignKey("TiendaAPI.Models.Usuario", "IdEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TiendaAPI.Models.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdRol");

                    b.Navigation("Empleado");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("TiendaAPI.Models.Venta", b =>
                {
                    b.HasOne("TiendaAPI.Models.Cliente", "Cliente")
                        .WithMany("Ventas")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TiendaAPI.Models.PuntoDeVenta", "PuntoDeVenta")
                        .WithMany("Ventas")
                        .HasForeignKey("IdPuntoVenta")
                        .IsRequired();

                    b.HasOne("TiendaAPI.Models.TipoDeComprobante", "TipoDeComprobante")
                        .WithMany("Ventas")
                        .HasForeignKey("IdTipoDeComprobante")
                        .IsRequired();

                    b.HasOne("TiendaAPI.Models.Usuario", "Usuario")
                        .WithMany("Ventas")
                        .HasForeignKey("IdUsuario")
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("PuntoDeVenta");

                    b.Navigation("TipoDeComprobante");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TiendaAPI.Models.Articulo", b =>
                {
                    b.Navigation("Inventarios");
                });

            modelBuilder.Entity("TiendaAPI.Models.Categoria", b =>
                {
                    b.Navigation("Articulos");
                });

            modelBuilder.Entity("TiendaAPI.Models.Cliente", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("TiendaAPI.Models.Color", b =>
                {
                    b.Navigation("Inventarios");
                });

            modelBuilder.Entity("TiendaAPI.Models.CondicionTributaria", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Tienda");
                });

            modelBuilder.Entity("TiendaAPI.Models.Empleado", b =>
                {
                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TiendaAPI.Models.Inventario", b =>
                {
                    b.Navigation("LineasDeVentas");
                });

            modelBuilder.Entity("TiendaAPI.Models.Marca", b =>
                {
                    b.Navigation("Articulos");
                });

            modelBuilder.Entity("TiendaAPI.Models.PuntoDeVenta", b =>
                {
                    b.Navigation("Sesiones");

                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("TiendaAPI.Models.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("TiendaAPI.Models.Sucursal", b =>
                {
                    b.Navigation("Empleados");

                    b.Navigation("Inventarios");

                    b.Navigation("PuntosDeVentas");
                });

            modelBuilder.Entity("TiendaAPI.Models.Talle", b =>
                {
                    b.Navigation("Inventarios");
                });

            modelBuilder.Entity("TiendaAPI.Models.Tienda", b =>
                {
                    b.Navigation("Sucursales");
                });

            modelBuilder.Entity("TiendaAPI.Models.TipoDeComprobante", b =>
                {
                    b.Navigation("CondicionesTributarias");

                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("TiendaAPI.Models.TipoTalle", b =>
                {
                    b.Navigation("Articulos");

                    b.Navigation("Talles");
                });

            modelBuilder.Entity("TiendaAPI.Models.Usuario", b =>
                {
                    b.Navigation("Sesion");

                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("TiendaAPI.Models.Venta", b =>
                {
                    b.Navigation("Comprobante");

                    b.Navigation("LineasDeVentas");

                    b.Navigation("Pago");
                });
#pragma warning restore 612, 618
        }
    }
}
