using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class TipoTalle
{
    public int IdTipoTalle { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Articulo> Articulo { get; set; } = new List<Articulo>();

    public virtual ICollection<Talle> Talle { get; set; } = new List<Talle>();
}
