using AutoMapper;
using CadastroMembros.Application.Interfaces;
using CadastroMembros.Application.ViewModel;
using CadastroMembros.Domain.Entities;
using CadastroMembros.Domain.Interfaces.Services;

namespace CadastroMembros.Application.Services
{
    public class PessoaAppService : IPessoaAppService
    {
        private readonly IPessoaDomainService _pessoaDomainService;
        private readonly IMapper _mapper;

        public PessoaAppService(IPessoaDomainService pessoaDomainService, IMapper mapper)
        {
            _pessoaDomainService = pessoaDomainService;
            _mapper = mapper;
        }

        public async Task<PessoaViewModel> CriarPessoaAsync(PessoaViewModel pessoaVw)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaVw);
            var pessoaCriada = await _pessoaDomainService.AdicionarAsync(pessoa);
            return _mapper.Map<PessoaViewModel>(pessoaCriada);
        }

        public async Task<PessoaViewModel> AtualizarPessoaAsync(PessoaViewModel pessoaVw)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaVw);
            var pessoaAtualizada = await _pessoaDomainService.AtualizarAsync(pessoa);
            return _mapper.Map<PessoaViewModel>(pessoaAtualizada);
        }

        public void Dispose()
        {
            _pessoaDomainService.Dispose();
        }

        public async Task ExcluirPessoaAsync(int id)
        {
            await _pessoaDomainService.ExcluirAsync(id);
        }

        public async Task<PessoaViewModel> ObterPessoaPorIdAsync(int id)
        {
            var pessoa = await _pessoaDomainService.BuscarPorIdAsync(id);
            return _mapper.Map<PessoaViewModel>(pessoa);
        }

        public async Task<IEnumerable<PessoaViewModel>> ObterTodosAsync()
        {
            var pessoas = await _pessoaDomainService.BuscarTodosAsync();
            return _mapper.Map<IEnumerable<PessoaViewModel>>(pessoas);
        }

        public async Task<PessoaViewModel> ObterPessoaPorCpfAsync(string cpf)
        {
            var cpfValidado = await _pessoaDomainService.BuscarPorCpfAsync(cpf);
            return _mapper.Map<PessoaViewModel>(cpfValidado);
        }
    }
}
