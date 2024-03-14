using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.Ventas;

namespace Domain.Models.Admin;

public partial class Usuario
{
    /*public Usuario(int idUsuario, string nombreUsuario, string contraseña, int? idRol, int idEmpleado)
    {
        IdUsuario = idUsuario;
        NombreUsuario = nombreUsuario ?? throw new ArgumentNullException(nameof(nombreUsuario));
        Contraseña = contraseña ?? throw new ArgumentNullException(nameof(contraseña));
        IdRol = idRol;
        IdEmpleado = idEmpleado;
    }*/

    [Key]
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public int? IdRol { get; set; }
    [ForeignKey("IdRol")]
    public virtual Rol? Rol { get; set; }

    public int IdEmpleado { get; set; }
    [ForeignKey("IdEmpleado")]
    public virtual Empleado Empleado { get; set; } = null!;
    public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    public virtual ICollection<Sesion> Sesiones { get; set; } = new List<Sesion>();
}
