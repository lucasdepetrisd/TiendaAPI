using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public record CategoriaDTO
{
    public int IdCategoria { get; init; }
    public string Descripcion { get; init; } = null!;
    public virtual ICollection<ViewArticuloDTO> Articulos { get; set; } = new List<ViewArticuloDTO>();
}

public record CreateCategoriaDTO
{
    public string Descripcion { get; init; } = null!;
}

public record ViewCategoriaDTO
{
    public int IdCategoria { get; init; }
    public string Descripcion { get; init; } = null!;
}