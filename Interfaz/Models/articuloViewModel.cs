using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DsmGen.ApplicationCore.Enumerated.Dominio_dsm;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using Microsoft.AspNetCore.Http;

namespace Interfaz.Models

{
    public class ArticuloViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Display(Prompt ="Describe el artículo", Description="Descripción del articulo",Name ="Descripción")]
        [Required(ErrorMessage="Debe indicar un nombre para el artículo")]
        [StringLength(maximumLength:200,ErrorMessage= "La descripción no puede tener más de 200 caracteres")]
        public string Descripcion { get; set; }
        public Talla_artEnum Talla { get; set; }

        [Display(Prompt = "Introduce el precio del artículo", Description = "Precio del articulo", Name = "Precio")]
        [Required(ErrorMessage = "Debe indicar el precio del artículo")]
        [DataType(DataType.Currency, ErrorMessage="El precio debe ser un valor númerico")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que 0 y menor que 10000")]
        public float Precio { get; set; }
        public Boolean Check_verificado { get; set; }
        public string Recomendaciones { get; set; }
        [Display(Prompt = "Introduce la marca del artículo", Description = "Marca del articulo", Name = "Marca")]
        public string Marca { get; set; }
        public string Desc_verificado { get; set; }
        public string Color { get; set; }
        [Display(Prompt = "Introduce el stock del artículo", Description = "Stock del articulo", Name = "Stock")]
        [Required(ErrorMessage = "Debe indicar el stock del artículo")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El stock debe ser mayor que 0 y menor que 10000")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Por favor introduce un número entero para el stock")]
        public int Stock { get; set; }
        [ScaffoldColumn(false)]
        public string Imagen { get; set; }

        [Display(Prompt = "Introduce la imagen para el artículo", Description ="Imagen del artículo", Name = "Imagen")]        
        public IFormFile Foto { get; set; }
        public bool Favorito { get; set; }
    }
}
