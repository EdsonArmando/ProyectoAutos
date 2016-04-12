using AutoVentas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoVentas.Controllers
{
    public class ArchivoController : Controller
    {
        public DB_AUTOS db = new DB_AUTOS();
        // GET: Archivo
        public ActionResult Archivo(int id)
        {
            var imagen = db.archivo.Find(id);
            return File(imagen.contenido,imagen.contentType);
        }
    }
}