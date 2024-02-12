using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using TiendaAPI.Models;

namespace TiendaAPI.Data;

public partial class TiendaContext : DbContext
{
    public TiendaContext(DbContextOptions<TiendaContext> options) : base(options)
    {

    }

    public virtual DbSet<Articulo> Articulo { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Color> Color { get; set; }

    public virtual DbSet<Comprobante> Comprobante { get; set; }

    public virtual DbSet<CondicionTributaria> CondicionTributaria { get; set; }

    public virtual DbSet<Empleado> Empleado { get; set; }

    public virtual DbSet<Inventario> Inventario { get; set; }

    public virtual DbSet<LineaDeVenta> LineaDeVenta { get; set; }

    public virtual DbSet<Marca> Marca { get; set; }

    public virtual DbSet<Pago> Pago { get; set; }

    public virtual DbSet<PuntoDeVenta> PuntoDeVenta { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Sucursal> Sucursal { get; set; }

    public virtual DbSet<Talle> Talle { get; set; }

    public virtual DbSet<Tienda> Tienda { get; set; }

    public virtual DbSet<TipoDeComprobante> TipoDeComprobante { get; set; }

    public virtual DbSet<TipoTalle> TipoTalle { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=THORS\\SQLEXPRESS;Database=TIENDADB;Trusted_Connection=true;TrustServerCertificate=Yes;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Define a list of entity types
        var entityVenta = new List<Type>
        {
            typeof(Venta),
            typeof(LineaDeVenta),
            typeof(Pago),
            typeof(Comprobante),
            typeof(TipoDeComprobante),
        };

        var entityAdmin = new List<Type>
        {
            typeof(Empleado),
            typeof(Usuario),
            typeof(Rol),
            typeof(Cliente),
            typeof(Tienda),
            typeof(Sucursal),
            typeof(PuntoDeVenta),
            typeof(Sesion),
            typeof(CondicionTributaria)
        };

        var entityArticulo = new List<Type>
        {
            typeof(Articulo),
            typeof(Inventario),
            typeof(Categoria),
            typeof(Marca),
            typeof(Color),
            typeof(Talle),
            typeof(TipoTalle)
        };

        // Configure table schema for each entity type
        foreach (var entityType in entityVenta)
        {
            Console.WriteLine(entityType.Name + " : Venta");
            modelBuilder.Entity(entityType).ToTable(entityType.Name, "Venta");
        }

        // Configure table schema for each entity type
        foreach (var entityType in entityArticulo)
        {
            Console.WriteLine(entityType.Name + " : Articulo");
            modelBuilder.Entity(entityType).ToTable(entityType.Name, "Articulo");
        }

        // Configure table schema for each entity type
        foreach (var entityType in entityAdmin)
        {
            Console.WriteLine(entityType.Name + " : Admin");
            modelBuilder.Entity(entityType).ToTable(entityType.Name, "Admin");
        }
    }
}