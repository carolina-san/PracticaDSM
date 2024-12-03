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
            public string Email { get; set; }
            public string Password { get; set; }
            public string Nombre { get; set; }
            public Nullable<DateTime> FechaNac { get; set; }
        }
    
}
