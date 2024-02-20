using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public record MarcaDTO : ShowMarcaDTO
{
    public virtual ICollection<ArticuloDTO> Articulos { get; set; } = new List<ArticuloDTO>();
}

public record ShowMarcaDTO : CreateMarcaDTO
{
    public int IdMarca { get; set; }
}

public record CreateMarcaDTO
{
    public string Descripcion { get; set; } = null!;
}
