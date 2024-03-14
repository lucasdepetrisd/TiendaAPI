using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.DTOs.Ventas;

public record PagoDTO
{
    public int IdPago { get; init; }
    public DateTime Fecha { get; init; }
    public decimal MontoTotal { get; init; }
    public string? NroTicket { get; init; }
    public string? NroCae { get; init; }
    public string Estado { get; init; } = null!;
    public string? Observaciones { get; init; }

    public virtual ViewVentaDTO Venta { get; init; } = null!;
}

public record ViewPagoDTO
{
    public int IdPago { get; init; }
    public DateTime Fecha { get; init; }
    public decimal MontoTotal { get; init; }
    public string? NroTicket { get; init; }
    public string? NroCae { get; init; }
    public string Estado { get; init; } = null!;
    public string? Observaciones { get; init; }
    public int IdVenta { get; init; }
}