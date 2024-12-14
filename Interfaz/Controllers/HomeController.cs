using DsmGen.ApplicationCore.CEN.Dominio_dsm;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.ApplicationCore.Enumerated.Dominio_dsm;
using DsmGen.Infraestructure.Repository.Dominio_dsm;
using Interfaz.Assemblers;
using Interfaz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Interfaz.Controllers
{
    public class HomeController : BasicController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string tipo)
        {
            SessionInitialize();
            ArticuloRepository artRepository = new ArticuloRepository(session);
            ArticuloCEN artCEN = new ArticuloCEN(artRepository);
            IList<ArticuloEN> listEN = artCEN.DameALL(0, -1);

            if (string.IsNullOrEmpty(tipo))
            {
                // Si no hay marca, mostrar todos los artículos destacados
                listEN = artCEN.DameALL(0, -1);
            }
            else
            {
                // Buscar artículos por marca
                listEN = artCEN.DamePorTipo(tipo);
            }

            SessionClose();
            return View(listEN);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Busqueda(string nombre, string color, string marca, double? precioMin, double? precioMax, Talla_artEnum? talla)
        {
            SessionInitialize();
            ArticuloRepository artRepository = new ArticuloRepository(session);
            ArticuloCEN artCEN = new ArticuloCEN(artRepository);
            IList<ArticuloEN> listEN = artCEN.DameALL(0, -1);
            MarcaRepository marcaRepository = new MarcaRepository();
            MarcaCEN marcaCEN = new MarcaCEN(marcaRepository);

            IList<MarcaEN> listaMarcas = marcaCEN.DameALL(0, -1);
            IList<SelectListItem> marcaItems = new List<SelectListItem>();

            foreach (MarcaEN marca2 in listaMarcas)
            {
                marcaItems.Add(new SelectListItem { Text = marca2.Nombre, Value = marca2.Nombre });
            }
            ViewData["marcaItems"] = marcaItems;

            if (!string.IsNullOrEmpty(nombre))  // Mejor que != null
            {
                listEN = artCEN.DamePorTipo(nombre);
            }
            IList<ArticuloEN> listEN2 = artCEN.DameALL(0, -1);
            if (!string.IsNullOrEmpty(marca))  // Mejor que != null
            {
                listEN2 = artCEN.DamePorMarca(marca);
            }
            IList<ArticuloEN> listEN3 = artCEN.DameALL(0, -1);
            if (!string.IsNullOrEmpty(color))  // Mejor que != null
            {
                listEN3 = artCEN.DamePorColor(color);
            }
            IList<ArticuloEN> listEN4 = artCEN.DameALL(0, -1);
            if (talla!=null)  // Usar .HasValue para verificar si es nulo o no
            {
                listEN4 = artCEN.DamePorTalla(talla.Value);
            }
            IList<ArticuloEN> listEN5 = artCEN.DameALL(0, -1);
            if (precioMin.HasValue && !precioMax.HasValue)  // Comprobar si los valores de precio son válidos
            {
                precioMax = 10000;
                listEN5 = artCEN.DamePorPrecio(precioMin, precioMax);
            }

            if (!precioMin.HasValue && precioMax.HasValue)  // Comprobar si los valores de precio son válidos
            {
                precioMin = 0;
                listEN5 = artCEN.DamePorPrecio(precioMin, precioMax);
            }
            if (precioMin.HasValue && precioMax.HasValue)  // Comprobar si los valores de precio son válidos
            {
                
                listEN5 = artCEN.DamePorPrecio(precioMin, precioMax);
            }
            // Crear una lista para almacenar los elementos comunes
            List<ArticuloEN> elementosComunes = new List<ArticuloEN>();

            // Iterar sobre los artículos de la primera lista
            foreach (var articulo in listEN)
            {
                // Verificar si el artículo está presente en las demás listas
                if (listEN.Contains(articulo) && listEN2.Contains(articulo) && listEN3.Contains(articulo) && listEN4.Contains(articulo) && listEN5.Contains(articulo))
                {
                    // Si está presente en todas, agregarlo a la lista de elementos comunes
                    elementosComunes.Add(articulo);
                }
            }

            SessionClose();
            return View(elementosComunes);
            
        }

        [HttpPost]
        public ActionResult Favorito(int idArticulo)
        {
            if (idArticulo <= 0)
            {
                // Manejo de errores: ID no válido
                return RedirectToAction("Error", "Home");
            }

            // Lógica de favorito
            SessionInitialize();

            try
            {
                var usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");

                if (usuario == null)
                {
                    return RedirectToAction("Login", "Usuario");
                }

                // Operaciones relacionadas con el artículo
                IList<string> p_usuario_OIDs = new List<string> { usuario.Email };

                ArticuloRepository artRepository = new ArticuloRepository();
                ArticuloCEN artCEN = new ArticuloCEN(artRepository);

                artCEN.Favorito(idArticulo, p_usuario_OIDs);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return RedirectToAction("Error", "Home");
            }
            finally
            {
                SessionClose();
            }
        }


        [HttpPost]
        public IActionResult NotFavorito(int p_Articulo_OID)
        {
            // Recuperar el usuario desde la sesión
            var usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");

            if (usuario == null)
            {
                // Si el usuario no está logueado, redirigir a la página de login o mostrar un mensaje
                return RedirectToAction("Login", "Usuario");
            }

            // Crear la lista de usuarios que tendrá el artículo en favoritos
            IList<string> p_usuario_OIDs = new List<string> { usuario.Email };
            ArticuloRepository artRepository = new ArticuloRepository(session);
            ArticuloCEN artCEN = new ArticuloCEN(artRepository);
            // Llamar a la función para eliminar el artículo de favoritos
            artCEN.NotFavorito(p_Articulo_OID, p_usuario_OIDs);

            // Redirigir al usuario al index o la página de detalles del artículo, según sea necesario
            return RedirectToAction("Index", "Home");
        }

    }
}
