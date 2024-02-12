using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class Marca
{
    public int IdMarca { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Articulo> Articulo { get; set; } = new List<Articulo>();
}
