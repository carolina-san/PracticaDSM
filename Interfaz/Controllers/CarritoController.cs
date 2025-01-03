﻿using DsmGen.ApplicationCore.CEN.Dominio_dsm;
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
using DsmGen.ApplicationCore.CP.Dominio_dsm;
using DsmGen.Infraestructure.EN.Dominio_dsm;
using DsmGen.ApplicationCore.Enumerated.Dominio_dsm;


public class CarritoController : BasicController
{
    private static CarritoViewModel _carrito = new CarritoViewModel();
    // En la acción Añadir
    [HttpPost]
    public ActionResult Añadir(int id, Talla_artEnum talla)
    {

        // Inicializa la sesión
        SessionInitialize();
        var usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
        // Crear el repositorio y CEN
        ArticuloRepository artRepository = new ArticuloRepository(session);
        ArticuloCEN artCEN = new ArticuloCEN(artRepository);

        // Obtener el artículo por ID
        ArticuloEN artEN = artCEN.DameOID(id);
        artCEN.Modificar(artEN.Id, artEN.Nombre, artEN.Precio, artEN.Descripcion, talla, artEN.Recomendaciones, artEN.Check_verificado, artEN.Desc_verificado, artEN.Marca, artEN.Stock, artEN.En_stock, artEN.Color);
        ArticuloViewModel artView = new ArticuloAssembler().ConvertirENToViewModel(artEN);

        IList<int> arts = new List<int>();
        arts.Add(id);
        CarritoViewModel carritoView = HttpContext.Session.GetObject<CarritoViewModel>("CarritoView");
        int idCarrito = HttpContext.Session.Get<int>("idCarrito");
        // Crear el repositorio y CEN
        CarritoRepository carritoRepository = new CarritoRepository(); // quitarle el session a este repository para que no esté dentro de la sessión de aquí, y haga commit, sino no funciona el AddArticulo.
        CarritoCEN carritoCEN = new CarritoCEN(carritoRepository);
        // Verificar que el artículo no sea nulo
        if (carritoView != null)
        {
            carritoCEN.AddArticulo(idCarrito, arts);
            CarritoRepository carritoRepositoryAssem = new CarritoRepository(session);
            CarritoEN carritoEN = carritoRepositoryAssem.ReadOIDDefault(idCarrito);
            carritoView = new CarritoAssembler().ConvertirENToViewModel(carritoEN);
            HttpContext.Session.SetObject("CarritoView", carritoView);
        }
        else
        {
            idCarrito = carritoCEN.Nuevo(usuario.Email, 0);
            carritoCEN.AddArticulo(idCarrito, arts);

            CarritoRepository carritoRepositoryAssem = new CarritoRepository(session); // este  respository le ponemos el session para que funcione correctamente el assembler.
            CarritoEN carritoEN = carritoRepositoryAssem.ReadOIDDefault(idCarrito);

            carritoView = new CarritoAssembler().ConvertirENToViewModel(carritoEN);
            HttpContext.Session.Set<int>("idCarrito", idCarrito);
            HttpContext.Session.SetObject("CarritoView", carritoView);

        }

        SessionClose();
        return RedirectToAction("Carrito", "Articulo");

    }
    [HttpGet]
    public ActionResult Eliminar(int id)
    {

        // Inicializa la sesión
        SessionInitialize();
        var usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
        // Crear el repositorio y CEN
        ArticuloRepository artRepository = new ArticuloRepository(session);
        ArticuloCEN artCEN = new ArticuloCEN(artRepository);

        // Obtener el artículo por ID
        ArticuloEN artEN = artCEN.DameOID(id);
        ArticuloViewModel artView = new ArticuloAssembler().ConvertirENToViewModel(artEN);

        IList<int> arts = new List<int>();
        arts.Add(id);
        CarritoViewModel carritoView = HttpContext.Session.GetObject<CarritoViewModel>("CarritoView");
        int idCarrito = HttpContext.Session.Get<int>("idCarrito");
        // Crear el repositorio y CEN
        CarritoRepository carritoRepository = new CarritoRepository(); // quitarle el session a este repository para que no esté dentro de la sessión de aquí, y haga commit, sino no funciona el AddArticulo.
        CarritoCEN carritoCEN = new CarritoCEN(carritoRepository);
        // Verificar que el artículo no sea nulo
        if (carritoView != null)
        {
            carritoCEN.EliminarArticulo(idCarrito, arts);
            CarritoRepository carritoRepositoryAssem = new CarritoRepository(session);
            CarritoEN carritoEN = carritoRepositoryAssem.ReadOIDDefault(idCarrito);
            carritoView = new CarritoAssembler().ConvertirENToViewModel(carritoEN);
            HttpContext.Session.SetObject("CarritoView", carritoView);
            HttpContext.Session.Set<int>("idCarrito", idCarrito);

        }
        

        SessionClose();
        return RedirectToAction("Carrito", "Articulo");

    }
    [HttpPost]
    public ActionResult PasarPorCaja()
    {
        var usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");

        if (usuario == null)
        {
            return RedirectToAction("Login", "Usuario");
        }

        // Lógica para procesar el pago
        try
        {
            // Aquí implementarías la lógica para procesar el pedido.
            // Por ejemplo, crear un nuevo pedido en la base de datos.

            return RedirectToAction("Create", "Pedido");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return RedirectToAction("Error", "Home");
        }
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
