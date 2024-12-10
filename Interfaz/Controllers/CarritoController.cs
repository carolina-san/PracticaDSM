using DsmGen.ApplicationCore.CEN.Dominio_dsm;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.Infraestructure.Repository.Dominio_dsm;
using Interfaz.Assemblers;
using Interfaz.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Interfaz.Controllers;
using Interfaz;


public class CarritoController : BasicController
{
    private static CarritoViewModel _carrito = new CarritoViewModel();
    // En la acción Añadir
    [HttpGet]
    public ActionResult Añadir(int id)
    {
        // Inicializa la sesión
        SessionInitialize();

        // Crear el repositorio y CEN
        ArticuloRepository artRepository = new ArticuloRepository(session);
        ArticuloCEN artCEN = new ArticuloCEN(artRepository);

        // Obtener el artículo por ID
        ArticuloEN artEN = artCEN.DameOID(id);
        ArticuloViewModel artView = new ArticuloAssembler().ConvertirENToViewModel(artEN);

      
        CarritoViewModel carritoView = HttpContext.Session.GetObject<CarritoViewModel>("CarritoView");
        // Verificar que el artículo no sea nulo
        if (carritoView != null)
        {
            carritoView.Articulos.Add(artView); // Suponiendo que articuloEN es un ArticuloEN válido
            // Guardar el carrito en la sesión
            HttpContext.Session.SetObject("CarritoView", carritoView);
            // Redirigir a la vista del carrito
        }
        else
        {
            // Crear el repositorio y CEN
            CarritoRepository carritoRepository = new CarritoRepository(session);
            CarritoCEN carritoCEN = new CarritoCEN(carritoRepository);

            // Obtener el artículo por ID
            CarritoEN carritoEN = carritoCEN.ReadOID(id);
            carritoView = new CarritoAssembler().ConvertirENToViewModel(carritoEN);
            carritoView.Articulos.Add(artView); // Suponiendo que articuloEN es un ArticuloEN válido
            HttpContext.Session.SetObject("CarritoView", carritoView);

        }
        // Cerrar la sesión de base de datos
        SessionClose();
        return RedirectToAction("Carrito", "Articulo");

    }



    public ActionResult Index()
    {
        // Obtener el carrito desde la sesión, asegurándote de que sea un objeto de tipo CarritoEN
        CarritoViewModel carritoView = HttpContext.Session.GetObject<CarritoViewModel>("CarritoView");

        if (carritoView == null)
        {
            // Si el carrito no existe en la sesión, redirige a la página de inicio o muestra un mensaje adecuado
            return RedirectToAction("Index", "Home");
        }


        // Pasar el carrito a la vista
        return View(carritoView);
    }

}
