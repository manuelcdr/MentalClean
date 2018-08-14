using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Infra.Cross.Identity.Models.ManageViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha atual")]
        public string SenhaAtual { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova senha", Description = "A senha deve conter letras maiúsculas e minúsculas, numeros e caracter especial")]
        public string NovaSenha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmação nova senha")]
        [Compare("NovaSenha", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmacaoNovaSenha { get; set; }

        public string StatusMessage { get; set; }
    }
}
