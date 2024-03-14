using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Articulo;

public partial class TipoTalle
{
    [Key]
    public int IdTipoTalle { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();

    public virtual ICollection<Talle> Talles { get; set; } = new List<Talle>();
}
