using System.ComponentModel.DataAnnotations;

namespace url.api.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "O campo`{0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo`{0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(15, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(15, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
        public string NewPassword { get; set; }
    }
}