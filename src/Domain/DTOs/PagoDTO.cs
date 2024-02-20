using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record PagoDTO
{
    public int IdPago { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Monto { get; set; }
    public int Ticket { get; set; }
    public string? Estado { get; set; }
    public string? Observaciones { get; set; }

    public virtual ViewVentaDTO Venta { get; set; } = null!;
}

public record CreatePagoDTO
{
    public DateTime Fecha { get; set; }
    public decimal Monto { get; set; }
    public int Ticket { get; set; }
    public string? Estado { get; set; }
    public string? Observaciones { get; set; }
    
    public int IdVenta { get; set; }
}

public record ViewPagoDTO
{
    public int IdPago { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Monto { get; set; }
    public int Ticket { get; set; }
    public string? Estado { get; set; }
    public string? Observaciones { get; set; }
    public int IdVenta { get; set; }
}