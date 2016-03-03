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
    public class ParticipantesController : Controller
    {
        private GTHContext db = new GTHContext();

        // GET: GTH/Participantes
        public ActionResult Index()
        {
            var participantes = db.Participantes.Include(p => p.formacionYDesarrollo);
            return View(participantes.ToList());
        }

        // GET: GTH/Participantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participante participante = db.Participantes.Find(id);
            if (participante == null)
            {
                return HttpNotFound();
            }
            return View(participante);
        }

        // GET: GTH/Participantes/Create
        public ActionResult Create()
        {
            ViewBag.idFormacionYDesarrollo = new SelectList(db.FormacionYDesarrolloes, "idFormacionYDesarrollo", "nombreTema");
            return View();
        }

        // POST: GTH/Participantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPartipante,nombreParticipante,nmIdentificacion,areaDeTrabajo,cargo,idFormacionYDesarrollo")] Participante participante)
        {
            if (ModelState.IsValid)
            {
                db.Participantes.Add(participante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFormacionYDesarrollo = new SelectList(db.FormacionYDesarrolloes, "idFormacionYDesarrollo", "nombreTema", participante.idFormacionYDesarrollo);
            return View(participante);
        }

        // GET: GTH/Participantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participante participante = db.Participantes.Find(id);
            if (participante == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFormacionYDesarrollo = new SelectList(db.FormacionYDesarrolloes, "idFormacionYDesarrollo", "nombreTema", participante.idFormacionYDesarrollo);
            return View(participante);
        }

        // POST: GTH/Participantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPartipante,nombreParticipante,nmIdentificacion,areaDeTrabajo,cargo,idFormacionYDesarrollo")] Participante participante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFormacionYDesarrollo = new SelectList(db.FormacionYDesarrolloes, "idFormacionYDesarrollo", "nombreTema", participante.idFormacionYDesarrollo);
            return View(participante);
        }

        // GET: GTH/Participantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participante participante = db.Participantes.Find(id);
            if (participante == null)
            {
                return HttpNotFound();
            }
            return View(participante);
        }

        // POST: GTH/Participantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Participante participante = db.Participantes.Find(id);
            db.Participantes.Remove(participante);
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
