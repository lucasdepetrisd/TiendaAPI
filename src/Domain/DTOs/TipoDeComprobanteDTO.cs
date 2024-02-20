using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record TipoDeComprobanteDTO
{
    [Key]
    public int IdTipoDeComprobante { get; set; }

    public string Nombre { get; set; } = null!;

    /*public int IdCondicionTributaria { get; set; }
    [ForeignKey("IdCondicionTributaria")]
    public virtual CondicionTributaria CondicionTributaria { get; set; } = null!;*/
    //TODO: Añadir relación 1 a 1
    public virtual ICollection<CondicionTributariaDTO> CondicionesTributarias { get; set; } = new List<CondicionTributariaDTO>();
}
