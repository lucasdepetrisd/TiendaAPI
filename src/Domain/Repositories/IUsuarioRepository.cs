using Domain.Models;

namespace Domain.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario?> GetByUsernameAsync(string nombreUsuario);
    }
}
