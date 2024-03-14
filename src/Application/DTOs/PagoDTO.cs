using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.DTOs;

public record PagoDTO
{
    public int IdPago { get; init; }
    public DateTime Fecha { get; init; }
    public decimal Monto { get; init; }
    public required string NroTicket { get; init; }
    public required string Estado { get; init; }
    public string? Observaciones { get; init; }

    public virtual ViewVentaDTO Venta { get; init; } = null!;
}

public record ViewPagoDTO
{
    public int IdPago { get; init; }
    public DateTime Fecha { get; init; }
    public decimal Monto { get; init; }
    public required string NroTicket { get; init; }
    public required string Estado { get; init; }
    public string? Observaciones { get; init; }
    public int IdVenta { get; init; }
}