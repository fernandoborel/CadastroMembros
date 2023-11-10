using CadastroMembros.Domain.Entities;
using CadastroMembros.Domain.Interfaces.Repositories;
using CadastroMembros.Domain.Interfaces.Services;

namespace CadastroMembros.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioDomainService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> AdicionarAsync(Usuario usuario)
        {
            return await _usuarioRepository.CreateAsync(usuario);
        }


        public async Task<Usuario> BuscarPorEmailAsync(string email)
        {
            return await _usuarioRepository.GetByEmailAsync(email);
        }

        public async Task<Usuario> BuscaPorLoginESenhaAsync(string login, string senha)
        {
            return await _usuarioRepository.GetByLoginESenhaAsync(login, senha);
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
        }
    }
}
