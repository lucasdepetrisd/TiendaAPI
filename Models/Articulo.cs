using System;
using System.Collections.Generic;

namespace TiendaAPI.Models;

public partial class Articulo
{
    public int Codigo { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Costo { get; set; }

    public int Iva { get; set; }

    public int MargenGanancia { get; set; }

    public int IdCategoria { get; set; }

    public int IdMarca { get; set; }

    public int IdTipoTalle { get; set; }

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    public virtual Marca IdMarcaNavigation { get; set; } = null!;

    public virtual TipoTalle IdTipoTalleNavigation { get; set; } = null!;

    public virtual ICollection<Inventario> Inventario { get; set; } = new List<Inventario>();
}
