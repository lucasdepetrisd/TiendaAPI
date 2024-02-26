using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{
    public interface ITiendaContext
    {
        DbSet<Articulo> Articulo { get; set; }
        DbSet<Categoria> Categoria { get; set; }
        DbSet<Cliente> Cliente { get; set; }
        DbSet<Color> Color { get; set; }
        DbSet<Comprobante> Comprobante { get; set; }
        DbSet<CondicionTributaria> CondicionTributaria { get; set; }
        DbSet<Empleado> Empleado { get; set; }
        DbSet<Inventario> Inventario { get; set; }
        DbSet<LineaDeVenta> LineaDeVenta { get; set; }
        DbSet<Marca> Marca { get; set; }
        DbSet<Pago> Pago { get; set; }
        DbSet<PuntoDeVenta> PuntoDeVenta { get; set; }
        DbSet<Rol> Rol { get; set; }
        DbSet<Sesion> Sesion { get; set; }
        DbSet<Sucursal> Sucursal { get; set; }
        DbSet<Talle> Talle { get; set; }
        DbSet<Tienda> Tienda { get; set; }
        DbSet<TipoDeComprobante> TipoDeComprobante { get; set; }
        DbSet<TipoTalle> TipoTalle { get; set; }
        DbSet<Usuario> Usuario { get; set; }
        DbSet<Venta> Venta { get; set; }

        // Añado para ser utilizado en BaseController.
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
