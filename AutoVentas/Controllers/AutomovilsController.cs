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
    public class AutomovilsController : Controller
    {
        private DB_AUTOS db = new DB_AUTOS();

        // GET: Automovils
        public ActionResult Index()
        {
            var automovil = db.automovil.Include(a => a.marca);
            return View(automovil.ToList());
        }

        // GET: Automovils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovil automovil = db.automovil.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            return View(automovil);
        }

        // GET: Automovils/Create
        public ActionResult Create()
        {
            ViewBag.idMarca = new SelectList(db.Marcas, "idMarca", "nombre");
            return View();
        }

        // POST: Automovils/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAutomovil,modelo,color,precio,idMarca")] Automovil automovil)
        {
            if (ModelState.IsValid)
            {
                db.automovil.Add(automovil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMarca = new SelectList(db.Marcas, "idMarca", "nombre", automovil.idMarca);
            return View(automovil);
        }

        // GET: Automovils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovil automovil = db.automovil.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMarca = new SelectList(db.Marcas, "idMarca", "nombre", automovil.idMarca);
            return View(automovil);
        }

        // POST: Automovils/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAutomovil,modelo,color,precio,idMarca")] Automovil automovil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(automovil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMarca = new SelectList(db.Marcas, "idMarca", "nombre", automovil.idMarca);
            return View(automovil);
        }

        // GET: Automovils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovil automovil = db.automovil.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            return View(automovil);
        }

        // POST: Automovils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Automovil automovil = db.automovil.Find(id);
            db.automovil.Remove(automovil);
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
