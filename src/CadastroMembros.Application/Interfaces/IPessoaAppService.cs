using CadastroMembros.Application.ViewModel;

namespace CadastroMembros.Application.Interfaces
{
    public interface IPessoaAppService : IDisposable
    {
        Task<PessoaViewModel> CriarPessoaAsync(PessoaViewModel pessoaVw);
        Task<PessoaViewModel> ObterPessoaPorIdAsync(int id);
        Task<IEnumerable<PessoaViewModel>> ObterTodosAsync();
        Task<PessoaViewModel> AtualizarPessoaAsync(PessoaViewModel pessoaVw);
        Task ExcluirPessoaAsync(int id);
        Task<PessoaViewModel> ObterPessoaPorCpfAsync(string cpf);
    }
}
