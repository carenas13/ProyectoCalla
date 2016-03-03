using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApplicationProductionsFarms.Model;
using ApplicationProductionsFarms.Models;

namespace GalleriaDesign.Areas.ProductionFarms.Controllers
{
    public class VarietiesController : Controller
    {
        private ApplicationProductionsFarmsContext db = new ApplicationProductionsFarmsContext();

        // GET: ProductionFarms/Varieties
        public ActionResult Index()
        {
            return View(db.Varieties.ToList());
        }

        // GET: ProductionFarms/Varieties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Variety variety = db.Varieties.Find(id);
            if (variety == null)
            {
                return HttpNotFound();
            }
            return View(variety);
        }

        // GET: ProductionFarms/Varieties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductionFarms/Varieties/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVariety,codVariety,descriptionVariety")] Variety variety)
        {
            if (ModelState.IsValid)
            {
                db.Varieties.Add(variety);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(variety);
        }

        // GET: ProductionFarms/Varieties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Variety variety = db.Varieties.Find(id);
            if (variety == null)
            {
                return HttpNotFound();
            }
            return View(variety);
        }

        // POST: ProductionFarms/Varieties/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVariety,codVariety,descriptionVariety")] Variety variety)
        {
            if (ModelState.IsValid)
            {
                db.Entry(variety).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(variety);
        }

        // GET: ProductionFarms/Varieties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Variety variety = db.Varieties.Find(id);
            if (variety == null)
            {
                return HttpNotFound();
            }
            return View(variety);
        }

        // POST: ProductionFarms/Varieties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Variety variety = db.Varieties.Find(id);
            db.Varieties.Remove(variety);
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
