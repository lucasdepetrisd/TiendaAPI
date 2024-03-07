namespace Application.DTOs;

public record CondicionTributariaDTO
{
    public int IdCondicionTributaria { get; init; }
    public string Nombre { get; init; } = null!;

    public virtual ICollection<ViewTipoDeComprobanteDTO> TiposDeComprobantesEmisor { get; set; } = new List<ViewTipoDeComprobanteDTO>();
    public virtual ICollection<ViewTipoDeComprobanteDTO> TiposDeComprobantesReceptor { get; set; } = new List<ViewTipoDeComprobanteDTO>();
    public virtual ICollection<ViewClienteDTO> Clientes { get; set; } = new List<ViewClienteDTO>();
}

public record ViewCondicionTributariaDTO
{
    public int IdCondicionTributaria { get; init; }
    public string Nombre { get; init; } = null!;
}
