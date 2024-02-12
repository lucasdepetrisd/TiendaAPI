using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class Talle
{
    public int IdMedida { get; set; }

    public string? Medida { get; set; }

    public int IdTipoTalle { get; set; }

    public virtual TipoTalle IdTipoTalleNavigation { get; set; } = null!;

    public virtual ICollection<Inventario> Inventario { get; set; } = new List<Inventario>();
}
