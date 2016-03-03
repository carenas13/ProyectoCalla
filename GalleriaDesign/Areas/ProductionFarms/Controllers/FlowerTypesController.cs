using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApplicationProductionsFarms.Models;

namespace GalleriaDesign.Areas.ProductionFarms.Controllers
{
    public class FlowerTypesController : Controller
    {
        private ApplicationProductionsFarmsContext db = new ApplicationProductionsFarmsContext();

        // GET: ProductionFarms/FlowerTypes
        public ActionResult Index()
        {
            return View(db.FlowerTypes.ToList());
        }

        // GET: ProductionFarms/FlowerTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowerType flowerType = db.FlowerTypes.Find(id);
            if (flowerType == null)
            {
                return HttpNotFound();
            }
            return View(flowerType);
        }

        // GET: ProductionFarms/FlowerTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductionFarms/FlowerTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCodFlowerType,codFlowerType,description")] FlowerType flowerType)
        {
            if (ModelState.IsValid)
            {
                db.FlowerTypes.Add(flowerType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flowerType);
        }

        // GET: ProductionFarms/FlowerTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowerType flowerType = db.FlowerTypes.Find(id);
            if (flowerType == null)
            {
                return HttpNotFound();
            }
            return View(flowerType);
        }

        // POST: ProductionFarms/FlowerTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCodFlowerType,codFlowerType,description")] FlowerType flowerType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flowerType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flowerType);
        }

        // GET: ProductionFarms/FlowerTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowerType flowerType = db.FlowerTypes.Find(id);
            if (flowerType == null)
            {
                return HttpNotFound();
            }
            return View(flowerType);
        }

        // POST: ProductionFarms/FlowerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FlowerType flowerType = db.FlowerTypes.Find(id);
            db.FlowerTypes.Remove(flowerType);
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
