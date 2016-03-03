using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Supermarket.Models;

namespace GalleriaDesign.Areas.InspetionSuperMarket.Controllers
{
    public class Bouquet_FillerController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: Bouquet_Filler
        public ActionResult Index()
        {
            var bouquet_Filler = db.Bouquet_Filler.Include(b => b.bouquetProgram).Include(b => b.fillerType);
            return View(bouquet_Filler.ToList());
        }

        // GET: Bouquet_Filler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bouquet_Filler bouquet_Filler = db.Bouquet_Filler.Find(id);
            if (bouquet_Filler == null)
            {
                return HttpNotFound();
            }
            return View(bouquet_Filler);
        }

        // GET: Bouquet_Filler/Create
        public ActionResult Create()
        {
            ViewBag.idBouquetProgram = new SelectList(db.BouquetPrograms, "idBouquetProgram", "descriptionProgram");
            ViewBag.idFillerType = new SelectList(db.FillerTypes, "idFillerType", "nameFiller");
            return View();
        }

        // POST: Bouquet_Filler/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBouquet,idBouquetProgram,idFillerType,checkFiller")] Bouquet_Filler bouquet_Filler)
        {
            if (ModelState.IsValid)
            {
                db.Bouquet_Filler.Add(bouquet_Filler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idBouquetProgram = new SelectList(db.BouquetPrograms, "idBouquetProgram", "descriptionProgram", bouquet_Filler.idBouquetProgram);
            ViewBag.idFillerType = new SelectList(db.FillerTypes, "idFillerType", "nameFiller", bouquet_Filler.idFillerType);
            return View(bouquet_Filler);
        }

        // GET: Bouquet_Filler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bouquet_Filler bouquet_Filler = db.Bouquet_Filler.Find(id);
            if (bouquet_Filler == null)
            {
                return HttpNotFound();
            }
            ViewBag.idBouquetProgram = new SelectList(db.BouquetPrograms, "idBouquetProgram", "descriptionProgram", bouquet_Filler.idBouquetProgram);
            ViewBag.idFillerType = new SelectList(db.FillerTypes, "idFillerType", "nameFiller", bouquet_Filler.idFillerType);
            return View(bouquet_Filler);
        }

        // POST: Bouquet_Filler/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBouquet,idBouquetProgram,idFillerType,checkFiller")] Bouquet_Filler bouquet_Filler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bouquet_Filler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBouquetProgram = new SelectList(db.BouquetPrograms, "idBouquetProgram", "descriptionProgram", bouquet_Filler.idBouquetProgram);
            ViewBag.idFillerType = new SelectList(db.FillerTypes, "idFillerType", "nameFiller", bouquet_Filler.idFillerType);
            return View(bouquet_Filler);
        }

        // GET: Bouquet_Filler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bouquet_Filler bouquet_Filler = db.Bouquet_Filler.Find(id);
            if (bouquet_Filler == null)
            {
                return HttpNotFound();
            }
            return View(bouquet_Filler);
        }

        // POST: Bouquet_Filler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bouquet_Filler bouquet_Filler = db.Bouquet_Filler.Find(id);
            db.Bouquet_Filler.Remove(bouquet_Filler);
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
