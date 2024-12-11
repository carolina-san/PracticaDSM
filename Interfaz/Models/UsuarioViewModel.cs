using System;
using System.ComponentModel.DataAnnotations;

namespace Interfaz.Models
{
    
        public class LoginUsuarioViewModel
        {
            [Display(Prompt = "Introduce el email del usuario", Description = "Email usuario", Name = "EmailUsuario")]
            [Required(ErrorMessage = "El email del Usuario es obligatorio")]

            public string Email { get; set; }

            [Display(Prompt = "Introduce el password del usuario", Description = "Password usuario", Name = "Password")]
            [Required(ErrorMessage ="El Password del Usuario es obligatorio")]
            [DataType(DataType.Password)]


            public string Password { get; set; }

        }

        public class UsuarioViewModel
        {
               [Required(ErrorMessage = "El nombre es obligatorio")]
            public string Nombre { get; set; }

            [Required(ErrorMessage = "El correo es obligatorio")]
            [EmailAddress(ErrorMessage = "Formato de correo inválido")]
            public string Email { get; set; }

            [Required(ErrorMessage = "La contraseña es obligatoria")]
            [MinLength(4, ErrorMessage = "La contraseña debe tener al menos 4 caracteres")]
            public string Password { get; set; }

            [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
            [DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido")]
            public DateTime FechaNac { get; set; }
    }
    
}
