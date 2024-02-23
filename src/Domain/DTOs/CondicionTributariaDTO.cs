using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record CondicionTributariaDTO
{
    public int IdCondicionTributaria { get; init; }
    public string Descripcion { get; init; } = null!;
    public virtual ViewTipoDeComprobanteDTO TipoDeComprobante { get; init; } = null!;

    //public virtual ICollection<ViewClienteDTO> Clientes { get; init; } = new List<ViewClienteDTO>();
}

public record CreateCondicionTributariaDTO
{
    public string Descripcion { get; init; } = null!;
    public int IdTipoDeComprobante { get; init; }
}

public record ViewCondicionTributariaDTO
{
    public int IdCondicionTributaria { get; init; }
    public string Descripcion { get; init; } = null!;
}
