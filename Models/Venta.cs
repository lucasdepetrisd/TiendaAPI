using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaAPI.Models;

public partial class Venta
{
    [Key]
    public int IdVenta { get; set; }

    public DateTime Fecha { get; set; }

    [Precision(18, 2)]
    public decimal Monto { get; set; }

    public string Estado { get; set; } = null!;

    public string? Observaciones { get; set; }

    public virtual Pago? Pago { get; set; }
    public virtual Comprobante? Comprobante { get; set; }

    public int IdCliente { get; set; }
    [ForeignKey("IdCliente")]
    public virtual Cliente Cliente { get; set; } = null!;

    public int IdUsuario { get; set; }
    [ForeignKey("IdUsuario")]
    [DeleteBehavior(DeleteBehavior.ClientSetNull)]
    public virtual Usuario Usuario { get; set; } = null!;

    public int IdTipoDeComprobante { get; set; }
    [ForeignKey("IdTipoDeComprobante")]
    [DeleteBehavior(DeleteBehavior.ClientSetNull)]
    public virtual TipoDeComprobante TipoDeComprobante { get; set; } = null!;

    public int IdPuntoVenta { get; set; }
    public virtual PuntoDeVenta PuntoDeVenta { get; set; } = null!;

    public virtual ICollection<LineaDeVenta> LineasDeVentas { get; set; } = new List<LineaDeVenta>();
}
