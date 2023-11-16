using CadastroMembros.Domain.Entities;

namespace CadastroMembros.Domain.Interfaces.Services
{
    public interface IPessoaDomainService : IDisposable
    {
        Task<List<Pessoa>> BuscarTodosAsync();
        Task <Pessoa> BuscarPorIdAsync(int id);
        Task <Pessoa> AdicionarAsync(Pessoa pessoa);
        Task <Pessoa> AtualizarAsync(Pessoa pessoa);
        Task<bool> ExcluirAsync(int id);
        Task<Pessoa> BuscarPorCpfAsync(string cpf);
    }
}
