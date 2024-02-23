using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record ComprobanteDTO
{
    public int IdComprobante { get; init; }

    public int IdVenta { get; init; }
    public virtual VentaDTO Venta { get; init; } = null!;
}

public record CreateComprobanteDTO
{
    public int IdVenta { get; init; }
}
