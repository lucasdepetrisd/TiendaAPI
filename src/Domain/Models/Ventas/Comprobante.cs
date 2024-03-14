using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Ventas;

public partial class Comprobante
{
    [Key]
    public int IdComprobante { get; set; }

    public long NroComprobante { get; set; }

    public int IdVenta { get; set; }
    [ForeignKey("IdVenta")]
    public virtual Venta Venta { get; set; } = null!;

    private Comprobante() { }

    public Comprobante(long nroCompobante, int idVenta)
    {
        NroComprobante = nroCompobante;
        IdVenta = idVenta;
    }
}
