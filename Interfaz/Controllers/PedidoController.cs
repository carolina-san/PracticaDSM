using DsmGen.ApplicationCore.CEN.Dominio_dsm;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
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
    }
}
