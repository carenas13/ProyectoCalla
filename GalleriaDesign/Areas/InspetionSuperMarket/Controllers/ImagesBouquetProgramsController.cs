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
    public class ImagesBouquetProgramsController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: InspetionSuperMarket/ImagesBouquetPrograms
        public ActionResult Index()
        {
            var imagesBouquetPrograms = db.ImagesBouquetPrograms.Include(i => i.bouquetProgram);
            return View(imagesBouquetPrograms.ToList());
        }

        // GET: InspetionSuperMarket/ImagesBouquetPrograms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagesBouquetProgram imagesBouquetProgram = db.ImagesBouquetPrograms.Find(id);
            if (imagesBouquetProgram == null)
            {
                return HttpNotFound();
            }
            return View(imagesBouquetProgram);
        }

        // GET: InspetionSuperMarket/ImagesBouquetPrograms/Create
        public ActionResult Create()
        {
            ViewBag.idBouquetProgram = new SelectList(db.BouquetPrograms, "idBouquetProgram", "descriptionProgramBP");
            return View();
        }

        // POST: InspetionSuperMarket/ImagesBouquetPrograms/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "imageBouquetID,image,idBouquetProgram")] ImagesBouquetProgram imagesBouquetProgram)
        {
            if (ModelState.IsValid)
            {
                db.ImagesBouquetPrograms.Add(imagesBouquetProgram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idBouquetProgram = new SelectList(db.BouquetPrograms, "idBouquetProgram", "descriptionProgramBP", imagesBouquetProgram.idBouquetProgram);
            return View(imagesBouquetProgram);
        }

        // GET: InspetionSuperMarket/ImagesBouquetPrograms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagesBouquetProgram imagesBouquetProgram = db.ImagesBouquetPrograms.Find(id);
            if (imagesBouquetProgram == null)
            {
                return HttpNotFound();
            }
            ViewBag.idBouquetProgram = new SelectList(db.BouquetPrograms, "idBouquetProgram", "descriptionProgramBP", imagesBouquetProgram.idBouquetProgram);
            return View(imagesBouquetProgram);
        }

        // POST: InspetionSuperMarket/ImagesBouquetPrograms/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "imageBouquetID,image,idBouquetProgram")] ImagesBouquetProgram imagesBouquetProgram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagesBouquetProgram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBouquetProgram = new SelectList(db.BouquetPrograms, "idBouquetProgram", "descriptionProgramBP", imagesBouquetProgram.idBouquetProgram);
            return View(imagesBouquetProgram);
        }

        // GET: InspetionSuperMarket/ImagesBouquetPrograms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagesBouquetProgram imagesBouquetProgram = db.ImagesBouquetPrograms.Find(id);
            if (imagesBouquetProgram == null)
            {
                return HttpNotFound();
            }
            return View(imagesBouquetProgram);
        }

        // POST: InspetionSuperMarket/ImagesBouquetPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImagesBouquetProgram imagesBouquetProgram = db.ImagesBouquetPrograms.Find(id);
            db.ImagesBouquetPrograms.Remove(imagesBouquetProgram);
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
