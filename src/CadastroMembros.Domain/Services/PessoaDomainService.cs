using CadastroMembros.Domain.Entities;
using CadastroMembros.Domain.Interfaces.Repositories;
using CadastroMembros.Domain.Interfaces.Services;

namespace CadastroMembros.Domain.Services
{
    public class PessoaDomainService : IPessoaDomainService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaDomainService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<Pessoa> AdicionarAsync(Pessoa pessoa)
        {
            return await _pessoaRepository.CreateAsync(pessoa);
        }

        public async Task<Pessoa> AtualizarAsync(Pessoa pessoa)
        {
            return await _pessoaRepository.UpdateAsync(pessoa);
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            return await _pessoaRepository.DeleteAsync(id);
        }

        public async Task<Pessoa> BuscarPorIdAsync(int id)
        {
            return await _pessoaRepository.GetByIdAsync(id);
        }

        public async Task<List<Pessoa>> BuscarTodosAsync()
        {
            return await _pessoaRepository.GetAllAsync();
        }

        public void Dispose()
        {
            _pessoaRepository.Dispose();
        }

        public async Task<Pessoa> BuscarPorCpfAsync(string cpf)
        {
            return await _pessoaRepository.GetByCpfAsync(cpf);
        }
    }
}
