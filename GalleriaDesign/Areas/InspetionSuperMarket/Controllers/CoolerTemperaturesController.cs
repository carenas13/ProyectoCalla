using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GalleriaDesign.Areas.InspetionSuperMarket.Models
{
    public class CoolerTemperaturesController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: CoolerTemperatures
        public ActionResult Index()
        {
            return View(db.CoolerTemperatures.ToList());
        }

        // GET: CoolerTemperatures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoolerTemperature coolerTemperature = db.CoolerTemperatures.Find(id);
            if (coolerTemperature == null)
            {
                return HttpNotFound();
            }
            return View(coolerTemperature);
        }

        // GET: CoolerTemperatures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoolerTemperatures/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCoolerTemperature,description")] CoolerTemperature coolerTemperature)
        {
            if (ModelState.IsValid)
            {
                db.CoolerTemperatures.Add(coolerTemperature);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coolerTemperature);
        }

        // GET: CoolerTemperatures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoolerTemperature coolerTemperature = db.CoolerTemperatures.Find(id);
            if (coolerTemperature == null)
            {
                return HttpNotFound();
            }
            return View(coolerTemperature);
        }

        // POST: CoolerTemperatures/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCoolerTemperature,description")] CoolerTemperature coolerTemperature)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coolerTemperature).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coolerTemperature);
        }

        // GET: CoolerTemperatures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoolerTemperature coolerTemperature = db.CoolerTemperatures.Find(id);
            if (coolerTemperature == null)
            {
                return HttpNotFound();
            }
            return View(coolerTemperature);
        }

        // POST: CoolerTemperatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoolerTemperature coolerTemperature = db.CoolerTemperatures.Find(id);
            db.CoolerTemperatures.Remove(coolerTemperature);
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
