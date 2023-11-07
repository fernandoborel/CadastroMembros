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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoasMap());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
