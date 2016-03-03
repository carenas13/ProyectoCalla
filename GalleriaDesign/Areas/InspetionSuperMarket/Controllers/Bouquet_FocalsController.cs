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
    public class Bouquet_FocalsController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: Bouquet_Focals
        public ActionResult Index()
        {
            var bouquet_Focals = db.Bouquet_Focals.Include(b => b.bouquetProgram).Include(b => b.focals);
            return View(bouquet_Focals.ToList());
        }

        // GET: Bouquet_Focals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bouquet_Focals bouquet_Focals = db.Bouquet_Focals.Find(id);
            if (bouquet_Focals == null)
            {
                return HttpNotFound();
            }
            return View(bouquet_Focals);
        }

        // GET: Bouquet_Focals/Create
        public ActionResult Create()
        {
            ViewBag.idBouquetProgram = new SelectList(db.BouquetPrograms, "idBouquetProgram", "descriptionProgram");
            ViewBag.idFocals = new SelectList(db.Focals, "idFocals", "nameFocal");
            return View();
        }

        // POST: Bouquet_Focals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBouquetFocals,idBouquetProgram,idFocals,countPerType")] Bouquet_Focals bouquet_Focals)
        {
            if (ModelState.IsValid)
            {
                db.Bouquet_Focals.Add(bouquet_Focals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idBouquetProgram = new SelectList(db.BouquetPrograms, "idBouquetProgram", "descriptionProgram", bouquet_Focals.idBouquetProgram);
            ViewBag.idFocals = new SelectList(db.Focals, "idFocals", "nameFocal", bouquet_Focals.idFocals);
            return View(bouquet_Focals);
        }

        // GET: Bouquet_Focals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bouquet_Focals bouquet_Focals = db.Bouquet_Focals.Find(id);
            if (bouquet_Focals == null)
            {
                return HttpNotFound();
            }
            ViewBag.idBouquetProgram = new SelectList(db.BouquetPrograms, "idBouquetProgram", "descriptionProgram", bouquet_Focals.idBouquetProgram);
            ViewBag.idFocals = new SelectList(db.Focals, "idFocals", "nameFocal", bouquet_Focals.idFocals);
            return View(bouquet_Focals);
        }

        // POST: Bouquet_Focals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBouquetFocals,idBouquetProgram,idFocals,countPerType")] Bouquet_Focals bouquet_Focals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bouquet_Focals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBouquetProgram = new SelectList(db.BouquetPrograms, "idBouquetProgram", "descriptionProgram", bouquet_Focals.idBouquetProgram);
            ViewBag.idFocals = new SelectList(db.Focals, "idFocals", "nameFocal", bouquet_Focals.idFocals);
            return View(bouquet_Focals);
        }

        // GET: Bouquet_Focals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bouquet_Focals bouquet_Focals = db.Bouquet_Focals.Find(id);
            if (bouquet_Focals == null)
            {
                return HttpNotFound();
            }
            return View(bouquet_Focals);
        }

        // POST: Bouquet_Focals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bouquet_Focals bouquet_Focals = db.Bouquet_Focals.Find(id);
            db.Bouquet_Focals.Remove(bouquet_Focals);
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
