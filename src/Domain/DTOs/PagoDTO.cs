using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record PagoDTO
{
    public int IdPago { get; init; }
    public DateTime Fecha { get; init; }
    public decimal Monto { get; init; }
    public int Ticket { get; init; }
    public string? Estado { get; init; }
    public string? Observaciones { get; init; }

    public virtual ViewVentaDTO Venta { get; init; } = null!;
}

public record CreatePagoDTO
{
    public DateTime Fecha { get; init; }
    public decimal Monto { get; init; }
    public int Ticket { get; init; }
    public string? Estado { get; init; }
    public string? Observaciones { get; init; }
    
    public int IdVenta { get; init; }
}

public record ViewPagoDTO
{
    public int IdPago { get; init; }
    public DateTime Fecha { get; init; }
    public decimal Monto { get; init; }
    public int Ticket { get; init; }
    public string? Estado { get; init; }
    public string? Observaciones { get; init; }
    public int IdVenta { get; init; }
}