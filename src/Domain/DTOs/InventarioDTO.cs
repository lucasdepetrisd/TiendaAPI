using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record InventarioDTO
{
    public int IdInventario { get; set; }
    public int Cantidad { get; set; }

    public virtual ViewSucursalDTO Sucursal { get; set; } = null!;

    public virtual ColorDTO Color { get; set; } = null!;

    public virtual ViewTalleDTO Talle { get; set; } = null!;

    public virtual ArticuloDTO Articulo { get; set; } = null!;
}

public record CreateInventarioDTO
{
    public int Cantidad { get; set; }
    public int IdSucursal { get; set; }
    public int IdColor { get; set; }
    public int IdTalle { get; set; }
    public int IdArticulo { get; set; }
}

public record ShowInventarioDTO
{
    public int IdInventario { get; set; }
    public int Cantidad { get; set; }

    public int IdSucursal { get; set; }
    public int IdColor { get; set; }
    public int IdTalle { get; set; }
    public int IdArticulo { get; set; }
}
