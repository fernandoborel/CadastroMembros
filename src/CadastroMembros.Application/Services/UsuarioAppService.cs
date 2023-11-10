using AutoMapper;
using CadastroMembros.Application.Interfaces;
using CadastroMembros.Application.ViewModel;
using CadastroMembros.Domain.Entities;
using CadastroMembros.Domain.Interfaces.Services;

namespace CadastroMembros.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioDomainService _usuarioDomainService;
        private readonly IMapper _mapper;

        public UsuarioAppService(IUsuarioDomainService usuarioDomainService, IMapper mapper)
        {
            _usuarioDomainService = usuarioDomainService;
            _mapper = mapper;
        }
        public async Task<UsuarioViewModel> CriarUsuarioAsync(UsuarioViewModel usuarioVw)
        {
            var usuario = _mapper.Map<Usuario>(usuarioVw);
            var usuarioCriado = await _usuarioDomainService.AdicionarAsync(usuario);
            return _mapper.Map<UsuarioViewModel>(usuarioCriado);
        } 

        public void Dispose()
        {
            _usuarioDomainService.Dispose();
        }

        public async Task<UsuarioViewModel> ObterPorLoginESenha(string login, string senha)
        {
            var usuario = await _usuarioDomainService.BuscaPorLoginESenhaAsync(login, senha);
            var usuarioVw = _mapper.Map<UsuarioViewModel>(usuario);
            return usuarioVw;
        }

        public async Task<UsuarioViewModel> ObterPorEmail(string email)
        {
            var usuario = await _usuarioDomainService.BuscarPorEmailAsync(email);
            return _mapper.Map<UsuarioViewModel>(usuario);
        }
    }
}
