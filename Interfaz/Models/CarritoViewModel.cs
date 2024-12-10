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
    public class CarritoViewModel
    {
        public List<ArticuloViewModel> Articulos { get; set; } = new List<ArticuloViewModel>(); // Lista de artículos añadidos al carrito.
        public decimal Total { get; set; } // Total acumulado del carrito.
    }
}