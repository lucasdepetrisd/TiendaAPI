using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TiendaAPI.Server.Data;

public partial class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }


    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<Recurso> Recursos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioGrupo> UsuarioGrupos { get; set; }

    public virtual DbSet<UsuarioGrupoTarea> UsuarioGrupoTareas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=TIENDADB;Trusted_Connection=true;TrustServerCertificate=true;Connection Timeout=30;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__885457EE3734E87A");

            entity.ToTable("Cliente");

            entity.Property(e => e.FechaEliminacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Eliminacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.IdGrupo);

            entity.ToTable("Grupo");

            entity.HasIndex(e => new { e.IdGrupo, e.IdProyecto }, "UX_Grupo_Proyecto").IsUnique();

            entity.Property(e => e.FechaEliminacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Eliminacion");
            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.Grupos)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grupo__IdProyect__72C60C4A");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.IdProyecto).HasName("PK__Proyecto__F4888673E7AB00F1");

            entity.ToTable("Proyecto");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaEliminacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Eliminacion");
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Proyecto__IdClie__6EF57B66");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Proyecto__IdUsua__6FE99F9F");
        });

        modelBuilder.Entity<Recurso>(entity =>
        {
            entity.HasKey(e => e.IdRecurso).HasName("PK__Recurso__B91948E960BECD20");

            entity.ToTable("Recurso");

            entity.Property(e => e.FechaEliminacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Eliminacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTareaNavigation).WithMany(p => p.Recursos)
                .HasForeignKey(d => d.IdTarea)
                .HasConstraintName("FK__Recurso__IdTarea__01142BA1");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__3C872F769C8A57F0");

            entity.ToTable("Rol");

            entity.Property(e => e.FechaEliminacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Eliminacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("PK__Tarea__EADE9098A6656C3E");

            entity.ToTable("Tarea");

            entity.HasIndex(e => new { e.IdTarea, e.IdProyecto }, "UX_Tarea_Proyecto").IsUnique();

            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaEliminacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Eliminacion");
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.IdProyecto).IsRequired();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdProyecto)
                .HasConstraintName("FK__Tarea__IdProyect__7A672E12");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97E67B3209");

            entity.ToTable("Usuario");

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dni).HasMaxLength(8);
            entity.Property(e => e.FechaEliminacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Eliminacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Usuario");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuario__IdRol__693CA210");
        });

        modelBuilder.Entity<UsuarioGrupo>(entity =>
        {
            entity.HasKey(e => new { e.IdUsuario, e.IdGrupo }).HasName("PK__UsuarioGrupo");

            entity.ToTable("UsuarioGrupo");

            entity.HasIndex(e => new { e.IdUsuario, e.IdGrupo, e.IdProyecto }, "UX_UsuarioGrupo_Proyecto").IsUnique();

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioGrupos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioGr__IdUsu__3493CFA7");

            entity.HasOne(d => d.Grupo).WithMany(p => p.UsuarioGrupos)
                .HasPrincipalKey(p => new { p.IdGrupo, p.IdProyecto })
                .HasForeignKey(d => new { d.IdGrupo, d.IdProyecto })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioGrupo__339FAB6E");
        });

        modelBuilder.Entity<UsuarioGrupoTarea>(entity =>
        {
            entity.HasKey(e => new { e.IdUsuario, e.IdGrupo, e.IdTarea }).HasName("PK__UsuarioG__418C97FAC38257BF");

            entity.ToTable("UsuarioGrupoTarea");

            entity.HasOne(d => d.Id).WithMany(p => p.UsuarioGrupoTareas)
                .HasPrincipalKey(p => new { p.IdTarea, p.IdProyecto })
                .HasForeignKey(d => new { d.IdTarea, d.IdProyecto })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioGrupoTare__46B27FE2");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.UsuarioGrupoTareas)
                .HasPrincipalKey(p => new { p.IdUsuario, p.IdGrupo, p.IdProyecto })
                .HasForeignKey(d => new { d.IdUsuario, d.IdGrupo, d.IdProyecto })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioGrupoTare__47A6A41B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
