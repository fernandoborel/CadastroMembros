using CadastroMembros.Domain.Entities;
using CadastroMembros.Domain.Interfaces.Repositories;
using CadastroMembros.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CadastroMembros.Infra.Data.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly MembrosContext _context;

        public PessoaRepository(MembrosContext context)
        {
            _context = context;
        }

        public async Task<Pessoa> CreateAsync(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
            return pessoa;
        }

        public async Task<Pessoa> UpdateAsync(Pessoa pessoa)
        {
            Pessoa pessoaBd = await GetByIdAsync(pessoa.Id);
            if(pessoaBd == null)
                throw new Exception("Houve um erro na atualização da pessoa.");

            pessoaBd.Nome = pessoa.Nome;
            pessoaBd.Email = pessoa.Email;
            pessoaBd.Cpf = pessoa.Cpf;
            pessoaBd.DataNascimento = pessoa.DataNascimento;
            pessoaBd.OndeTrabalha = pessoa.OndeTrabalha;
            pessoaBd.Cargo = pessoa.Cargo;
            pessoaBd.Pais = pessoa.Pais;
            pessoaBd.Estado = pessoa.Estado;
            pessoaBd.Cidade = pessoa.Cidade;
            pessoaBd.Cep = pessoa.Cep;
            pessoaBd.Logradouro = pessoa.Logradouro;
            pessoaBd.Numero = pessoa.Numero;
            pessoaBd.Complemento = pessoa.Complemento;
            pessoaBd.Bairro = pessoa.Bairro;
            pessoaBd.Telefone = pessoa.Telefone;
            pessoaBd.Ministerio = pessoa.Ministerio;
            pessoaBd.Batizado = pessoa.Batizado;
            pessoaBd.DataCadastro = pessoa.DataCadastro;
            pessoaBd.Ativo = pessoa.Ativo;
            pessoaBd.Sexo = pessoa.Sexo;
            pessoaBd.EstadoCivil = pessoa.EstadoCivil;
            pessoaBd.Vinculo = pessoa.Vinculo;

            _context.Pessoas.Update(pessoaBd);
            await _context.SaveChangesAsync();
            return pessoaBd;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            if(pessoa == null)
                return false;

            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
            return true;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<Pessoa>> GetAllAsync()
        {
            return await _context.Pessoas.ToListAsync();
        }

        public async Task<Pessoa> GetByIdAsync(int id)
        {
            return await _context.Pessoas.FirstOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<Pessoa> GetByCpfAsync(string cpf)
        {
            return await _context.Pessoas.FirstOrDefaultAsync(p => p.Cpf.Equals(cpf));
        }
    }
}
