using CadastroMembros.Application.ViewModel;

namespace CadastroMembros.Application.Interfaces
{
    public interface IUsuarioAppService : IDisposable
    {
        Task<RegisterViewModel> CriarUsuarioAsync(RegisterViewModel usuarioVw);
        Task<UsuarioViewModel> ObterPorLoginESenha(string login, string senha);
        Task<UsuarioViewModel> ObterPorEmail(string email);
    }
}
