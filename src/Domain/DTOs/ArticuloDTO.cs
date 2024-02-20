using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Domain.DTOs;

public record ArticuloDTO
{
    public int IdArticulo { get; init; }
    public int Codigo { get; init; }
    public string Descripcion { get; init; } = null!;
    public decimal Costo { get; init; }
    public int MargenGanancia { get; init; }
    public ViewCategoriaDTO? Categoria { get; set; }
    public ViewMarcaDTO? Marca { get; set; }
    public ViewTipoTalleDTO? TipoTalle { get; set; }
}

public record CreateArticuloDTO
{
    public int Codigo { get; init; }
    public string Descripcion { get; init; } = null!;
    public decimal Costo { get; init; }
    public int MargenGanancia { get; init; }
    
    public int IdCategoria { get; init; }
    public int IdMarca { get; init; }
    public int IdTipoTalle { get; init; }
}

public record ViewArticuloDTO
{
    public int IdArticulo { get; init; }
    public int Codigo { get; init; }
    public string Descripcion { get; init; } = null!;
    public decimal Costo { get; init; }
    public int MargenGanancia { get; init; }

    public int? IdCategoria { get; init; }
    public int? IdMarca { get; init; }
    public int? IdTipoTalle { get; init; }
}