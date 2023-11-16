using CadastroMembros.Domain.Enums;

namespace CadastroMembros.Domain.Entities
{
    public partial class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }                
        public DateTime? DataNascimento { get; set; }
        public string? OndeTrabalha { get; set; }
        public string? Cargo { get; set; }
        public string? Pais { get; set; }
        public string? Estado { get; set; }
        public string? Cidade { get; set; }
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Telefone { get; set; }
        public string? Ministerio { get; set; }
        public DateTime? DataCadastro { get; set; } = DateTime.Now;
        public bool? Ativo { get; set; } = true;

        #region Enums

        public Sexo? Sexo { get; set; }
        public EstadoCivil? EstadoCivil { get; set; }
        public Vinculo? Vinculo { get; set; }
        public Batizado? Batizado { get; set; }

        #endregion
    }
}
