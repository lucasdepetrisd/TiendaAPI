using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Admin.Articulo;

public record ColorDTO
{
    public int IdColor { get; init; }
    public string Nombre { get; init; } = null!;
}

public record CreateColorDTO
{
    public string Nombre { get; init; } = null!;
}
