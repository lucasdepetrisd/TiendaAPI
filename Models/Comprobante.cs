using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class Comprobante
{
    public int IdComprobante { get; set; }

    public int IdVenta { get; set; }

    public virtual Venta IdVentaNavigation { get; set; } = null!;
}
