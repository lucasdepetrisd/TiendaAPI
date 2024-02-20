using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record ComprobanteDTO
{
    public int IdComprobante { get; set; }

    public int IdVenta { get; set; }
    public virtual VentaDTO Venta { get; set; } = null!;
}
