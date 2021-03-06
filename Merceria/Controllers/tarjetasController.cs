using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Merceria.Models;

namespace Merceria.Controllers
{
    public class tarjetasController : Controller
    {
        private contextMerceria db = new contextMerceria();

        // GET: tarjetas
        public ActionResult Index()
        {
            var tarjetas = db.Tarjetas.Include(t => t.Usuarios);
            return View(tarjetas.ToList());
        }

        // GET: tarjetas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarjetas tarjetas = db.Tarjetas.Find(id);
            if (tarjetas == null)
            {
                return HttpNotFound();
            }
            return View(tarjetas);
        }

        // GET: tarjetas/Create
        public ActionResult Create()
        {
            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id", "Nombre");
            return View();
        }

        // POST: tarjetas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Usuario,Numero_Tarjeta,Mes_Vencimiento,Anio_Vencimiento,Estado")] Tarjetas tarjetas)
        {
            if (ModelState.IsValid)
            {
                db.Tarjetas.Add(tarjetas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id", "Nombre", tarjetas.Id_Usuario);
            return View(tarjetas);
        }

        // GET: tarjetas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarjetas tarjetas = db.Tarjetas.Find(id);
            if (tarjetas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id", "Nombre", tarjetas.Id_Usuario);
            return View(tarjetas);
        }

        // POST: tarjetas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Usuario,Numero_Tarjeta,Mes_Vencimiento,Anio_Vencimiento,Estado")] Tarjetas tarjetas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarjetas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id", "Nombre", tarjetas.Id_Usuario);
            return View(tarjetas);
        }

        // GET: tarjetas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarjetas tarjetas = db.Tarjetas.Find(id);
            if (tarjetas == null)
            {
                return HttpNotFound();
            }
            return View(tarjetas);
        }

        // POST: tarjetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarjetas tarjetas = db.Tarjetas.Find(id);
            db.Tarjetas.Remove(tarjetas);
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
