using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class LineaDeVenta
{
    [Key]
    public int IdLineaDeVenta { get; private set; }

    public int Cantidad { get; private set; }

    [Precision(18, 2)]
    public decimal NetoGravado { get; private set; }

    [Precision(18, 2)]
    public decimal MontoIVA { get; private set; }

    [Precision(18, 2)]
    public decimal Subtotal { get; private set; }

    public int IdInventario { get; private set; }
    [ForeignKey("IdInventario")]
    public virtual Inventario Inventario { get; private set; } = null!;

    public int IdVenta { get; private set; }
    [ForeignKey("IdVenta")]
    public virtual Venta Venta { get; private set; } = null!;

    private LineaDeVenta() { }

    public LineaDeVenta(int cantidad, Inventario inventario, Venta venta)
    {
        Cantidad = cantidad;
        Inventario = inventario;
        Venta = venta;
    }

    public decimal CalcularSubtotal()
    {
        if (Inventario.Articulo != null)
        {
            decimal costoTotal = Cantidad * Inventario.Articulo.Costo;

            NetoGravado = costoTotal * (1 + Inventario.Articulo.MargenGanancia / 100);
            MontoIVA = NetoGravado * (Inventario.Articulo.PorcentajeIVA / 100);

            NetoGravado = decimal.Round(NetoGravado, 2);
            MontoIVA = decimal.Round(MontoIVA, 2);

            Subtotal = NetoGravado + MontoIVA;
        }
        else
        {
            throw new Exception($"No articulo on LineaDeVenta with ID {IdLineaDeVenta}");
        }

        return Subtotal;
    }
}
