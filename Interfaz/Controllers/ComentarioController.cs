using DsmGen.ApplicationCore.CEN.Dominio_dsm;
using DsmGen.Infraestructure.Repository.Dominio_dsm;
using Interfaz.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Interfaz.Controllers
{
    public class ComentarioController : BasicController
    {
        // GET: ComentarioController/Create
        public ActionResult Create(int id)
        {
            // Verificar si el usuario está logueado
            UsuarioViewModel usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (usuario == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            // Crear un nuevo ComentarioViewModel
            ComentarioViewModel comentario = new ComentarioViewModel
            {
                Articulo = id,  
                Fecha = DateTime.Now, 
                Usuario = usuario.Email 
            };

            return View(comentario); 
        }

        // POST: ComentarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComentarioViewModel resenya)
        {

            if (ModelState.IsValid)
            {
                SessionInitialize();
                ResenyaRepository resenya2 = new ResenyaRepository();
                ResenyaCEN resenyaCEN = new ResenyaCEN(resenya2);
                ComentarioViewModel comentarioView = new ComentarioViewModel
                {
                    Estrellas= resenya.Estrellas,
                    Comentario= resenya.Comentario,
                    Articulo = resenya.Articulo,
                    Fecha = DateTime.Now,
                    Usuario = resenya.Usuario
                };
                int idComent = resenyaCEN.Nueva(comentarioView.Estrellas, comentarioView.Comentario, comentarioView.Fecha, comentarioView.Usuario, comentarioView.Articulo);
                SessionClose();
                return RedirectToAction("Detalles", "Articulo", new { id = resenya.Articulo });
            }

            return View(resenya); // Si hay errores, volver a mostrar el formulario con los datos
        }
    }
}
