using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Interfaz.Models

{
    public class ArticuloViewModel
    {
        [ScaffoldColumn(false)]
        public int NumReferencia { get; set; }

        [Display(Prompt ="Describe el artículo", Description="Descripción del articulo",Name ="Descripción")]
        [Required(ErrorMessage="Debe indicar un nombre para el artículo")]
        [StringLength(maximumLength:200,ErrorMessage= "La descripción no puede tener más de 200 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Introduce el precio del artículo", Description = "Precio del articulo", Name = "Precio")]
        [Required(ErrorMessage = "Debe indicar el precio del artículo")]
        [DataType(DataType.Currency, ErrorMessage="El precio debe ser un valor númerico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que 0 y menor que 10000")]
        public double Precio { get; set; }

        [Display(Prompt = "Introduce el stock del artículo", Description = "Stock del articulo", Name = "Stock")]
        [Required(ErrorMessage = "Debe indicar el stock del artículo")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que 0 y menor que 10000")]
        public int Stock { get; set; }


    }
}
