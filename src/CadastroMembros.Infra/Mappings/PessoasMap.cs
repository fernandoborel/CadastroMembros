using CadastroMembros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroMembros.Infra.Data.Mappings
{
    public class PessoasMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.Property(e => e.Bairro).HasMaxLength(50);

            builder.Property(e => e.Cargo).HasMaxLength(50);

            builder.Property(e => e.Cep)
                .HasMaxLength(9)
                .HasColumnName("CEP");

            builder.Property(e => e.Cidade).HasMaxLength(50);

            builder.Property(e => e.Complemento).HasMaxLength(50);

            builder.Property(e => e.Cpf).HasMaxLength(14);

            builder.Property(e => e.DataCadastro).HasColumnType("datetime");

            builder.Property(e => e.DataNascimento).HasColumnType("date");

            builder.Property(e => e.Email).HasMaxLength(100);

            builder.Property(e => e.Estado).HasMaxLength(2);

            builder.Property(e => e.Logradouro).HasMaxLength(100);

            builder.Property(e => e.Ministerio).HasMaxLength(100);

            builder.Property(e => e.Nome).HasMaxLength(100);

            builder.Property(e => e.Numero).HasMaxLength(10);

            builder.Property(e => e.OndeTrabalha).HasMaxLength(100);

            builder.Property(e => e.Pais).HasMaxLength(50);

            builder.Property(e => e.Telefone).HasMaxLength(15);
        }
    }
}
