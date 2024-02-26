namespace Domain.DTOs;

public record LineaDeVentaDTO
{
    public int IdLineaDeVenta { get; init; }
    public int Cantidad { get; init; }
    public decimal NetoGravado { get; init; }
    public decimal PorcentajeIVA { get; init; }
    public decimal MontoIVA { get; init; }
    public decimal Subtotal { get; init; }

    public virtual InventarioDTO Inventario { get; init; } = null!;

    public virtual ViewVentaDTO Venta { get; init; } = null!;
}

public record CreateLineaDeVentaDTO
{
    public int Cantidad { get; init; }
    public decimal PorcentajeIVA { get; init; }

    public int IdInventario { get; init; }
    public int IdVenta { get; init; }
}

public record ViewLineaDeVentaDTO
{
    public int IdLineaDeVenta { get; init; }
    public int Cantidad { get; init; }
    public decimal NetoGravado { get; init; }
    public decimal PorcentajeIVA { get; init; }
    public decimal MontoIVA { get; init; }
    public decimal Subtotal { get; init; }

    public int IdInventario { get; init; }
}