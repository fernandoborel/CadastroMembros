using System.ComponentModel.DataAnnotations;

namespace CadastroMembros.Application.ViewModel
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "Preencha o campo Senha")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "Preencha o campo Login")]
        public string? Login { get; set; }
    }
}
