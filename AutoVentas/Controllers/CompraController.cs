using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoVentas.Models;

namespace AutoVentas.Controllers
{
    public class CompraController : Controller
    {
        private DB_AUTOS db = new DB_AUTOS();

        // GET: Compra
        public ActionResult Index()
        {
            var compra = db.compra.Include(c => c.automovil).Include(c => c.usuario);
            return View(compra.ToList());
        }

        public ActionResult IndexAdmin()
        {
            var compra = db.compra.Include(c => c.automovil).Include(c => c.usuario);
            return View(compra.ToList());
        }
        // GET: Compra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compra/Create
        public ActionResult Create(int idAutomovil)
        {
            List<Automovil> autos = new List<Automovil>();
            autos.Add(db.automovil.Find(idAutomovil));
            ViewBag.idAutomovil = new SelectList(autos, "idAutomovil", "modelo");
            List<Usuario> usuarios = new List<Usuario>();
            usuarios.Add(db.usuario.Find(Session["IDUsuario"]));
            ViewBag.idUsuario = new SelectList(usuarios, "idUsuario", "Nombre");
            return View();
        }

        public ActionResult CreateAdmin()
        {
            ViewBag.idAutomovil = new SelectList(db.automovil, "idAutomovil", "modelo");
            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "nombre");
            return View();
        }
        // POST: Compra/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCompra,fecha,idUsuario,idAutomovil")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.compra.Add(compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAutomovil = new SelectList(db.automovil, "idAutomovil", "modelo", compra.idAutomovil);
            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "nombre", compra.idUsuario);
            return View(compra);
        }

        // GET: Compra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAutomovil = new SelectList(db.automovil, "idAutomovil", "modelo", compra.idAutomovil);
            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "nombre", compra.idUsuario);
            return View(compra);
        }

        // POST: Compra/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCompra,fecha,idUsuario,idAutomovil")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAutomovil = new SelectList(db.automovil, "idAutomovil", "modelo", compra.idAutomovil);
            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "nombre", compra.idUsuario);
            return View(compra);
        }

        // GET: Compra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compra compra = db.compra.Find(id);
            db.compra.Remove(compra);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
