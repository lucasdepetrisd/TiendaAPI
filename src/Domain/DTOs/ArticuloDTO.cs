namespace Domain.DTOs;

public record ArticuloDTO
{
    public int IdArticulo { get; init; }
    public string Codigo { get; init; } = null!;
    public string Descripcion { get; init; } = null!;
    public decimal Costo { get; init; }
    public int MargenGanancia { get; init; }
    public ViewCategoriaDTO? Categoria { get; init; }
    public ViewMarcaDTO? Marca { get; init; }
    public ViewTipoTalleDTO? TipoTalle { get; init; }
}

public record CreateArticuloDTO
{
    public string Codigo { get; init; } = null!;
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
    public string Codigo { get; init; } = null!;
    public string Descripcion { get; init; } = null!;
    public decimal Costo { get; init; }
    public int MargenGanancia { get; init; }

    public int? IdCategoria { get; init; }
    public int? IdMarca { get; init; }
    public int? IdTipoTalle { get; init; }
}