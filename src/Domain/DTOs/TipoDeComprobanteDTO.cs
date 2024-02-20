using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record TipoDeComprobanteDTO
{
    public int IdTipoDeComprobante { get; set; }
    public string Nombre { get; set; } = null!;
    public virtual ICollection<ViewCondicionTributariaDTO> CondicionesTributarias { get; set; } = new List<ViewCondicionTributariaDTO>();
}

public record CreateTipoDeComprobanteDTO
{
    public string Nombre { get; set; } = null!;
}

public record ViewTipoDeComprobanteDTO
{
    public int IdTipoDeComprobante { get; set; }
    public string Nombre { get; set; } = null!;
}