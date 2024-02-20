using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record ArticuloDTO : ShowArticuloDTO
{
    public ShowCategoriaDTO? Categoria { get; set; }
    public ShowMarcaDTO? Marca { get; set; }
    public ShowTipoTalleDTO? TipoTalle { get; set; }
}

public record CreateArticuloDTO : ShowArticuloDTO
{
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
    public int PorcentajeIVA { get; init; }
    public int MargenGanancia { get; init; }
}