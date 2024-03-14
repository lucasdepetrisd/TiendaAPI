using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.DTOs.Admin.Articulo;

public record TalleDTO
{
    public int IdTalle { get; init; }
    public string Medida { get; init; } = null!;

    public virtual ViewTipoTalleDTO? TipoTalle { get; init; }

    //public virtual ICollection<Inventario> Inventarios { get; init; } = new List<Inventario>();
}

public record CreateTalleDTO
{
    [Required] public string Medida { get; init; } = null!;

    public virtual int? IdTipoTalle { get; init; }
}

public record ViewTalleDTO
{
    public int IdTalle { get; init; }
    public string Medida { get; init; } = null!;

    public int IdTipoTalle { get; init; }
}