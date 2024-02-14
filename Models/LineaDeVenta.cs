using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaAPI.Models;

public partial class LineaDeVenta
{
    [Key]
    public int IdLineaDeVenta { get; set; }

    public int Cantidad { get; set; }
    
    [Precision(18, 2)]
    public decimal NetoGravado 
    {
        get
        {
            return Inventario.Articulo.Costo * (1 + Inventario.Articulo.MargenGanancia);
        }
    }

    [Precision(18, 2)]
    public decimal PorcentajeIVA { get; set; }
    
    [Precision(18, 2)]
    public decimal MontoIVA
    {
        get
        {
            return NetoGravado * PorcentajeIVA;
        }
    }
    
    [Precision(18, 2)]
    public decimal Subtotal
    {
        get
        {
            return Cantidad * (NetoGravado + MontoIVA);
        }
    }

    public int IdInventario { get; set; }
    [ForeignKey("IdInventario")]
    public virtual Inventario Inventario { get; set; } = null!;

    public int IdVenta { get; set; }
    [ForeignKey("IdVenta")]
    public virtual Venta Venta { get; set; } = null!;
}
