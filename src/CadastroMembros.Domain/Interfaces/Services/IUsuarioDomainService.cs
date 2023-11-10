using CadastroMembros.Domain.Entities;

namespace CadastroMembros.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService : IDisposable
    {
        Task <Usuario> AdicionarAsync(Usuario usuario);
        Task<Usuario> BuscarPorEmailAsync(string email);
        Task<Usuario> BuscaPorLoginESenhaAsync(string login, string senha);
    }
}
