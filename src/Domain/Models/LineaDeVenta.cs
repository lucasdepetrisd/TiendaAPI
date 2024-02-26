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
    public decimal PorcentajeIVA { get; private set; } = 21;

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

    public LineaDeVenta(int cantidad, Inventario inventario, Venta venta, decimal porcentajeIVA)
    {
        Cantidad = cantidad;
        Inventario = inventario;
        Venta = venta;
        PorcentajeIVA = porcentajeIVA;
    }

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
            NetoGravado = Inventario.Articulo.Costo * (1 + Inventario.Articulo.MargenGanancia / 100);
            MontoIVA = NetoGravado * (PorcentajeIVA / 100);
            Subtotal = NetoGravado + MontoIVA;
        }
        else
        {
            NetoGravado = 0;
            MontoIVA = 0;
            Subtotal = 0;
        }

        return Subtotal;
    }
}
