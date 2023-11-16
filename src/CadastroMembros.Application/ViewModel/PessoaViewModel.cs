using CadastroMembros.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CadastroMembros.Application.ViewModel
{
    public class PessoaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório")]
        [EmailAddress(ErrorMessage = "O Email é inválido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O CPF deve conter 11 caracteres")]
        public string? Cpf { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento é obrigatória")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataNascimento { get; set; }
        public string? OndeTrabalha { get; set; }
        public string? Cargo { get; set; }

        [Required(ErrorMessage = "O País é obrigatório")]
        public string? Pais { get; set; }

        [Required(ErrorMessage = "O Estado é obrigatório")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O Estado deve conter 2 caracteres")]
        public string? Estado { get; set; }

        [Required(ErrorMessage = "A Cidade é obrigatória")]
        public string? Cidade { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório")]
        [StringLength(9, MinimumLength = 8, ErrorMessage = "O CEP deve conter 8 caracteres")]
        public string? Cep { get; set; }

        [Required(ErrorMessage = "O Logradouro é obrigatório")]
        public string? Logradouro { get; set; }

        [Required(ErrorMessage = "O Número é obrigatório")]
        public string? Numero { get; set; }
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "O Bairro é obrigatório")]
        public string? Bairro { get; set; }

        [MaxLength(11, ErrorMessage = "O Telefone deve conter no máximo 11 caracteres")]
        public string? Telefone { get; set; }
        public string? Ministerio { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataCadastro { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;

        #region Enums

        [Required(ErrorMessage = "O Sexo é obrigatório")]
        public Sexo Sexo { get; set; }

        [Required(ErrorMessage = "O Estado Civil é obrigatório")]
        public EstadoCivil EstadoCivil { get; set; }

        [Required(ErrorMessage = "O Vínculo é obrigatório")]
        public Vinculo Vinculo { get; set; }

        [Required(ErrorMessage = "O campo batismo é obrigatório")]
        public Batizado Batizado { get; set; }

        #endregion
    }
}
