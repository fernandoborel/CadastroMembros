using CadastroMembros.Domain.Entities;
using CadastroMembros.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CadastroMembros.Infra.Data.Context
{
    public partial class MembrosContext : DbContext
    {
        public MembrosContext()
        {
        }

        public MembrosContext(DbContextOptions<MembrosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoasMap());
            modelBuilder.ApplyConfiguration(new UsuariosMap());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
