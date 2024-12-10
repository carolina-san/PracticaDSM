using DsmGen.ApplicationCore.EN.Dominio_dsm;
using Interfaz.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Interfaz.Assemblers
{
    public class CarritoAssembler
    {
        public CarritoViewModel ConvertirENToViewModel(CarritoEN en)
        {
            CarritoViewModel carrito = new CarritoViewModel();

            // Verificar si la lista de artículos no está vacía
            if (en.Articulo != null && en.Articulo.Any())
            {
                carrito.Articulos = new List<ArticuloViewModel>();
                foreach (ArticuloEN artEN in en.Articulo)
                {
                    ArticuloViewModel artView = new ArticuloAssembler().ConvertirENToViewModel(artEN);
                    carrito.Articulos.Add(artView);
                }
            }
            else
            {
                carrito.Articulos = new List<ArticuloViewModel>(); // Lista vacía
            }

            carrito.Total = (decimal)en.Subtotal; // Asegurarse de que el subtotal se asigne correctamente

            return carrito;
        }


        // Convertir una lista de CarritoEN a una lista de CarritoViewModel
        public IList<CarritoViewModel> ConvertirListENToViewModel(IList<CarritoEN> ens)
        {
            IList<CarritoViewModel> carritos = new List<CarritoViewModel>();
            foreach (CarritoEN en in ens)
            {
                carritos.Add(ConvertirENToViewModel(en));
            }
            return carritos;
        }
    }
}
