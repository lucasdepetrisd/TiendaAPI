using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TiendaAPI.Models;

public partial class TiendaContext : DbContext
{
    public TiendaContext()
    {
    }

    public TiendaContext(DbContextOptions<TiendaContext> options)
        : base(options)
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=THORS\\SQLEXPRESS;Database=Tienda;Trusted_Connection=true;TrustServerCertificate=Yes;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__articulo__40F9A207C0631BA2");

            entity.ToTable("articulo", "Articulo");

            entity.Property(e => e.Codigo)
                .ValueGeneratedNever()
                .HasColumnName("codigo");
            entity.Property(e => e.Costo)
                .HasColumnType("numeric(8, 2)")
                .HasColumnName("costo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.IdMarca).HasColumnName("idMarca");
            entity.Property(e => e.IdTipoTalle).HasColumnName("idTipoTalle");
            entity.Property(e => e.Iva).HasColumnName("IVA");
            entity.Property(e => e.MargenGanancia).HasColumnName("margenGanancia");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Articulo)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__articulo__idCate__5BE2A6F2");

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Articulo)
                .HasForeignKey(d => d.IdMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__articulo__idMarc__5CD6CB2B");

            entity.HasOne(d => d.IdTipoTalleNavigation).WithMany(p => p.Articulo)
                .HasForeignKey(d => d.IdTipoTalle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__articulo__idTipo__41EDCAC5");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__categori__8A3D240CB58255A9");

            entity.ToTable("categoria", "Articulo");

            entity.Property(e => e.IdCategoria)
                .ValueGeneratedNever()
                .HasColumnName("idCategoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Dni).HasName("PK__cliente__D87608A608379B4F");

            entity.ToTable("cliente", "Venta");

            entity.Property(e => e.Dni)
                .ValueGeneratedNever()
                .HasColumnName("dni");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Cuil).HasColumnName("cuil");
            entity.Property(e => e.Domicilio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("domicilio");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdCondicionTributaria).HasColumnName("idCondicionTributaria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");

            entity.HasOne(d => d.IdCondicionTributariaNavigation).WithMany(p => p.Cliente)
                .HasForeignKey(d => d.IdCondicionTributaria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cliente__idCondi__531856C7");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.IdColor).HasName("PK__color__504A3B88F74C3770");

            entity.ToTable("color", "Articulo");

            entity.Property(e => e.IdColor)
                .ValueGeneratedNever()
                .HasColumnName("idColor");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Comprobante>(entity =>
        {
            entity.HasKey(e => e.IdComprobante).HasName("PK__comproba__BF4D8CF366135E87");

            entity.ToTable("comprobante", "Venta");

            entity.Property(e => e.IdComprobante)
                .ValueGeneratedNever()
                .HasColumnName("idComprobante");
            entity.Property(e => e.IdVenta).HasColumnName("idVenta");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.Comprobante)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__comproban__idVen__7849DB76");
        });

        modelBuilder.Entity<CondicionTributaria>(entity =>
        {
            entity.HasKey(e => e.IdCondicionTributaria).HasName("PK__condicio__9E34510FD33425BF");

            entity.ToTable("condicionTributaria", "Venta");

            entity.Property(e => e.IdCondicionTributaria)
                .ValueGeneratedNever()
                .HasColumnName("idCondicionTributaria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.LegajoEmpleado).HasName("PK__empleado__818C9F861F66CC65");

            entity.ToTable("empleado", "Venta");

            entity.Property(e => e.LegajoEmpleado)
                .ValueGeneratedNever()
                .HasColumnName("legajoEmpleado");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("usuario");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Empleado)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__empleado__idSucu__6754599E");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.IdInventarioArticulo).HasName("PK__inventar__6180102DBC747281");

            entity.ToTable("inventario", "Articulo");

            entity.Property(e => e.IdInventarioArticulo)
                .ValueGeneratedNever()
                .HasColumnName("idInventarioArticulo");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.IdColor).HasColumnName("idColor");
            entity.Property(e => e.IdMedida).HasColumnName("idMedida");
            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");

            entity.HasOne(d => d.CodigoNavigation).WithMany(p => p.Inventario)
                .HasForeignKey(d => d.Codigo)
                .HasConstraintName("FK__inventari__codig__6E01572D");

            entity.HasOne(d => d.IdColorNavigation).WithMany(p => p.Inventario)
                .HasForeignKey(d => d.IdColor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__inventari__idCol__6EF57B66");

            entity.HasOne(d => d.IdMedidaNavigation).WithMany(p => p.Inventario)
                .HasForeignKey(d => d.IdMedida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__inventari__idMed__46B27FE2");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Inventario)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__inventari__idSuc__6FE99F9F");
        });

        modelBuilder.Entity<LineaDeVenta>(entity =>
        {
            entity.HasKey(e => e.IdLineaDeVenta).HasName("PK__lineaDeV__2F800F238B71F4C8");

            entity.ToTable("lineaDeVenta", "Venta");

            entity.Property(e => e.IdLineaDeVenta)
                .ValueGeneratedNever()
                .HasColumnName("idLineaDeVenta");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdInventarioArticulo).HasColumnName("idInventarioArticulo");
            entity.Property(e => e.IdVenta).HasColumnName("idVenta");
            entity.Property(e => e.MontoIva).HasColumnName("montoIVA");
            entity.Property(e => e.NetoGravado).HasColumnName("netoGravado");
            entity.Property(e => e.PorcentajeIva).HasColumnName("porcentajeIVA");
            entity.Property(e => e.Subtotal)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("subtotal");

            entity.HasOne(d => d.IdInventarioArticuloNavigation).WithMany(p => p.LineaDeVenta)
                .HasForeignKey(d => d.IdInventarioArticulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__lineaDeVe__idInv__4E53A1AA");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.LineaDeVenta)
                .HasForeignKey(d => d.IdVenta)
                .HasConstraintName("FK__lineaDeVe__idVen__40F9A68C");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.IdMarca).HasName("PK__marca__703318121D9B1C0F");

            entity.ToTable("marca", "Articulo");

            entity.Property(e => e.IdMarca)
                .ValueGeneratedNever()
                .HasColumnName("idMarca");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("pago", "Venta");

            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.IdVenta).HasColumnName("idVenta");
            entity.Property(e => e.Monto)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("monto");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("observaciones");
            entity.Property(e => e.Ticket).HasColumnName("ticket");

            entity.HasOne(d => d.IdVentaNavigation).WithMany()
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__pago__idVenta__503BEA1C");
        });

        modelBuilder.Entity<PuntoDeVenta>(entity =>
        {
            entity.HasKey(e => e.NumeroPtoVenta).HasName("PK__puntoDeV__FC77F2102BA3FE17");

            entity.ToTable("puntoDeVenta", "Venta");

            entity.Property(e => e.NumeroPtoVenta)
                .ValueGeneratedNever()
                .HasColumnName("numeroPtoVenta");
            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.PuntoDeVenta)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__puntoDeVe__idSuc__6477ECF3");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__rol__3C872F768D0AE1F7");

            entity.ToTable("rol", "Venta");

            entity.Property(e => e.IdRol)
                .ValueGeneratedNever()
                .HasColumnName("idRol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.IdSucursal).HasName("PK__sucursal__F707694C455677A7");

            entity.ToTable("sucursal", "Venta");

            entity.Property(e => e.IdSucursal)
                .ValueGeneratedNever()
                .HasColumnName("idSucursal");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.Cuit).HasColumnName("cuit");
            entity.Property(e => e.Domicilio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("domicilio");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");

            entity.HasOne(d => d.CuitNavigation).WithMany(p => p.Sucursal)
                .HasForeignKey(d => d.Cuit)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__sucursal__cuit__619B8048");
        });

        modelBuilder.Entity<Talle>(entity =>
        {
            entity.HasKey(e => e.IdMedida).HasName("PK__talle__4E0391E840A367C8");

            entity.ToTable("talle", "Articulo");

            entity.Property(e => e.IdMedida)
                .ValueGeneratedNever()
                .HasColumnName("idMedida");
            entity.Property(e => e.IdTipoTalle).HasColumnName("idTipoTalle");
            entity.Property(e => e.Medida)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("medida");

            entity.HasOne(d => d.IdTipoTalleNavigation).WithMany(p => p.Talle)
                .HasForeignKey(d => d.IdTipoTalle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__talle__idTipoTal__45BE5BA9");
        });

        modelBuilder.Entity<Tienda>(entity =>
        {
            entity.HasKey(e => e.Cuit).HasName("PK__tienda__2CDD9896A5330FF3");

            entity.ToTable("tienda", "Venta");

            entity.Property(e => e.Cuit)
                .ValueGeneratedNever()
                .HasColumnName("cuit");
            entity.Property(e => e.IdCondicionTributaria).HasColumnName("idCondicionTributaria");

            entity.HasOne(d => d.IdCondicionTributariaNavigation).WithMany(p => p.Tienda)
                .HasForeignKey(d => d.IdCondicionTributaria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tienda__idCondic__540C7B00");
        });

        modelBuilder.Entity<TipoDeComprobante>(entity =>
        {
            entity.HasKey(e => e.IdTipoDeComprobante).HasName("PK__tipoDeCo__A6DD7DAABB429969");

            entity.ToTable("tipoDeComprobante", "Venta");

            entity.Property(e => e.IdTipoDeComprobante)
                .ValueGeneratedNever()
                .HasColumnName("idTipoDeComprobante");
            entity.Property(e => e.IdCondicionTributaria).HasColumnName("idCondicionTributaria");
            entity.Property(e => e.NombreTipo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreTipo");

            entity.HasOne(d => d.IdCondicionTributariaNavigation).WithMany(p => p.TipoDeComprobante)
                .HasForeignKey(d => d.IdCondicionTributaria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tipoDeCom__idCon__625A9A57");
        });

        modelBuilder.Entity<TipoTalle>(entity =>
        {
            entity.HasKey(e => e.IdTipoTalle).HasName("PK__tipoTall__C71D5769F90D9EF2");

            entity.ToTable("tipoTalle", "Articulo");

            entity.Property(e => e.IdTipoTalle)
                .ValueGeneratedNever()
                .HasColumnName("idTipoTalle");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuario__645723A6B2AFC3D1");

            entity.ToTable("usuario", "Venta");

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("idUsuario");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.LegajoEmpleado).HasColumnName("legajoEmpleado");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuario__idRol__7D0E9093");

            entity.HasOne(d => d.LegajoEmpleadoNavigation).WithMany(p => p.UsuarioNavigation)
                .HasForeignKey(d => d.LegajoEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuario__legajoE__7E02B4CC");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__venta__077D5614CCDFBEF1");

            entity.ToTable("venta", "Venta");

            entity.Property(e => e.IdVenta)
                .ValueGeneratedNever()
                .HasColumnName("idVenta");
            entity.Property(e => e.DniCliente).HasColumnName("dniCliente");
            entity.Property(e => e.Estado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.IdTipoDeComprobante).HasColumnName("idTipoDeComprobante");
            entity.Property(e => e.LegajoEmpleado).HasColumnName("legajoEmpleado");
            entity.Property(e => e.Monto)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("monto");
            entity.Property(e => e.NumeroPtoVenta).HasColumnName("numeroPtoVenta");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("observaciones");

            entity.HasOne(d => d.DniClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.DniCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__venta__dniClient__3D2915A8");

            entity.HasOne(d => d.IdTipoDeComprobanteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdTipoDeComprobante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__venta__idTipoDeC__756D6ECB");

            entity.HasOne(d => d.LegajoEmpleadoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.LegajoEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__venta__legajoEmp__3E1D39E1");

            entity.HasOne(d => d.NumeroPtoVentaNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.NumeroPtoVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__venta__numeroPto__3C34F16F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
