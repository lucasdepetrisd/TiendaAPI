using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record TalleDTO
{
    [Key]
    public int IdTalle { get; set; }

    public string? Medida { get; set; }

    public int? IdTipoTalle { get; set; }
    public virtual TipoTalleDTO? TipoTalle { get; set; }
}
