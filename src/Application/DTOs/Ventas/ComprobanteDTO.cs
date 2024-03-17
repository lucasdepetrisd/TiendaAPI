namespace Application.DTOs.Ventas;

public record ComprobanteDTO
{
    public int IdComprobante { get; init; }
    public long NroComprobante { get; init; }
    public string? NroTicket { get; init; }

    public int IdVenta { get; init; }
    public virtual VentaDTO Venta { get; init; } = null!;
}

public record ViewComprobanteDTO
{
    public int IdComprobante { get; init; }
    public long NroComprobante { get; init; }
    public string? NroTicket { get; init; }

    public int IdVenta { get; init; }
}