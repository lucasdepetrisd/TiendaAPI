using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class Pago
{
    public DateTime Fecha { get; set; }

    public decimal Monto { get; set; }

    public int Ticket { get; set; }

    public bool Estado { get; set; }

    public string? Observaciones { get; set; }

    public int IdVenta { get; set; }

    public virtual Venta IdVentaNavigation { get; set; } = null!;
}
