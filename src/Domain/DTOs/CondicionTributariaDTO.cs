using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record CondicionTributariaDTO
{
    public int IdCondicionTributaria { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual TiendaDTO? Tienda { get; set; }

    public int IdTipoDeComprobante { get; set; }
    public virtual TipoDeComprobanteDTO TipoDeComprobante { get; set; } = null!;
    public virtual ICollection<ClienteDTO> Clientes { get; set; } = new List<ClienteDTO>();
}
