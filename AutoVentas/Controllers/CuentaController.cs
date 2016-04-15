using AutoVentas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoVentas.Controllers
{
    public class CuentaController : Controller
    {
        public DB_AUTOS db = new DB_AUTOS();
        // GET: Cuenta
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            Rol rol = db.rol.FirstOrDefault(r => r.idRol == 1);
            Rol rolUsuario = db.rol.FirstOrDefault(r => r.idRol == 2);
            usuario.rol = rol;
            var usr = db.usuario.FirstOrDefault(u => u.correo == usuario.correo && u.contraseña == usuario.contraseña);
            if (usr != null && usr.rol == rol)
            {
                Session["nombreUsuario"] = usr.nombre;
                Session["idUsuario"] = usr.idUsuario;
                Session["rol"] = usr.rol.idRol;
                return VerificarSesion();
            }
            else
            {
                if (usr != null && usr.rol == rolUsuario)
                {
                    Session["nombreUsuario"] = usr.nombre;
                    Session["idUsuario"] = usr.idUsuario;
                    return VerificarSesionUsuario();
                }
                else {
                    ModelState.AddModelError("", "Verifica tus credenciales");
                }
            }
            return View();
        }
        // GET: Cuenta
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Rol rol = db.rol.FirstOrDefault(r => r.idRol == 2);
                usuario.rol = rol;
                db.usuario.Add(usuario);
                db.SaveChanges();
                ViewBag.mensaje = "El usuario " + usuario.nombre + " Fue registrado satisfactoriamente.";
                ModelState.Clear();
            }
            return RedirectToAction("Login");
        }
        public ActionResult VerificarSesion()
        {
            if (Session["idUsuario"] != null)
            {
                return RedirectToAction("../Home/Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult VerificarSesionUsuario()
        {
            if (Session["idUsuario"] != null)
            {
                return RedirectToAction("../Home/IndexUsuario");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("IDUsuario");
            Session.Remove("nombreUsuario");
            Session.Remove("rol");
            return RedirectToAction("Login");
        }

    }
}