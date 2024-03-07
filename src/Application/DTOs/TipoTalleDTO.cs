using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public record TipoTalleDTO
{
    public int IdTipoTalle { get; init; }
    public string Descripcion { get; init; } = null!;

    public virtual ICollection<ViewTalleDTO> Talles { get; init; } = new List<ViewTalleDTO>();
}

public record CreateTipoTalleDTO
{
    public string Descripcion { get; init; } = null!;
}

public record ViewTipoTalleDTO
{
    public int IdTipoTalle { get; init; }
    public string Descripcion { get; init; } = null!;
}