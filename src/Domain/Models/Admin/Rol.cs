using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Admin;

public partial class Rol
{
    [Key]
    public int IdRol { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = [];
}
