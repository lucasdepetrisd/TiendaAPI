using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record PagoDTO
{
    [Key]
    public int IdPago { get; set; }

    public DateTime Fecha { get; set; }

    [Precision(18, 2)]
    public decimal Monto { get; set; }

    public int Ticket { get; set; }

    public string? Estado { get; set; }

    public string? Observaciones { get; set; }

    public int IdVenta { get; set; }
    public virtual VentaDTO Venta { get; set; } = null!;
}
