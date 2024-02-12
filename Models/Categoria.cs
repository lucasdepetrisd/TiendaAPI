using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Articulo> Articulo { get; set; } = new List<Articulo>();
}
