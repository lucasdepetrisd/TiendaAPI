using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record LineaDeVentaDTO
{
    public int IdLineaDeVenta { get; set; }
    public int Cantidad { get; set; }
    public decimal NetoGravado { get; set; }
    public decimal PorcentajeIVA { get; set; }
    public decimal MontoIVA { get; set; }
    public decimal Subtotal { get; set; }

    public virtual InventarioDTO Inventario { get; set; } = null!;

    public virtual ViewVentaDTO Venta { get; set; } = null!;
}

public record CreateLineaDeVentaDTO
{
    public int IdLineaDeVenta { get; set; }
    public int Cantidad { get; set; }
    public decimal NetoGravado { get; set; }
    public decimal PorcentajeIVA { get; set; }
    public decimal MontoIVA { get; set; }
    public decimal Subtotal { get; set; }

    public int IdInventario { get; set; }
    public int IdVenta { get; set; }
}
