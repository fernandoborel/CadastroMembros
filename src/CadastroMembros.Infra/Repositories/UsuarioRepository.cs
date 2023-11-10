using CadastroMembros.Domain.Entities;
using CadastroMembros.Domain.Interfaces.Repositories;
using CadastroMembros.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CadastroMembros.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MembrosContext _context;

        public UsuarioRepository(MembrosContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Email.Equals(email));
        }

        public async Task<Usuario> GetByLoginESenhaAsync(string login, string senha)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(x => x.Login.Equals(login) && x.Senha.Equals(senha));
        }
    }
}
