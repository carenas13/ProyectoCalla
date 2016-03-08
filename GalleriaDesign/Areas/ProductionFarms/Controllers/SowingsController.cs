using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApplicationProductionsFarms.Models;
using GalleriaDesign.Areas.ProductionFarms.Models;

namespace GalleriaDesign.Areas.ProductionFarms.Controllers
{
    public class SowingsController : Controller
    {
        private ApplicationProductionsFarmsContext db = new ApplicationProductionsFarmsContext();

        // GET: ProductionFarms/Sowings
        public ActionResult Index()
        {
            var sowings = db.Sowings.Include(s => s.Farms);
            return View(sowings.ToList());
        }

        // GET: ProductionFarms/Sowings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sowing sowing = db.Sowings.Find(id);
            if (sowing == null)
            {
                return HttpNotFound();
            }
            return View(sowing);
        }

        // GET: ProductionFarms/Sowings/Create
        public ActionResult Create()
        {
            ViewBag.idFarms = new SelectList(db.Farms, "idFarms", "codeFarms");
            return View();
        }

        // POST: ProductionFarms/Sowings/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSowing,NumSowing,fecSowing,month,weekSowing,fusionCode,metersavailable,stemsxMeters,idFarms")] Sowing sowing)
        {
            if (ModelState.IsValid)
            {
                db.Sowings.Add(sowing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFarms = new SelectList(db.Farms, "idFarms", "codeFarms", sowing.idFarms);
            return View(sowing);
        }

        // GET: ProductionFarms/Sowings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sowing sowing = db.Sowings.Find(id);
            if (sowing == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFarms = new SelectList(db.Farms, "idFarms", "codeFarms", sowing.idFarms);
            return View(sowing);
        }

        // POST: ProductionFarms/Sowings/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSowing,NumSowing,fecSowing,month,weekSowing,fusionCode,metersavailable,stemsxMeters,idFarms")] Sowing sowing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sowing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFarms = new SelectList(db.Farms, "idFarms", "codeFarms", sowing.idFarms);
            return View(sowing);
        }

        // GET: ProductionFarms/Sowings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sowing sowing = db.Sowings.Find(id);
            if (sowing == null)
            {
                return HttpNotFound();
            }
            return View(sowing);
        }

        // POST: ProductionFarms/Sowings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sowing sowing = db.Sowings.Find(id);
            db.Sowings.Remove(sowing);
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
