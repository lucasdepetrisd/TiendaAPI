using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public record TipoTalleDTO
{
    public int IdTipoTalle { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<TalleDTO> Talles { get; set; } = new List<TalleDTO>();
}

public record CreateTipoTalleDTO
{
    public string Descripcion { get; set; } = null!;
}

public record ShowTipoTalleDTO
{
    public int IdTipoTalle { get; set; }

    public string Descripcion { get; set; } = null!;
}