using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaAPI.Models;

public partial class Marca
{
    [Key]
    public int IdMarca { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
}
