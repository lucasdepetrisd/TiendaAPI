using Domain.Models;

namespace Domain.Repositories
{
    public interface IUsuarioRepository : ICrudRepository<Usuario>
    {
        Task<Usuario?> GetByUsernameAsync(string nombreUsuario);
    }
}
