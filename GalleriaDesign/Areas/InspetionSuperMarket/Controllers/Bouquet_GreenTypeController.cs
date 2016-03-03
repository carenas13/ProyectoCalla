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
    public class Bouquet_GreenTypeController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: Bouquet_GreenType
        public ActionResult Index()
        {
            var bouquet_GreenType = db.Bouquet_GreenType.Include(b => b.bouquetProgram);
            return View(bouquet_GreenType.ToList());
        }

        // GET: Bouquet_GreenType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bouquet_GreenType bouquet_GreenType = db.Bouquet_GreenType.Find(id);
            if (bouquet_GreenType == null)
            {
                return HttpNotFound();
            }
            return View(bouquet_GreenType);
        }

        // GET: Bouquet_GreenType/Create
        public ActionResult Create()
        {
            ViewBag.idBouquetProgram = new SelectList(db.BouquetPrograms, "idBouquetProgram", "descriptionProgram");
            return View();
        }

        // POST: Bouquet_GreenType/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBouquetGreenType,idBouquetProgram,idGreenType,checkGreenType")] Bouquet_GreenType bouquet_GreenType)
        {
            if (ModelState.IsValid)
            {
                db.Bouquet_GreenType.Add(bouquet_GreenType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idBouquetProgram = new SelectList(db.BouquetPrograms, "idBouquetProgram", "descriptionProgram", bouquet_GreenType.idBouquetProgram);
            return View(bouquet_GreenType);
        }

        // GET: Bouquet_GreenType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bouquet_GreenType bouquet_GreenType = db.Bouquet_GreenType.Find(id);
            if (bouquet_GreenType == null)
            {
                return HttpNotFound();
            }
            ViewBag.idBouquetProgram = new SelectList(db.BouquetPrograms, "idBouquetProgram", "descriptionProgram", bouquet_GreenType.idBouquetProgram);
            return View(bouquet_GreenType);
        }

        // POST: Bouquet_GreenType/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBouquetGreenType,idBouquetProgram,idGreenType,checkGreenType")] Bouquet_GreenType bouquet_GreenType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bouquet_GreenType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBouquetProgram = new SelectList(db.BouquetPrograms, "idBouquetProgram", "descriptionProgram", bouquet_GreenType.idBouquetProgram);
            return View(bouquet_GreenType);
        }

        // GET: Bouquet_GreenType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bouquet_GreenType bouquet_GreenType = db.Bouquet_GreenType.Find(id);
            if (bouquet_GreenType == null)
            {
                return HttpNotFound();
            }
            return View(bouquet_GreenType);
        }

        // POST: Bouquet_GreenType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bouquet_GreenType bouquet_GreenType = db.Bouquet_GreenType.Find(id);
            db.Bouquet_GreenType.Remove(bouquet_GreenType);
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
