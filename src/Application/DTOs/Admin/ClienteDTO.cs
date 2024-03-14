using System.ComponentModel.DataAnnotations;
using Application.DTOs.Ventas;

namespace Application.DTOs.Admin;

public record ClienteDTO
{
    public int IdCliente { get; init; }
    public string TipoDocumento { get; init; } = null!;
    public string NroDocumento { get; init; } = null!;
    public string Nombre { get; init; } = null!;
    public string Apellido { get; init; } = null!;
    public string? Telefono { get; init; }
    public string? Email { get; init; }
    public string Domicilio { get; init; } = null!;

    public virtual ViewCondicionTributariaDTO? CondicionTributaria { get; init; }

    public virtual ICollection<ViewVentaDTO> Ventas { get; init; } = [];
}

public record CreateClienteDTO
{
    [Required] public string TipoDocumento { get; init; } = null!;
    [Required] public string NroDocumento { get; init; } = null!;
    [Required] public string Nombre { get; init; } = null!;
    [Required] public string Apellido { get; init; } = null!;
    public string? Telefono { get; init; }
    public string? Email { get; init; }
    [Required] public string Domicilio { get; init; } = null!;
    [Required] public int IdCondicionTributaria { get; init; }
}

public record ViewClienteDTO
{
    public int IdCliente { get; init; }
    public string NroDocumento { get; init; } = null!;
    public string TipoDocumento { get; init; } = null!;
    public string Nombre { get; init; } = null!;
    public string Apellido { get; init; } = null!;
    public string? Telefono { get; init; }
    public string? Email { get; init; }
    public string Domicilio { get; init; } = null!;

    public virtual ViewCondicionTributariaDTO? CondicionTributaria { get; init; }
}
