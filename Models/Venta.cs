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

    public int IdCliente { get; set; }
    [ForeignKey("IdCliente")]
    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Pago? Pago { get; set; }
    public virtual Comprobante? Comprobante { get; set; }

    public int IdTipoDeComprobante { get; set; }
    [ForeignKey("IdTipoDeComprobante")]
    public virtual TipoDeComprobante TipoDeComprobante { get; set; } = null!;

    public int IdUsuario { get; set; }
    [ForeignKey("IdUsuario")]
    public virtual Usuario Usuario { get; set; } = null!;

    public int IdPuntoVenta { get; set; }
    [ForeignKey("IdPuntoVenta")]
    public virtual PuntoDeVenta PuntoDeVenta { get; set; } = null!;

    public virtual ICollection<LineaDeVenta> LineaDeVenta { get; set; } = new List<LineaDeVenta>();
}
