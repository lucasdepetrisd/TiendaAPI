using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public record CategoriaDTO : ShowCategoriaDTO
{
    public virtual ICollection<ArticuloDTO> Articulos { get; set; } = new List<ArticuloDTO>();
}

public record ShowCategoriaDTO
{
    public int IdCategoria { get; init; }
    public string Descripcion { get; init; } = null!;
}

public record CreateCategoriaDTO
{
    public string Descripcion { get; init; } = null!;
}