using DsmGen.ApplicationCore.CEN.Dominio_dsm;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.Infraestructure.Repository.Dominio_dsm;
using Interfaz.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Interfaz.Controllers
{
    public class ArticuloController : BasicController
    {
        // GET: ArticuloController
        public ActionResult Index()
        {
            SessionInitialize();
            ArticuloRepository artRepository = new ArticuloRepository(session);
            ArticuloCEN artCEN = new ArticuloCEN(artRepository);
            IList<ArticuloEN> listEN = artCEN.DameALL(0, -1);

            IEnumerable<ArticuloViewModel> listArts = new ArticuloAssembler().ConvertirListENToViewModel(listEN).ToList();
            SessionClose();
            return View(listArts);
        }

        // GET: ArticuloController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArticuloController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticuloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticuloViewModel art)
        {
            try
            {
                ArticuloRepository artRepo = new ArticuloRepository();
                ArticuloCEN artCEN = new ArticuloCEN(artRepo);
                artCEN.Nuevo(art.Nombre, art.Precio,art.Descripcion,art.Talla, art.Recomendaciones,art.Check_verificado,art.Desc_verificado,art.Marca.Nombre, art.Stock, art.Color);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticuloController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArticuloController/Edit/5
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

        // GET: ArticuloController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArticuloController/Delete/5
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
