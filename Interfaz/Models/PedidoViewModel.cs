using DsmGen.ApplicationCore.Enumerated.Dominio_dsm;
using System;
using System.ComponentModel.DataAnnotations;

namespace Interfaz.Models
{
    public class PedidoViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Introduce el Estado", Description = "Estado del pedido", Name = "Estado")]
        [Required(ErrorMessage = "Debe indicar el estado")]
        public EstadoPedidoEnum Estado { get; set; }

        [Display(Prompt = "Introduce la fecha", Description = "Fecha del pedido", Name = "Fecha")]
        [Required(ErrorMessage = "Debe indicar la fecha")]
        [DataType(DataType.Date, ErrorMessage = "El tipo de dato debe ser una fecha")]
        public DateTime Fecha { get; set; }

        [Display(Prompt = "Introduce la fecha de entrega estimada", Description = "Fecha de entrega estimada", Name = "Entrega estimada")]
        [Required(ErrorMessage = "Debe indicar la fecha de entrega estimada")]
        [DataType(DataType.Date, ErrorMessage="El tipo de dato debe ser una fecha")]
        public DateTime Entrega_est { get; set; }

        [Display(Prompt = "Introduce el precio total", Description = "Precio total del pedido", Name = "Precio total")]
        [Required(ErrorMessage = "Debe indicar el precio total")]
        [DataType(DataType.Currency, ErrorMessage = "El tipo de dato debe ser un numero")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El precio debe ser mayor que 0 y menor que 10000")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Por favor introduce un número entero para el precio")]
        public double Total{ get; set; }

        [Display(Prompt = "Introduce el gasto de envio", Description = "Gasto de envio de pedido", Name = "Gastos envio")]
        [Required(ErrorMessage = "Debe indicar el gasato de envio")]
        [DataType(DataType.Currency, ErrorMessage = "El tipo de dato debe ser un numero")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El envio debe ser mayor que 0 y menor que 10000")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Por favor introduce un número entero para el envio")]

        public double Gastos_envio { get; set; }


    }
}
