﻿using DsmGen.ApplicationCore.CEN.Dominio_dsm;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.Infraestructure.Repository.Dominio_dsm;
using Interfaz.Assemblers;
using Interfaz.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Interfaz.Controllers
{
    public class UsuarioController : BasicController
    {
        // GET: UsuarioController/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: UsuarioController/Login
        [HttpPost]
        public ActionResult Login(LoginUsuarioViewModel login)
        {
            UsuarioRepository usuRepo = new UsuarioRepository();
            UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);

            if (usuCEN.Login(login.Email, login.Password) == null)
            {
                ModelState.AddModelError("", "Error al introducir los datos del email o Password");
                return View();
            }
            else
            {
                SessionInitialize();
                UsuarioEN usuEN=usuCEN.DameOID(login.Email);
                UsuarioViewModel usuVM=new UsuarioAssembler().ConvertirENToViewModel(usuEN);
                HttpContext.Session.Set<UsuarioViewModel>("usuario", usuVM);

                SessionClose();
                return RedirectToAction("index", "home");
            }
        }

        public ActionResult Index()
        {
            return View();
        }


        // GET: UsuarioController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController1/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }
        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Verificar que el usuario sea mayor de edad (por ejemplo, al menos 18 años)
            var edad = DateTime.Today.Year - model.FechaNac.Year;
            if (model.FechaNac.Date > DateTime.Today.AddYears(-edad))
            {
                edad--;
            }

            if (edad < 18)
            {
                ModelState.AddModelError("", "Debes tener al menos 18 años para registrarte.");
                return View(model);
            }

            // Encriptar la contraseña y guardar al usuario (igual que antes)
            UsuarioRepository userRepo = new UsuarioRepository();
            UsuarioCEN userCEN = new UsuarioCEN(userRepo);

            // Llamar al método de creación del usuario
            userCEN.Nuevo(
                model.Email,
                model.Nombre,
                model.FechaNac,
                model.Password
            );

            return RedirectToAction("Login");
        }

        // GET: UsuarioController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController1/Edit/5
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
        public IActionResult Logout()
        {
            // Eliminar la sesión
            HttpContext.Session.Clear();

            // Redirigir al inicio de sesión o página principal pública
            return RedirectToAction("Index", "Home");
        }
        // GET: UsuarioController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController1/Delete/5
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

        // GET: UsuarioController/Perfil/5
        public IActionResult Perfil()
        {
            UsuarioViewModel usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");

            if (usuario == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            // Obtener los artículos favoritos del usuario (suponiendo que ya existe un método para esto)
            IList<ArticuloViewModel> favoritos = obtenerFavoritosPorUsuario(usuario.Email);
            usuario.Favoritos = favoritos;
            return View(usuario);
        }

        public IList<ArticuloViewModel> obtenerFavoritosPorUsuario(string email)
        {
            SessionInitialize();
            UsuarioRepository usuRepo = new UsuarioRepository();
            ArticuloAssembler ArticuloAssembler = new ArticuloAssembler();
            UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);
            UsuarioEN usuarioEN = usuCEN.DameOID(email);
            ArticuloRepository articuloRepository = new ArticuloRepository();
            ArticuloCEN articuloCEN = new ArticuloCEN(articuloRepository);
            IList<ArticuloEN> favoritos = articuloCEN.DameALL(0,-1);
            IList<ArticuloViewModel> favoritosUsuario = new List<ArticuloViewModel>();
            foreach (ArticuloEN art in favoritos)
            {
                if (art.Usuario.Contains(usuarioEN))
                {
                    ArticuloViewModel art1 = ArticuloAssembler.ConvertirENToViewModel(art);
                    favoritosUsuario.Add(art1);
                }
            }
            SessionClose();
            return favoritosUsuario;
        }
    }
}
