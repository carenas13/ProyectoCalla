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
    public class ExposureClimatesController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: ExposureClimates
        public ActionResult Index()
        {
            return View(db.ExposureClimates.ToList());
        }

        // GET: ExposureClimates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExposureClimate exposureClimate = db.ExposureClimates.Find(id);
            if (exposureClimate == null)
            {
                return HttpNotFound();
            }
            return View(exposureClimate);
        }

        // GET: ExposureClimates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExposureClimates/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idExposureClimate,description")] ExposureClimate exposureClimate)
        {
            if (ModelState.IsValid)
            {
                db.ExposureClimates.Add(exposureClimate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exposureClimate);
        }

        // GET: ExposureClimates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExposureClimate exposureClimate = db.ExposureClimates.Find(id);
            if (exposureClimate == null)
            {
                return HttpNotFound();
            }
            return View(exposureClimate);
        }

        // POST: ExposureClimates/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idExposureClimate,description")] ExposureClimate exposureClimate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exposureClimate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exposureClimate);
        }

        // GET: ExposureClimates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExposureClimate exposureClimate = db.ExposureClimates.Find(id);
            if (exposureClimate == null)
            {
                return HttpNotFound();
            }
            return View(exposureClimate);
        }

        // POST: ExposureClimates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExposureClimate exposureClimate = db.ExposureClimates.Find(id);
            db.ExposureClimates.Remove(exposureClimate);
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
