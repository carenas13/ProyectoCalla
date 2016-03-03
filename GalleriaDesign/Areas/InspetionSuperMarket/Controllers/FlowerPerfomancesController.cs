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
    public class FlowerPerfomancesController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: FlowerPerfomances
        public ActionResult Index()
        {
            return View(db.FlowerPerfomances.ToList());
        }

        // GET: FlowerPerfomances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowerPerfomance flowerPerfomance = db.FlowerPerfomances.Find(id);
            if (flowerPerfomance == null)
            {
                return HttpNotFound();
            }
            return View(flowerPerfomance);
        }

        // GET: FlowerPerfomances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FlowerPerfomances/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFlowerPerformance,description")] FlowerPerfomance flowerPerfomance)
        {
            if (ModelState.IsValid)
            {
                db.FlowerPerfomances.Add(flowerPerfomance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flowerPerfomance);
        }

        // GET: FlowerPerfomances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowerPerfomance flowerPerfomance = db.FlowerPerfomances.Find(id);
            if (flowerPerfomance == null)
            {
                return HttpNotFound();
            }
            return View(flowerPerfomance);
        }

        // POST: FlowerPerfomances/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFlowerPerformance,description")] FlowerPerfomance flowerPerfomance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flowerPerfomance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flowerPerfomance);
        }

        // GET: FlowerPerfomances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowerPerfomance flowerPerfomance = db.FlowerPerfomances.Find(id);
            if (flowerPerfomance == null)
            {
                return HttpNotFound();
            }
            return View(flowerPerfomance);
        }

        // POST: FlowerPerfomances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FlowerPerfomance flowerPerfomance = db.FlowerPerfomances.Find(id);
            db.FlowerPerfomances.Remove(flowerPerfomance);
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
