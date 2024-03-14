using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.DTOs.Ventas;

public record ComprobanteDTO
{
    public int IdComprobante { get; init; }

    public long NroComprobante { get; init; }

    public int IdVenta { get; init; }
    public virtual VentaDTO Venta { get; init; } = null!;
}

public record ViewComprobanteDTO
{
    public int IdComprobante { get; init; }

    public long NroComprobante { get; init; }

    public int IdVenta { get; init; }
}