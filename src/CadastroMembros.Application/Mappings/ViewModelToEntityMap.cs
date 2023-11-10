using AutoMapper;
using CadastroMembros.Application.ViewModel;
using CadastroMembros.Domain.Entities;

namespace CadastroMembros.Application.Mappings
{
    public class ViewModelToEntityMap : Profile
    {
        public ViewModelToEntityMap()
        {
            CreateMap<PessoaViewModel, Pessoa>();
            CreateMap<Pessoa, PessoaViewModel>();

            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}
