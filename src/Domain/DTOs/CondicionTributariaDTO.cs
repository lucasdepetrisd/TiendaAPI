using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record CondicionTributariaDTO
{
    public int IdCondicionTributaria { get; set; }
    public string Descripcion { get; set; } = null!;
    public virtual ViewTipoDeComprobanteDTO TipoDeComprobante { get; set; } = null!;

    //public virtual ICollection<ViewClienteDTO> Clientes { get; set; } = new List<ViewClienteDTO>();
}

public record CreateCondicionTributariaDTO
{
    public int IdCondicionTributaria { get; set; }
    public string Descripcion { get; set; } = null!;
    public int IdTipoDeComprobante { get; set; }
}

public record ViewCondicionTributariaDTO
{
    public int IdCondicionTributaria { get; set; }
    public string Descripcion { get; set; } = null!;
}
