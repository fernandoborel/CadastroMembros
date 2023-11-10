using CadastroMembros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroMembros.Infra.Data.Mappings
{
    public class UsuariosMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(e => e.Nome).HasMaxLength(150);

            builder.Property(e => e.Email).HasMaxLength(100);

            builder.Property(e => e.Senha).HasMaxLength(100);

            builder.Property(e => e.Login).HasMaxLength(100);

            builder.Property(e => e.DataCadastro).HasColumnType("datetime");
        }
    }
}
