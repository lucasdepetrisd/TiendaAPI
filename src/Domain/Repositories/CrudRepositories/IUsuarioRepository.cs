using Domain.Models.Admin;

namespace Domain.Repositories
{
    public interface IUsuarioRepository : ICrudRepository<Usuario>
    {
        Task<Usuario?> GetByUsernameAsync(string nombreUsuario);
    }
}
