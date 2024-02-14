using System;
using System.Collections.Generic;
using System.Data;
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

        var sesionConfig = modelBuilder.Entity<Sesion>();
        //sesionConfig.HasOne(s => s.Usuario).WithOne(u => u.Sesion).OnDelete(DeleteBehavior.NoAction);
        //sesionConfig.HasOne(s => s.PuntoDeVenta).WithMany(p => p.Sesiones).OnDelete(DeleteBehavior.oAction);

        var tipoCompConfig = modelBuilder.Entity<TipoDeComprobante>();
        tipoCompConfig
            .HasMany(t => t.Ventas)
            .WithOne(v => v.TipoDeComprobante)            
            .OnDelete(DeleteBehavior.Restrict);

        tipoCompConfig
            .HasMany(t => t.Ventas)
            .WithOne(v => v.TipoDeComprobante)
            .HasForeignKey(v => v.IdTipoDeComprobante)
            .IsRequired();

        var usuarioConfig = modelBuilder.Entity<Usuario>();
        usuarioConfig
            .HasMany(t => t.Ventas)
            .WithOne(v => v.Usuario)
            .OnDelete(DeleteBehavior.Restrict);

        //ventaConfig.HasOne(v => v.Usuario)
        //    .WithOne()
        //    .HasForeignKey<Venta>(i => i.IdUsuario) // Assuming IdTalle is the foreign key property in Inventario
        //    .OnDelete(DeleteBehavior.NoAction);
        //ventaConfig.HasOne(v => v.PuntoDeVenta)
        //    .WithOne()
        //    .HasForeignKey<Venta>(i => i.IdPuntoVenta) // Assuming IdTalle is the foreign key property in Inventario
        //    .OnDelete(DeleteBehavior.NoAction);

        var ventaConfig = modelBuilder.Entity<Venta>();
        ventaConfig
            .HasMany(v => v.LineasDeVentas)
            .WithOne(l => l.Venta)
            .OnDelete(DeleteBehavior.Restrict);

        ventaConfig
            .HasMany(v => v.LineasDeVentas)
            .WithOne(l => l.Venta)
            .HasForeignKey(l => l.IdVenta)
            .IsRequired();

        var ptoVtaConfig = modelBuilder.Entity<PuntoDeVenta>();
        ptoVtaConfig
            .HasMany(p => p.Ventas)
            .WithOne(v => v.PuntoDeVenta)
            .HasForeignKey(v => v.IdPuntoVenta)
            .IsRequired();

        //linvenConfig.HasOne(i => i.Venta)
        //    .WithOne()
        //    .HasForeignKey<LineaDeVenta>(i => i.IdVenta) // Assuming IdTalle is the foreign key property in Inventario
        //    .OnDelete(DeleteBehavior.NoAction);
        /*
        var invConfig = modelBuilder.Entity<Inventario>();
        invConfig.HasOne(i => i.Talle)
            .WithOne()
            .HasForeignKey<Inventario>(i => i.IdTalle) // Assuming IdTalle is the foreign key property in Inventario
            .OnDelete(DeleteBehavior.NoAction);*/

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
            //Console.WriteLine(entityType.Name + " : Venta");
            modelBuilder.Entity(entityType).ToTable(entityType.Name, "Ventas");
        }

        // Configure table schema for each entity type
        foreach (var entityType in entityArticulo)
        {
            //Console.WriteLine(entityType.Name + " : Articulo");
            modelBuilder.Entity(entityType).ToTable(entityType.Name, "Articulo");
        }

        // Configure table schema for each entity type
        foreach (var entityType in entityAdmin)
        {
            //Console.WriteLine(entityType.Name + " : Admin");
            modelBuilder.Entity(entityType).ToTable(entityType.Name, "Admin");
        }
    }
}