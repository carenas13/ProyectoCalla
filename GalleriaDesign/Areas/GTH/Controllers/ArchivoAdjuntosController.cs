using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GalleriaDesign.Areas.GTH.Models;
using GalleriaDesign.Models;

namespace GalleriaDesign.Areas.GTH.Controllers
{
    public class ArchivoAdjuntosController : Controller
    {
        private GTHContext db = new GTHContext();

        // GET: GTH/ArchivoAdjuntos
        public ActionResult Index()
        {
            var archivoAdjuntoes = db.ArchivoAdjuntoes.Include(a => a.formacionYDesarrollo);
            return View(archivoAdjuntoes.ToList());
        }

        // GET: GTH/ArchivoAdjuntos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArchivoAdjunto archivoAdjunto = db.ArchivoAdjuntoes.Find(id);
            if (archivoAdjunto == null)
            {
                return HttpNotFound();
            }
            return View(archivoAdjunto);
        }

        // GET: GTH/ArchivoAdjuntos/Create
        public ActionResult Create()
        {
            ViewBag.idFormacionYDesarrollo = new SelectList(db.FormacionYDesarrolloes, "idFormacionYDesarrollo", "nombreTema");
            return View();
        }

        // POST: GTH/ArchivoAdjuntos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idArchivoAdjunto,comentario,image,idFormacionYDesarrollo")] ArchivoAdjunto archivoAdjunto)
        {
            if (ModelState.IsValid)
            {
                db.ArchivoAdjuntoes.Add(archivoAdjunto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFormacionYDesarrollo = new SelectList(db.FormacionYDesarrolloes, "idFormacionYDesarrollo", "nombreTema", archivoAdjunto.idFormacionYDesarrollo);
            return View(archivoAdjunto);
        }

        // GET: GTH/ArchivoAdjuntos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArchivoAdjunto archivoAdjunto = db.ArchivoAdjuntoes.Find(id);
            if (archivoAdjunto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFormacionYDesarrollo = new SelectList(db.FormacionYDesarrolloes, "idFormacionYDesarrollo", "nombreTema", archivoAdjunto.idFormacionYDesarrollo);
            return View(archivoAdjunto);
        }

        // POST: GTH/ArchivoAdjuntos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idArchivoAdjunto,comentario,image,idFormacionYDesarrollo")] ArchivoAdjunto archivoAdjunto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(archivoAdjunto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFormacionYDesarrollo = new SelectList(db.FormacionYDesarrolloes, "idFormacionYDesarrollo", "nombreTema", archivoAdjunto.idFormacionYDesarrollo);
            return View(archivoAdjunto);
        }

        // GET: GTH/ArchivoAdjuntos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArchivoAdjunto archivoAdjunto = db.ArchivoAdjuntoes.Find(id);
            if (archivoAdjunto == null)
            {
                return HttpNotFound();
            }
            return View(archivoAdjunto);
        }

        // POST: GTH/ArchivoAdjuntos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArchivoAdjunto archivoAdjunto = db.ArchivoAdjuntoes.Find(id);
            db.ArchivoAdjuntoes.Remove(archivoAdjunto);
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
