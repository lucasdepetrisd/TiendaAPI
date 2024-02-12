using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
