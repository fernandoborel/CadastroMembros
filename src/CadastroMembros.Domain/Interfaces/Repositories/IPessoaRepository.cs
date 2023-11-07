using CadastroMembros.Domain.Entities;

namespace CadastroMembros.Domain.Interfaces.Repositories
{
    public interface IPessoaRepository : IDisposable
    {
        Task <List<Pessoa>> GetAllAsync();
        Task <Pessoa> GetByIdAsync(int id);
        Task <Pessoa> CreateAsync(Pessoa pessoa);
        Task <Pessoa> UpdateAsync(Pessoa pessoa);
        Task <bool> DeleteAsync(int id);
    }
}
