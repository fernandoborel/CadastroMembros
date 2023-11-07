using CadastroMembros.Application.Interfaces;
using CadastroMembros.Application.Mappings;
using CadastroMembros.Application.Services;
using CadastroMembros.Domain.Interfaces.Repositories;
using CadastroMembros.Domain.Interfaces.Services;
using CadastroMembros.Domain.Services;
using CadastroMembros.Infra.Data.Context;
using CadastroMembros.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CadastroMembros.Presentation
{
    public static class Setup
    {
        public static void AddEntityFrameworkServices(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("BDMembros");
            builder.Services.AddDbContext<MembrosContext>(options => options.UseSqlServer(connectionString));
        }

        public static void AddRegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IPessoaAppService, PessoaAppService>();
            builder.Services.AddTransient<IPessoaDomainService, PessoaDomainService>();
            builder.Services.AddTransient<IPessoaRepository, PessoaRepository>();
        }

        public static void AddAutoMapperServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(ViewModelToEntityMap));
        }
    }
}
