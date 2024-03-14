using Application.DTOs.Admin;

namespace Application.DTOs.Ventas;

public record TipoDeComprobanteDTO
{
    public int IdTipoDeComprobante { get; init; }
    public string Nombre { get; init; } = null!;
    public ViewCondicionTributariaDTO CondicionTributariaEmisor { get; set; } = null!;
    public ViewCondicionTributariaDTO CondicionTributariaReceptor { get; set; } = null!;
}

public record CreateTipoDeComprobanteDTO
{
    public string Nombre { get; init; } = null!;
}

public record ViewTipoDeComprobanteDTO
{
    public int IdTipoDeComprobante { get; init; }
    public string Nombre { get; init; } = null!;
    public int IdCondicionTributariaEmisor { get; init; }
    public int IdCondicionTributariaReceptor { get; init; }
}