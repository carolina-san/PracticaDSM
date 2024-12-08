﻿using DsmGen.ApplicationCore.CEN.Dominio_dsm;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.Infraestructure.Repository.Dominio_dsm;
using Interfaz.Assemblers;
using Interfaz.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Interfaz.Controllers
{
    public class ArticuloController : BasicController
    {
        private readonly IWebHostEnvironment _webHost;

        public ArticuloController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }
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
            SessionInitialize();
            ArticuloRepository artRepository = new ArticuloRepository(session);
            ArticuloCEN artCEN = new ArticuloCEN(artRepository);


            ArticuloEN artEN = artCEN.DameOID(id);
            ArticuloViewModel artView = new ArticuloAssembler().ConvertirENToViewModel(artEN);
            SessionClose();
            return View(artView);
        }

        // GET: ArticuloController/Create
        public ActionResult Create()
        {
            MarcaRepository marcaRepository = new MarcaRepository();
            MarcaCEN marcaCEN = new MarcaCEN(marcaRepository);

            IList<MarcaEN> listaMarcas = marcaCEN.DameALL(0, -1);
            IList<SelectListItem> marcaItems= new List<SelectListItem>();

            foreach (MarcaEN marca in listaMarcas)
            {
                marcaItems.Add(new SelectListItem { Text = marca.Nombre ,Value=marca.Nombre});
            }
            ViewData["marcaItems"] = marcaItems;
            return View();
        }

        // POST: ArticuloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(ArticuloViewModel art)
        {
            string fileName = "", path = "";
            if(art.Fichero!=null && art.Fichero.Length > 0)
            {
                fileName=Path.GetFileName(art.Fichero.FileName).Trim();
                string directory = _webHost.WebRootPath + "/Images";
                path = Path.Combine((directory), fileName);

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                using (var stream = System.IO.File.Create(path))
                {
                    await art.Fichero.CopyToAsync(stream);
                }
            }
            try
            {
                fileName = "/Images/" + fileName;
                ArticuloRepository artRepo = new ArticuloRepository();
                ArticuloCEN artCEN = new ArticuloCEN(artRepo);
                artCEN.Nuevo(art.Nombre, art.Precio,art.Descripcion,art.Talla, art.Recomendaciones,
                    art.Check_verificado,art.Desc_verificado,art.Marca.Nombre, art.Stock, art.Color/*, fileName*/);
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
            SessionInitialize();
            ArticuloRepository artRepository = new ArticuloRepository(session);
            ArticuloCEN artCEN = new ArticuloCEN(artRepository);


            ArticuloEN artEN = artCEN.DameOID(id);
            ArticuloViewModel artView= new ArticuloAssembler().ConvertirENToViewModel(artEN);
            SessionClose(); 
            return View(artView);
        }

        // POST: ArticuloController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArticuloViewModel art)
        {
            try
            {
                ArticuloRepository artRepository = new ArticuloRepository();
                ArticuloCEN artCEN = new ArticuloCEN(artRepository);
                artCEN.Modificar(id, art.Nombre, art.Precio, art.Descripcion, art.Talla, art.Recomendaciones, art.Check_verificado, art.Desc_verificado, art.Marca, art.Stock,true, art.Color);
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
            ArticuloRepository artRepository = new ArticuloRepository();
            ArticuloCEN artCEN = new ArticuloCEN(artRepository);
            artCEN.Eliminar(id);
            return RedirectToAction(nameof(Index));
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
