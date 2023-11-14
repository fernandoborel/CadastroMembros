using CadastroMembros.Application.Interfaces;
using CadastroMembros.Application.Mappings;
using CadastroMembros.Application.Services;
using CadastroMembros.Domain.Interfaces.Repositories;
using CadastroMembros.Domain.Interfaces.Services;
using CadastroMembros.Domain.Services;
using CadastroMembros.Infra.Data.Context;
using CadastroMembros.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
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

            builder.Services.AddTransient<IUsuarioAppService, UsuarioAppService>();
            builder.Services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        }

        public static void AddAutoMapperServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(ViewModelToEntityMap));
        }

        public static void AddCookie(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<CookiePolicyOptions>(op => { op.MinimumSameSitePolicy = SameSiteMode.None; });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Login"; // Rota para a página de login
                options.AccessDeniedPath = "/AcessoNegado"; // Rota para a página de acesso negado personalizada
            });
        }
    }
}
