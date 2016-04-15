using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoVentas.Models;
using System.Data.Entity.Infrastructure;

namespace AutoVentas.Controllers
{
    public class AutomovilController : Controller
    {
        private DB_AUTOS db = new DB_AUTOS();

        // GET: Automovil
        public ActionResult Index()
        {
            var automovil = db.automovil.Include(a => a.marca);
            return View(automovil.ToList());
        }

        public ActionResult IndexUsuario()
        {
            var automovil = db.automovil.Include(a => a.marca);
            return View(automovil.ToList());
        }
        public ActionResult IndexReserva()
        {
            var automovil = db.automovil.Include(a => a.marca);
            return View(automovil.ToList());
        }
        public ActionResult IndexVisitantes()
        {
            var automovil = db.automovil.Include(a => a.marca);
            return View(automovil.ToList());
        }

        public ActionResult IndexAutosUsuario()
        {
            List<Usuario> usuarios = new List<Usuario>();
            usuarios.Add(db.usuario.Find(Session["IDUsuario"]));
            var automovil = db.automovil.Include(a => a.marca);
            return View(automovil.ToList());
        }
        // GET: Automovil/Details/5
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

        // GET: Automovil/Create
        public ActionResult Create()
        {
            ViewBag.idMarca = new SelectList(db.Marcas, "idMarca", "nombre");
            return View();
        }

        // POST: Automovil/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAutomovil,modelo,combustible,cilindrada,motor,manufacturacion,color,precio,idMarca")] Automovil automovil, HttpPostedFileBase archivo)
        {
            if (ModelState.IsValid)
            {
                if (archivo != null && archivo.ContentLength > 0)
                {
                    var imagen = new Archivo
                    {
                        nombre = System.IO.Path.GetFileName(archivo.FileName),
                        tipo = FileType.Image,
                        contentType = archivo.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(archivo.InputStream))
                    {
                        imagen.contenido = reader.ReadBytes(archivo.ContentLength);
                    };
                    automovil.archivos = new List<Archivo> { imagen };
                }
                db.automovil.Add(automovil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMarca = new SelectList(db.Marcas, "idMarca", "nombre", automovil.idMarca);
            return View(automovil);
        }

        // GET: Automovil/Edit/5
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

        // POST: Automovil/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost,ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, HttpPostedFileBase archivo)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var automovil = db.automovil.Find(id);
            if (TryUpdateModel(automovil, "", new string[] { "idAutomovil,modelo,combustible,cilindrada,motor,manufacturacion,color,precio,idMarca" }))
            {
                try
                {
                    if (archivo != null && archivo.ContentLength > 0)
                    {
                        if (automovil.archivos.Any(a => a.tipo == FileType.Image))
                        {
                            db.archivo.Remove(automovil.archivos.First(a => a.tipo == FileType.Image));
                        }
                        var imagen = new Archivo
                        {
                            nombre = System.IO.Path.GetFileName(archivo.FileName),
                            tipo = FileType.Image,
                            contentType = archivo.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(archivo.InputStream))
                        {
                            imagen.contenido = reader.ReadBytes(archivo.ContentLength);
                        }
                        automovil.archivos = new List<Archivo> { imagen};
                    }
                    db.Entry(automovil).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                  
                }
                catch (RetryLimitExceededException ex)
                {
                    ModelState.AddModelError("", "Error al agregar la imagen");
                }
            }
            ViewBag.idMarca = new SelectList(db.Marcas, "idMarca", "nombre", automovil.idMarca);
            return View(automovil);
        }

        // GET: Automovil/Delete/5
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

        // POST: Automovil/Delete/5
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
