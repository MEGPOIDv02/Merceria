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
    public class enviosController : Controller
    {
        private contextMerceria db = new contextMerceria();

        // GET: envios
        public ActionResult Index()
        {
            return View(db.Envios.ToList());
        }

        // GET: envios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Envios envios = db.Envios.Find(id);
            if (envios == null)
            {
                return HttpNotFound();
            }
            return View(envios);
        }

        // GET: envios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: envios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Paqueteria,Id_Venta,Codigo_Rastreo,Fecha_Envio,Fecha_Estimada_Entrega,Estado_Envio,Fecha_Entrega,Estado")] Envios envios)
        {
            if (ModelState.IsValid)
            {
                db.Envios.Add(envios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(envios);
        }

        // GET: envios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Envios envios = db.Envios.Find(id);
            if (envios == null)
            {
                return HttpNotFound();
            }
            return View(envios);
        }

        // POST: envios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Paqueteria,Id_Venta,Codigo_Rastreo,Fecha_Envio,Fecha_Estimada_Entrega,Estado_Envio,Fecha_Entrega,Estado")] Envios envios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(envios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(envios);
        }

        // GET: envios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Envios envios = db.Envios.Find(id);
            if (envios == null)
            {
                return HttpNotFound();
            }
            return View(envios);
        }

        // POST: envios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Envios envios = db.Envios.Find(id);
            db.Envios.Remove(envios);
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
