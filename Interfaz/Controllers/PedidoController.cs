using DsmGen.ApplicationCore.CEN.Dominio_dsm;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.Infraestructure.CP;
using DsmGen.Infraestructure.Repository.Dominio_dsm;
using Interfaz.Assemblers;
using Interfaz.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DsmGen.ApplicationCore.CP.Dominio_dsm;
using DsmGen.Infraestructure.EN.Dominio_dsm;
using NHibernate.Criterion;
namespace Interfaz.Controllers
{
    public class PedidoController : BasicController
    {
        // GET: PedidoController
        public ActionResult Index()
        {
            SessionInitialize();

            PedidoRepository pedidoRepository = new PedidoRepository();
            PedidoCEN pedido = new PedidoCEN(pedidoRepository);
            
            IList<PedidoEN> pedidos = pedido.DameALL(0,-1);

            IEnumerable<PedidoViewModel> listPedido = new PedidoAssembler().convertirListENToViewModel(pedidos).ToList();

            SessionClose(); 

            return View(listPedido);
        }

        // GET: PedidoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PedidoController/Create
        public ActionResult Create()
        {
            return View();
        }

       
        // POST: PedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(PedidoViewModel pedido)
        {
            UsuarioViewModel usuario = HttpContext.Session.GetObject<UsuarioViewModel>("usuario");

            if (usuario == null)
            {
                // Si no hay un nombre de usuario en la sesión, redirigir a la página de login
                return RedirectToAction("Login", "Usuario");
            }
            
            try
            {
                

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: PedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PedidoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PedidoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult ConfirmarPedido(string TipoEnvio, string Calle, string Provincia, long CodigoPostal, long Telf, string Nombre)
        {
            SessionInitialize();
            // Obtener el usuario actual (esto puede variar según cómo manejas la autenticación)
            var usuario = HttpContext.Session.GetObject<UsuarioViewModel>("usuario");
            UsuarioRepository usuRepo = new UsuarioRepository();
            UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);
            UsuarioEN usuEN = usuCEN.DameOID(usuario.Email);
            // Crear la dirección
            var nuevaDireccion = new DireccionViewModel
            {
                Calle = Calle,
                Provincia = Provincia,
                CodPost = CodigoPostal,
                Telefono = Telf,
                NombreCompleto=Nombre
            };

            DireccionRepository dirRep = new DireccionRepository();
            DireccionCEN dirCEN = new DireccionCEN(dirRep);
            int idDireccion = dirCEN.Nuevo(Calle, Provincia, CodigoPostal, Telf, Nombre, usuario.Email);

            decimal gastosEnvio = TipoEnvio == "Envío rápido (+4.99€)" ? 4.99m : 0m;

            var carrito = HttpContext.Session.GetObject<CarritoViewModel>("CarritoView");
            carrito.Subtotal += gastosEnvio;

            PedidoRepository pedidoRepository = new PedidoRepository();
            PedidoCEN pedidoCEN = new PedidoCEN(pedidoRepository);
            int idPedido = pedidoCEN.Nuevo(usuario.Email, (float)gastosEnvio, idDireccion);
            PedidoEN pedido=pedidoCEN.DameOID(idPedido);
            PedidoViewModel pedidoView = new PedidoAssembler().convertirENtoViewModel(pedido);

            LineaPedidoCP lineaPedidoCEN = new LineaPedidoCP(new SessionCPNHibernate());

            foreach (var item in carrito.Articulos)
            {
                
                    lineaPedidoCEN.Nuevo(
                        idPedido,1, (float)item.Precio, item.Id
                       
                    );
                
            }
            HttpContext.Session.Set<PedidoViewModel>("pedido", pedidoView);
            SessionClose();
            return RedirectToAction("Pago","Pedido");
        }
        [HttpGet]
        public ActionResult Pago()
        {
            var pedido = HttpContext.Session.Get<PedidoViewModel>("pedido");
        
            PedidoRepository pedidoRepository = new PedidoRepository();
            PedidoCEN pedidoCEN = new PedidoCEN(pedidoRepository);
            PedidoEN pedidoEN = pedidoCEN.DameOID(pedido.Id);
            LineaPedidoRepository linped = new LineaPedidoRepository();
            LineaPedidoCEN lineaPedidoCEN = new LineaPedidoCEN(linped);
            IList<LineaPedidoEN> lineas = lineaPedidoCEN.DameALL(0,-1);
            var lineasPedido = lineas.Where(p => p.Pedido == pedidoEN).ToList();
            var viewModel = new PedidoViewModel
            {
                Articulos = lineasPedido.Select(linea => new ArticuloViewModel
                {
                    Id = linea.Articulo.Id,
                    Nombre = linea.Articulo.Nombre,
                    Imagen = linea.Articulo.Foto,
                    Precio = linea.Articulo.Precio
                }).ToList(),
                Total = lineasPedido.Sum(linea => linea.Articulo.Precio * linea.Cantidad)
            };

            return View(viewModel);
        }
        [HttpGet]
        public ActionResult MisPedidos()
        {
            var usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            PedidoRepository pedRep = new PedidoRepository();
            PedidoCEN pedCEN = new PedidoCEN(pedRep);
            IList<PedidoEN> pedidos = pedCEN.DameALL(0, -1);
            var pedidosUsuario = pedidos.Where(p => p.Usuario.Email == usuario.Email).ToList();
            IList<PedidoViewModel> pedidosView = new PedidoAssembler().convertirListENToViewModel(pedidosUsuario);
            // Pasar los pedidos filtrados a la vista
            return View(pedidosView);
        }
    }
}
