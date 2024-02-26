using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class Venta
{
    [Key]
    public int IdVenta { get; private set; }

    public DateTime Fecha { get; private set; } = DateTime.Now;

    [Precision(18, 2)]
    public decimal Monto { get; private set; }

    public string Estado { get; private set; } = "Pendiente";

    public string? Observaciones { get; private set; } = "Ninguna";

    public virtual Pago? Pago { get; private set; }
    public virtual Comprobante? Comprobante { get; private set; }

    public int? IdCliente { get; private set; }
    [ForeignKey("IdCliente")]
    public virtual Cliente? Cliente { get; private set; }

    public int? IdTipoDeComprobante { get; private set; }
    [ForeignKey("IdTipoDeComprobante")]
    public virtual TipoDeComprobante? TipoDeComprobante { get; private set; }

    public int IdUsuario { get; private set; }
    [ForeignKey("IdUsuario")]
    [DeleteBehavior(DeleteBehavior.ClientSetNull)]
    public virtual Usuario Usuario { get; private set; } = null!;

    public int IdPuntoVenta { get; private set; }
    public virtual PuntoDeVenta PuntoDeVenta { get; private set; } = null!;

    public virtual ICollection<LineaDeVenta> LineasDeVentas { get; private set; } = new List<LineaDeVenta>();

    private Venta() { }

    public Venta(int usuarioId, int puntoDeVentaId)
    {
        IdUsuario = usuarioId;
        IdPuntoVenta = puntoDeVentaId;
    }

    public Venta(Usuario usuario, PuntoDeVenta puntoDeVenta)
    {
        Usuario = usuario;
        PuntoDeVenta = puntoDeVenta;
    }

    public LineaDeVenta CrearLineaDeVenta(int cantidad, Inventario inventario, decimal porcentajeIVA)
    {
        LineaDeVenta lineaDeVenta = new LineaDeVenta(cantidad, inventario, this, porcentajeIVA);

        Monto += lineaDeVenta.CalcularSubtotal();

        LineasDeVentas.Add(lineaDeVenta);

        return lineaDeVenta;
    }
}
