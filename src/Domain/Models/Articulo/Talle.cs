using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Articulo;

public partial class Talle
{
    [Key]
    public int IdTalle { get; set; }

    public string Medida { get; set; } = null!;

    public int? IdTipoTalle { get; set; }
    [ForeignKey("IdTipoTalle")]
    public virtual TipoTalle? TipoTalle { get; set; }

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
}
