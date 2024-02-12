using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class Tienda
{
    public int Cuit { get; set; }

    public int IdCondicionTributaria { get; set; }

    public virtual CondicionTributaria IdCondicionTributariaNavigation { get; set; } = null!;

    public virtual ICollection<Sucursal> Sucursal { get; set; } = new List<Sucursal>();
}
