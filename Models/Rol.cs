using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaAPI.Models;

public partial class Rol
{
    [Key]
    public int IdRol { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
