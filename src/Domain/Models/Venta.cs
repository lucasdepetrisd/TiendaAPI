using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class Venta
{
    [Key]
    public int IdVenta { get; private set; }

    public DateTime Fecha { get; private set; } = DateTime.UtcNow;

    [Precision(18, 2)]
    public decimal Monto { get; private set; }

    public string Estado { get; private set; } = "Pendiente"; //TODO: Convertir a enum. Leer values objects

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

    public void Cancelar()
    {
        if (Estado != "Pendiente")
        {
            throw new InvalidOperationException("La venta solo se puede cancelar si esta en estado Pendiente.");
        }

        Estado = "Cancelada";
    }

    public LineaDeVenta AgregarLineaDeVenta(int cantidad, Inventario inventario)
    {
        if (cantidad > inventario.Cantidad)
        {
            throw new InvalidOperationException($"La cantidad solicitada ({cantidad}) excede la cantidad disponible en el inventario ({inventario.Cantidad}).");
        }

        LineaDeVenta lineaDeVenta = new LineaDeVenta(cantidad, inventario, this);

        Monto += lineaDeVenta.CalcularSubtotal();

        LineasDeVentas.Add(lineaDeVenta);

        return lineaDeVenta;
    }

    public void QuitarLineaDeVenta(int idLineaDeVenta)
    {
        var lineaDeVenta = LineasDeVentas.FirstOrDefault(l => l.IdLineaDeVenta == idLineaDeVenta);

        if (lineaDeVenta != null)
        {
            Monto -= lineaDeVenta.Subtotal;

            LineasDeVentas.Remove(lineaDeVenta);
        }
        else
        {
            throw new InvalidOperationException("La línea de venta especificada no pertenece a esta venta.");
        }
    }

    public void ActualizarMonto()
    {
        Monto = 0;

        foreach (LineaDeVenta lineaDeVenta in LineasDeVentas)
        {
            Monto += lineaDeVenta.Subtotal;
        }
    }
}