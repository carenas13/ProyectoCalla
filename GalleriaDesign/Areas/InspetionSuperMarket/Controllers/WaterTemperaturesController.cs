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
    public class WaterTemperaturesController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: WaterTemperatures
        public ActionResult Index()
        {
            return View(db.WaterTemperatures.ToList());
        }

        // GET: WaterTemperatures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterTemperature waterTemperature = db.WaterTemperatures.Find(id);
            if (waterTemperature == null)
            {
                return HttpNotFound();
            }
            return View(waterTemperature);
        }

        // GET: WaterTemperatures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WaterTemperatures/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idWaterTemperature,description")] WaterTemperature waterTemperature)
        {
            if (ModelState.IsValid)
            {
                db.WaterTemperatures.Add(waterTemperature);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(waterTemperature);
        }

        // GET: WaterTemperatures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterTemperature waterTemperature = db.WaterTemperatures.Find(id);
            if (waterTemperature == null)
            {
                return HttpNotFound();
            }
            return View(waterTemperature);
        }

        // POST: WaterTemperatures/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idWaterTemperature,description")] WaterTemperature waterTemperature)
        {
            if (ModelState.IsValid)
            {
                db.Entry(waterTemperature).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(waterTemperature);
        }

        // GET: WaterTemperatures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterTemperature waterTemperature = db.WaterTemperatures.Find(id);
            if (waterTemperature == null)
            {
                return HttpNotFound();
            }
            return View(waterTemperature);
        }

        // POST: WaterTemperatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WaterTemperature waterTemperature = db.WaterTemperatures.Find(id);
            db.WaterTemperatures.Remove(waterTemperature);
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
