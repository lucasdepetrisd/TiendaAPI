using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record TipoDeComprobanteDTO
{
    public int IdTipoDeComprobante { get; init; }
    public string Nombre { get; init; } = null!;
    public virtual ICollection<ViewCondicionTributariaDTO> CondicionesTributarias { get; init; } = new List<ViewCondicionTributariaDTO>();
}

public record CreateTipoDeComprobanteDTO
{
    public string Nombre { get; init; } = null!;
}

public record ViewTipoDeComprobanteDTO
{
    public int IdTipoDeComprobante { get; init; }
    public string Nombre { get; init; } = null!;
}