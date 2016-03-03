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
    public class FlowerSuppliersController : Controller
    {
        private ApplicationProductionsFarmsContext db = new ApplicationProductionsFarmsContext();

        // GET: ProductionFarms/FlowerSuppliers
        public ActionResult Index()
        {
            return View(db.FlowerSuppliers.ToList());
        }

        // GET: ProductionFarms/FlowerSuppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowerSuppliers flowerSuppliers = db.FlowerSuppliers.Find(id);
            if (flowerSuppliers == null)
            {
                return HttpNotFound();
            }
            return View(flowerSuppliers);
        }

        // GET: ProductionFarms/FlowerSuppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductionFarms/FlowerSuppliers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFlowerSup,codFlowerSup,description")] FlowerSuppliers flowerSuppliers)
        {
            if (ModelState.IsValid)
            {
                db.FlowerSuppliers.Add(flowerSuppliers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flowerSuppliers);
        }

        // GET: ProductionFarms/FlowerSuppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowerSuppliers flowerSuppliers = db.FlowerSuppliers.Find(id);
            if (flowerSuppliers == null)
            {
                return HttpNotFound();
            }
            return View(flowerSuppliers);
        }

        // POST: ProductionFarms/FlowerSuppliers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFlowerSup,codFlowerSup,description")] FlowerSuppliers flowerSuppliers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flowerSuppliers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flowerSuppliers);
        }

        // GET: ProductionFarms/FlowerSuppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowerSuppliers flowerSuppliers = db.FlowerSuppliers.Find(id);
            if (flowerSuppliers == null)
            {
                return HttpNotFound();
            }
            return View(flowerSuppliers);
        }

        // POST: ProductionFarms/FlowerSuppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FlowerSuppliers flowerSuppliers = db.FlowerSuppliers.Find(id);
            db.FlowerSuppliers.Remove(flowerSuppliers);
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
