using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class Venta
{
    public int IdVenta { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Monto { get; set; }

    public string Estado { get; set; } = null!;

    public string? Observaciones { get; set; }

    public int NumeroPtoVenta { get; set; }

    public int DniCliente { get; set; }

    public int LegajoEmpleado { get; set; }

    public int IdTipoDeComprobante { get; set; }

    public virtual ICollection<Comprobante> Comprobante { get; set; } = new List<Comprobante>();

    public virtual Cliente DniClienteNavigation { get; set; } = null!;

    public virtual TipoDeComprobante IdTipoDeComprobanteNavigation { get; set; } = null!;

    public virtual Empleado LegajoEmpleadoNavigation { get; set; } = null!;

    public virtual ICollection<LineaDeVenta> LineaDeVenta { get; set; } = new List<LineaDeVenta>();

    public virtual PuntoDeVenta NumeroPtoVentaNavigation { get; set; } = null!;
}
