using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaAPI.Models;

public partial class Articulo
{
    [Key]
    public int IdArticulo { get; set; }
    public int Codigo { get; set; }
    public string Descripcion { get; set; } = null!;
    [Precision(18, 2)]
    public decimal Costo { get; set; }
    public int PorcentajeIVA { get; set; }
    public int MargenGanancia { get; set; }
    
    public int? IdCategoria { get; set; }
    [ForeignKey("IdCategoria")]
    public virtual Categoria? Categoria { get; set; }

    public int? IdMarca { get; set; }
    [ForeignKey("IdMarca")]
    public virtual Marca? Marca { get; set; }

    public int? IdTipoTalle { get; set; }
    [ForeignKey("IdTipoTalle")]
    public virtual TipoTalle? TipoTalle { get; set; }

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
}
