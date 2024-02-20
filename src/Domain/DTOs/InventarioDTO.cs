using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public record InventarioDTO
{
    [Key]
    public int IdInventario { get; set; }

    public int Cantidad { get; set; }

    public int IdSucursal { get; set; }
    public virtual SucursalDTO Sucursal { get; set; } = null!;

    public int IdColor { get; set; }
    public virtual ColorDTO? Color { get; set; }
    
    public int IdTalle { get; set; }
    public virtual TalleDTO? Talle { get; set; }
    
    public int IdArticulo { get; set; }
    public virtual ArticuloDTO Articulo { get; set; } = null!;
}
