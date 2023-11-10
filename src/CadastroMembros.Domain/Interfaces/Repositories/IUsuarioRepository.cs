using CadastroMembros.Domain.Entities;

namespace CadastroMembros.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IDisposable
    {
        Task <Usuario> CreateAsync(Usuario usuario);
        Task <Usuario> GetByEmailAsync(string email);
        Task <Usuario> GetByLoginESenhaAsync(string login, string senha);
    }
}
