using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Applicative_Order.Models;

namespace Applicative_Order.Controllers
{
    public class PackingSpecificationsController : Controller
    {
        private Applicative_OrderContext db = new Applicative_OrderContext();

        // GET: PackingSpecifications
        public ActionResult Index()
        {
            var packingSpecifications = db.PackingSpecifications.Include(p => p.boxType).Include(p => p.foodType).Include(p => p.sleeveType);
            return View(packingSpecifications.ToList());
        }

        // GET: PackingSpecifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackingSpecification packingSpecification = db.PackingSpecifications.Find(id);
            if (packingSpecification == null)
            {
                return HttpNotFound();
            }
            return View(packingSpecification);
        }

        // GET: PackingSpecifications/Create
        public ActionResult Create()
        {
            ViewBag.boxTypeID = new SelectList(db.BoxTypes, "boxTypeID", "codeBox");
            ViewBag.foodTypeID = new SelectList(db.FoodTypes, "foodTypeID", "code");
            ViewBag.sleeveTypeID = new SelectList(db.SleeveTypes, "sleeveTypeID", "codSleeveType");
            return View();
        }

        // POST: PackingSpecifications/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "packSpecID,slizeSleeve,positionSleeve,positionRubber,sleeveTypeID,boxTypeID,foodTypeID,BunchPerBox")] PackingSpecification packingSpecification)
        {
            if (ModelState.IsValid)
            {
                db.PackingSpecifications.Add(packingSpecification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.boxTypeID = new SelectList(db.BoxTypes, "boxTypeID", "codeBox", packingSpecification.boxTypeID);
            ViewBag.foodTypeID = new SelectList(db.FoodTypes, "foodTypeID", "code", packingSpecification.foodTypeID);
            ViewBag.sleeveTypeID = new SelectList(db.SleeveTypes, "sleeveTypeID", "codSleeveType", packingSpecification.sleeveTypeID);
            return View(packingSpecification);
        }

        // GET: PackingSpecifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackingSpecification packingSpecification = db.PackingSpecifications.Find(id);
            if (packingSpecification == null)
            {
                return HttpNotFound();
            }
            ViewBag.boxTypeID = new SelectList(db.BoxTypes, "boxTypeID", "codeBox", packingSpecification.boxTypeID);
            ViewBag.foodTypeID = new SelectList(db.FoodTypes, "foodTypeID", "code", packingSpecification.foodTypeID);
            ViewBag.sleeveTypeID = new SelectList(db.SleeveTypes, "sleeveTypeID", "codSleeveType", packingSpecification.sleeveTypeID);
            return View(packingSpecification);
        }

        // POST: PackingSpecifications/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "packSpecID,slizeSleeve,positionSleeve,positionRubber,sleeveTypeID,boxTypeID,foodTypeID,BunchPerBox")] PackingSpecification packingSpecification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(packingSpecification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.boxTypeID = new SelectList(db.BoxTypes, "boxTypeID", "codeBox", packingSpecification.boxTypeID);
            ViewBag.foodTypeID = new SelectList(db.FoodTypes, "foodTypeID", "code", packingSpecification.foodTypeID);
            ViewBag.sleeveTypeID = new SelectList(db.SleeveTypes, "sleeveTypeID", "codSleeveType", packingSpecification.sleeveTypeID);
            return View(packingSpecification);
        }

        // GET: PackingSpecifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackingSpecification packingSpecification = db.PackingSpecifications.Find(id);
            if (packingSpecification == null)
            {
                return HttpNotFound();
            }
            return View(packingSpecification);
        }

        // POST: PackingSpecifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PackingSpecification packingSpecification = db.PackingSpecifications.Find(id);
            db.PackingSpecifications.Remove(packingSpecification);
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
