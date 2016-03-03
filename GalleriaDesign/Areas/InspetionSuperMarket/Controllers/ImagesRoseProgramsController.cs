using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GalleriaDesign.Areas.InspetionSuperMarket.Models;
using Supermarket.Models;

namespace GalleriaDesign.Areas.InspetionSuperMarket.Controllers
{
    public class ImagesRoseProgramsController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: InspetionSuperMarket/ImagesRosePrograms
        public ActionResult Index()
        {
            var imagesRosePrograms = db.ImagesRosePrograms.Include(i => i.roseProgram);
            return View(imagesRosePrograms.ToList());
        }

        // GET: InspetionSuperMarket/ImagesRosePrograms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagesRoseProgram imagesRoseProgram = db.ImagesRosePrograms.Find(id);
            if (imagesRoseProgram == null)
            {
                return HttpNotFound();
            }
            return View(imagesRoseProgram);
        }

        // GET: InspetionSuperMarket/ImagesRosePrograms/Create
        public ActionResult Create()
        {
            ViewBag.idRoseProgram = new SelectList(db.RosePrograms, "idRoseProgram", "programDescription");
            return View();
        }

        // POST: InspetionSuperMarket/ImagesRosePrograms/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "imageRoseID,image,idRoseProgram")] ImagesRoseProgram imagesRoseProgram)
        {
            if (ModelState.IsValid)
            {
                db.ImagesRosePrograms.Add(imagesRoseProgram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idRoseProgram = new SelectList(db.RosePrograms, "idRoseProgram", "programDescription", imagesRoseProgram.idRoseProgram);
            return View(imagesRoseProgram);
        }

        // GET: InspetionSuperMarket/ImagesRosePrograms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagesRoseProgram imagesRoseProgram = db.ImagesRosePrograms.Find(id);
            if (imagesRoseProgram == null)
            {
                return HttpNotFound();
            }
            ViewBag.idRoseProgram = new SelectList(db.RosePrograms, "idRoseProgram", "programDescription", imagesRoseProgram.idRoseProgram);
            return View(imagesRoseProgram);
        }

        // POST: InspetionSuperMarket/ImagesRosePrograms/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "imageRoseID,image,idRoseProgram")] ImagesRoseProgram imagesRoseProgram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagesRoseProgram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idRoseProgram = new SelectList(db.RosePrograms, "idRoseProgram", "programDescription", imagesRoseProgram.idRoseProgram);
            return View(imagesRoseProgram);
        }

        // GET: InspetionSuperMarket/ImagesRosePrograms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagesRoseProgram imagesRoseProgram = db.ImagesRosePrograms.Find(id);
            if (imagesRoseProgram == null)
            {
                return HttpNotFound();
            }
            return View(imagesRoseProgram);
        }

        // POST: InspetionSuperMarket/ImagesRosePrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImagesRoseProgram imagesRoseProgram = db.ImagesRosePrograms.Find(id);
            db.ImagesRosePrograms.Remove(imagesRoseProgram);
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
