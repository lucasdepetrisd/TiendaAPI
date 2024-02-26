using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record InventarioDTO
{
    public int IdInventario { get; init; }
    public int Cantidad { get; init; }

    public virtual ViewSucursalDTO Sucursal { get; init; } = null!;

    public virtual ColorDTO Color { get; init; } = null!;

    public virtual ViewTalleDTO Talle { get; init; } = null!;

    public virtual ArticuloDTO Articulo { get; init; } = null!;
}

public record CreateInventarioDTO
{
    public int Cantidad { get; init; }
    public int IdSucursal { get; init; }
    public int IdColor { get; init; }
    public int IdTalle { get; init; }
    public int IdArticulo { get; init; }
}

public record ViewInventarioDTO
{
    public int IdInventario { get; init; }
    public int Cantidad { get; init; }

    public int IdSucursal { get; init; }
    public int IdColor { get; init; }
    public int IdTalle { get; init; }
    public int IdArticulo { get; init; }
}
