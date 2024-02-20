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
    public ShowCategoriaDTO? Categoria { get; set; }
    public ShowMarcaDTO? Marca { get; set; }
    public ShowTipoTalleDTO? TipoTalle { get; set; }
}

public record CreateArticuloDTO
{
    public int Codigo { get; init; }
    public string Descripcion { get; init; } = null!;
    public decimal Costo { get; init; }
    public int MargenGanancia { get; init; }
    public int? IdCategoria { get; init; }
    public int? IdMarca { get; init; }
    public int? IdTipoTalle { get; init; }
}

public record ShowArticuloDTO
{
    public int IdArticulo { get; init; }
    public int Codigo { get; init; }
    public string Descripcion { get; init; } = null!;
    public decimal Costo { get; init; }
    public int MargenGanancia { get; init; }
}