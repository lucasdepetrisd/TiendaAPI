using Application.DTOs.Admin;

namespace Application.DTOs.Ventas;

public record VentaDTO
{
    public int IdVenta { get; init; }
    public DateTime Fecha { get; init; }
    public decimal Monto { get; init; }
    public string Estado { get; init; } = null!;
    public string? Observaciones { get; init; }

    public virtual ViewPagoDTO? Pago { get; init; }
    public virtual ViewComprobanteDTO? Comprobante { get; init; }

    public virtual ViewTipoDeComprobanteDTO TipoDeComprobante { get; init; } = null!;
    public virtual ViewClienteDTO Cliente { get; init; } = null!;
    public virtual ViewUsuarioDTO Usuario { get; init; } = null!;
    public virtual ViewPuntoDeVentaDTO PuntoDeVenta { get; init; } = null!;
    public virtual ICollection<ViewLineaDeVentaDTO> LineasDeVentas { get; init; } = [];
}

public record ViewVentaDTO
{
    public int IdVenta { get; init; }
    public DateTime Fecha { get; init; }
    public decimal Monto { get; init; }
    public string Estado { get; init; } = null!;
    public string? Observaciones { get; init; }

    public int IdPago { get; init; }
    public int IdComprobante { get; init; }
    public int IdCliente { get; init; }
    public int IdUsuario { get; init; }
    public int IdTipoDeComprobante { get; init; }
    public int IdPuntoVenta { get; init; }
}
