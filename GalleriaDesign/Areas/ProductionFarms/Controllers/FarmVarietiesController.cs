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
    public class FarmVarietiesController : Controller
    {
        private ApplicationProductionsFarmsContext db = new ApplicationProductionsFarmsContext();

        // GET: ProductionFarms/FarmVarieties
        public ActionResult Index()
        {
            var farmVarieties = db.FarmVarieties.Include(f => f.Farms).Include(f => f.Variety);
            return View(farmVarieties.ToList());
        }

        // GET: ProductionFarms/FarmVarieties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FarmVariety farmVariety = db.FarmVarieties.Find(id);
            if (farmVariety == null)
            {
                return HttpNotFound();
            }
            return View(farmVariety);
        }

        // GET: ProductionFarms/FarmVarieties/Create
        public ActionResult Create()
        {
            ViewBag.idFarms = new SelectList(db.Farms, "idFarms", "codeFarms");
            ViewBag.idVariety = new SelectList(db.Varieties, "idVariety", "codVariety");
            return View();
        }

        // POST: ProductionFarms/FarmVarieties/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFarmVariety,idFarms,idVariety")] FarmVariety farmVariety)
        {
            if (ModelState.IsValid)
            {
                db.FarmVarieties.Add(farmVariety);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFarms = new SelectList(db.Farms, "idFarms", "codeFarms", farmVariety.idFarms);
            ViewBag.idVariety = new SelectList(db.Varieties, "idVariety", "codVariety", farmVariety.idVariety);
            return View(farmVariety);
        }

        // GET: ProductionFarms/FarmVarieties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FarmVariety farmVariety = db.FarmVarieties.Find(id);
            if (farmVariety == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFarms = new SelectList(db.Farms, "idFarms", "codeFarms", farmVariety.idFarms);
            ViewBag.idVariety = new SelectList(db.Varieties, "idVariety", "codVariety", farmVariety.idVariety);
            return View(farmVariety);
        }

        // POST: ProductionFarms/FarmVarieties/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFarmVariety,idFarms,idVariety")] FarmVariety farmVariety)
        {
            if (ModelState.IsValid)
            {
                db.Entry(farmVariety).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFarms = new SelectList(db.Farms, "idFarms", "codeFarms", farmVariety.idFarms);
            ViewBag.idVariety = new SelectList(db.Varieties, "idVariety", "codVariety", farmVariety.idVariety);
            return View(farmVariety);
        }

        // GET: ProductionFarms/FarmVarieties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FarmVariety farmVariety = db.FarmVarieties.Find(id);
            if (farmVariety == null)
            {
                return HttpNotFound();
            }
            return View(farmVariety);
        }

        // POST: ProductionFarms/FarmVarieties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FarmVariety farmVariety = db.FarmVarieties.Find(id);
            db.FarmVarieties.Remove(farmVariety);
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
