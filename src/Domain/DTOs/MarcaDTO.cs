using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public record MarcaDTO
{
    public int IdMarca { get; init; }
    public string Descripcion { get; init; } = null!;
    public virtual ICollection<ViewArticuloDTO> Articulos { get; init; } = new List<ViewArticuloDTO>();
}

public record CreateMarcaDTO
{
    public string Descripcion { get; init; } = null!;
}

public record ViewMarcaDTO
{
    public int IdMarca { get; init; }
    public string Descripcion { get; init; } = null!;
}
