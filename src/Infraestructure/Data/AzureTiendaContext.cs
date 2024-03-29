using Domain.Data;
using Domain.Models.Admin;
using Domain.Models.Articulo;
using Domain.Models.Ventas;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data;

public partial class AzureTiendaContext : DbContext, ITiendaContext
{
    public AzureTiendaContext(DbContextOptions<AzureTiendaContext> options) : base(options)
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

    public virtual DbSet<Sesion> Sesion { get; set; } // = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("AzureSQL"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AzureTiendaContext).Assembly);

        modelBuilder.Entity<CondicionTributaria>(condTrib =>
        {
            condTrib
                .Property(e => e.Nombre)
                .HasConversion<string>();

            condTrib
                .Property(e => e.IdCondicionTributaria)
                .HasConversion<int>();

            condTrib.HasData(
                Enum.GetValues(typeof(IdCondicionTributaria))
                    .Cast<IdCondicionTributaria>()
                    .Select(c => new CondicionTributaria()
                    {
                        IdCondicionTributaria = c,
                        Nombre = c.ToString()
                    })
                );
        });

        modelBuilder.Entity<Pago>(pago =>
        {
            pago
                .Property(e => e.Estado)
                .HasConversion<string>();
        });

        modelBuilder.Entity<TipoDeComprobante>(tipCompConfig =>
        {
            tipCompConfig.HasOne(t => t.CondicionTributariaEmisor)
                .WithMany()
                .HasForeignKey(t => t.IdCondicionTributariaEmisor)
                .OnDelete(DeleteBehavior.ClientSetNull);

            tipCompConfig
                .Property(c => c.IdCondicionTributariaEmisor)
                .HasConversion<int>();

            tipCompConfig.HasOne(t => t.CondicionTributariaReceptor)
                .WithMany()
                .HasForeignKey(t => t.IdCondicionTributariaReceptor)
                .OnDelete(DeleteBehavior.ClientSetNull);

            tipCompConfig
                .Property(c => c.IdCondicionTributariaReceptor)
                .HasConversion<int>();
        });

        modelBuilder.Entity<Venta>(venta =>
        {
            venta.HasOne(d => d.TipoDeComprobante).WithMany(p => p.Ventas)
                .HasForeignKey(d => d.IdTipoDeComprobante)
                .OnDelete(DeleteBehavior.ClientSetNull);

            venta.HasOne(d => d.Usuario).WithMany(p => p.Ventas)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull);

            venta.HasOne(d => d.PuntoDeVenta).WithMany(p => p.Ventas)
                .HasForeignKey(d => d.IdPuntoVenta)
                .OnDelete(DeleteBehavior.ClientSetNull);

            venta
                .Property(e => e.Estado)
                .HasConversion<string>();
        });

        modelBuilder.Entity<LineaDeVenta>(lineaDeVenta =>
        {
            lineaDeVenta.HasOne(d => d.Venta).WithMany(p => p.LineasDeVentas)
                .HasForeignKey(d => d.IdVenta);
        });

        modelBuilder.Entity<Cliente>(cliente =>
        {
            cliente
                .Property(c => c.IdCondicionTributaria)
                .HasConversion<int>();
        });

        modelBuilder.Entity<Tienda>(tienda =>
        {
            tienda
                .Property(c => c.IdCondicionTributaria)
                .HasConversion<int>();
        });

        modelBuilder.Entity<Usuario>(usuario =>
        {
            usuario
                .HasIndex(u => u.IdEmpleado)
                .IsUnique();
        });

        modelBuilder.Entity<Sesion>(sesion =>
        {
            sesion
                .HasOne(d => d.PuntoDeVenta)
                .WithMany(p => p.Sesiones)
                .HasForeignKey(d => d.IdPuntoDeVenta);
            //.OnDelete(DeleteBehavior.ClientSetNull);

            //sesion.Property(s => s.IdSesion).ValueGeneratedNever();//.UseIdentityColumn();
        });

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
