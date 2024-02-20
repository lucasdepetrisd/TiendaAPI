using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record TalleDTO
{
    public int IdTalle { get; set; }
    public string Medida { get; set; } = null!;
    
    public virtual TipoTalleDTO? TipoTalle { get; set; }
    
    //public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
}

public record CreateTalleDTO
{
    public string Medida { get; set; } = null!;
}

public record ViewTalleDTO
{
    public int IdTalle { get; set; }
    public string Medida { get; set; } = null!;

    public int IdTipoTalle { get; set; }
}