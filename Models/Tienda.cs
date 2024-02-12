using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaAPI.Models;

public partial class Tienda
{
    [Key]
    public int IdTienda { get; set; }

    public int Cuit { get; set; }

    public int IdCondicionTributaria { get; set; }

    public virtual CondicionTributaria IdCondicionTributariaNavigation { get; set; } = null!;

    public virtual ICollection<Sucursal> Sucursal { get; set; } = new List<Sucursal>();
}
