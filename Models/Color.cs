using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaAPI.Models;

public partial class Color
{
    [Key]
    public int IdColor { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Inventario> Inventario { get; set; } = new List<Inventario>();
}
