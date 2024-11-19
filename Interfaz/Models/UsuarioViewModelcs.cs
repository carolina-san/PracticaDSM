using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Interfaz.Models
{

    public class LoginUsuarioViewModelcs
    {
        [Display(Prompt = "Introduce el dni del usuario",Description = "DNI usuario",Name = "DNIUsuario")]
        [Required(ErrorMessage = "El DNI del Usuario es obligatorio")]

        public string DNI { get; set; }
        [Display(Prompt = "Introduce el password del usuario", Description = "Password usuario", Name = "Password")]
        [DataType(DataType.Password)]

        public string Password { get; set; }

    }
}
