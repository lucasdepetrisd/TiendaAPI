namespace Application.DTOs.Admin;

public record CondicionTributariaDTO
{
    public int IdCondicionTributaria { get; init; }
    public string Nombre { get; init; } = null!;

    public virtual ICollection<ViewClienteDTO> Clientes { get; set; } = [];
}

public record ViewCondicionTributariaDTO
{
    public int IdCondicionTributaria { get; init; }
    public string Nombre { get; init; } = null!;
}
