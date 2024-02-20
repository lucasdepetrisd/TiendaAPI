using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record LineaDeVentaDTO
{
    [Key]
    public int IdLineaDeVenta { get; set; }

    public int Cantidad { get; set; }
    
    [Precision(18, 2)]
    public decimal NetoGravado { get; set; }

    [Precision(18, 2)]
    public decimal PorcentajeIVA { get; set; }
    
    [Precision(18, 2)]
    public decimal MontoIVA { get; set; }
    
    [Precision(18, 2)]
    public decimal Subtotal { get; set; }

    public int IdInventario { get; set; }
    public virtual InventarioDTO Inventario { get; set; } = null!;

    public int IdVenta { get; set; }
    public virtual VentaDTO Venta { get; set; } = null!;
}
