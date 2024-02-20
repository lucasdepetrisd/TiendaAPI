using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public record MarcaDTO
{
    public int IdMarca { get; set; }
    public string Descripcion { get; set; } = null!;
    public virtual ICollection<ViewArticuloDTO> Articulos { get; set; } = new List<ViewArticuloDTO>();
}

public record CreateMarcaDTO
{
    public string Descripcion { get; set; } = null!;
}

public record ViewMarcaDTO
{
    public int IdMarca { get; set; }
    public string Descripcion { get; set; } = null!;
}
