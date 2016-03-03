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
    public class Bouquet_BasicsController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: Bouquet_Basics
        public ActionResult Index()
        {
            var bouquet_Basics = db.Bouquet_Basics.Include(b => b.bouquetProgram);
            return View(bouquet_Basics.ToList());
        }

        // GET: Bouquet_Basics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bouquet_Basics bouquet_Basics = db.Bouquet_Basics.Find(id);
            if (bouquet_Basics == null)
            {
                return HttpNotFound();
            }
            return View(bouquet_Basics);
        }

        // GET: Bouquet_Basics/Create
        public ActionResult Create()
        {
            ViewBag.idBouquetProgram = new SelectList(db.BouquetPrograms, "idBouquetProgram", "descriptionProgram");
            return View();
        }

        // POST: Bouquet_Basics/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBBasics,idBouquetProgram,idBouquetBasics,countPerType")] Bouquet_Basics bouquet_Basics)
        {
            if (ModelState.IsValid)
            {
                db.Bouquet_Basics.Add(bouquet_Basics);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idBouquetProgram = new SelectList(db.BouquetPrograms, "idBouquetProgram", "descriptionProgram", bouquet_Basics.idBouquetProgram);
            return View(bouquet_Basics);
        }

        // GET: Bouquet_Basics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bouquet_Basics bouquet_Basics = db.Bouquet_Basics.Find(id);
            if (bouquet_Basics == null)
            {
                return HttpNotFound();
            }
            ViewBag.idBouquetProgram = new SelectList(db.BouquetPrograms, "idBouquetProgram", "descriptionProgram", bouquet_Basics.idBouquetProgram);
            return View(bouquet_Basics);
        }

        // POST: Bouquet_Basics/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBBasics,idBouquetProgram,idBouquetBasics,countPerType")] Bouquet_Basics bouquet_Basics)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bouquet_Basics).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBouquetProgram = new SelectList(db.BouquetPrograms, "idBouquetProgram", "descriptionProgram", bouquet_Basics.idBouquetProgram);
            return View(bouquet_Basics);
        }

        // GET: Bouquet_Basics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bouquet_Basics bouquet_Basics = db.Bouquet_Basics.Find(id);
            if (bouquet_Basics == null)
            {
                return HttpNotFound();
            }
            return View(bouquet_Basics);
        }

        // POST: Bouquet_Basics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bouquet_Basics bouquet_Basics = db.Bouquet_Basics.Find(id);
            db.Bouquet_Basics.Remove(bouquet_Basics);
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
