using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class LineaDeVenta
{
    /*public LineaDeVenta(Inventario inventario, int porcentajeiva)
    {
        if (inventario != null && inventario.Articulo != null)
        {
            NetoGravado = inventario.Articulo.Costo * (1 + inventario.Articulo.MargenGanancia);
            MontoIVA = NetoGravado * porcentajeiva;
            Subtotal = Cantidad * (NetoGravado + MontoIVA);
        }
        else
        {
            NetoGravado = 0;
            MontoIVA = 0;
            Subtotal = 0;
        }
    }*/

    [Key]
    public int IdLineaDeVenta { get; set; }

    public int Cantidad { get; set; }

    [Precision(18, 2)]
    public decimal NetoGravado { get; private set; }

    [Precision(18, 2)]
    public decimal PorcentajeIVA { get; set; }

    [Precision(18, 2)]
    public decimal MontoIVA { get; private set; }

    [Precision(18, 2)]
    public decimal Subtotal { get; private set; }

    public int IdInventario { get; set; }
    [ForeignKey("IdInventario")]
    public virtual Inventario Inventario { get; set; } = null!;

    public int IdVenta { get; set; }
    [ForeignKey("IdVenta")]
    public virtual Venta Venta { get; set; } = null!;
}
