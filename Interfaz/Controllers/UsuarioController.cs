using DsmGen.ApplicationCore.CEN.Dominio_dsm;
using DsmGen.ApplicationCore.EN.Dominio_dsm;
using DsmGen.Infraestructure.Repository.Dominio_dsm;
using Interfaz.Assemblers;
using Interfaz.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // POST: UsuarioController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
    }
}
