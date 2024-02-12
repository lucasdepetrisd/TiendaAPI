using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class LineaDeVenta
{
    public int Cantidad { get; set; }

    public int NetoGravado { get; set; }

    public int PorcentajeIva { get; set; }

    public int MontoIva { get; set; }

    public decimal Subtotal { get; set; }

    public int IdVenta { get; set; }

    public int IdInventarioArticulo { get; set; }

    public int IdLineaDeVenta { get; set; }

    public virtual Inventario IdInventarioArticuloNavigation { get; set; } = null!;

    public virtual Venta IdVentaNavigation { get; set; } = null!;
}
