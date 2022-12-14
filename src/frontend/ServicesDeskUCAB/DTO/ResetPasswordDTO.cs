using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCAB.DTO
{
    public class ResetPasswordDTO
    {
        [Required]
        public string token {get; set;} = string.Empty;

        [Required(ErrorMessage = "Introduzca la contraseņa")]
        [MinLength(8, ErrorMessage = "La contraseņa debe tener minimo 8 caracteres")]
        public string Password {get; set;} = string.Empty;

        [Required(ErrorMessage = "Repita la contraseņa")]
        [Compare("Password", ErrorMessage = "Las contraseņas no coinciden")]
        public string confirmationpassword {get; set;} =string.Empty;
    }
    }
