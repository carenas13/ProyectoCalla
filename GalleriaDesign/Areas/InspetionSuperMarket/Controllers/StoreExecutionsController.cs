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
    public class StoreExecutionsController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: StoreExecutions
        public ActionResult Index()
        {
            var storeExecutions = db.StoreExecutions.Include(s => s.coolerTemperature).Include(s => s.exposureClimate).Include(s => s.flowerPerfomance).Include(s => s.overallFloralExecution).Include(s => s.pullDates).Include(s => s.waterState).Include(s => s.waterTemperature);
            return View(storeExecutions.ToList());
        }

        // GET: StoreExecutions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreExecution storeExecution = db.StoreExecutions.Find(id);
            if (storeExecution == null)
            {
                return HttpNotFound();
            }
            return View(storeExecution);
        }

        // GET: StoreExecutions/Create
        public ActionResult Create()
        {
            ViewBag.idCoolerTemperature = new SelectList(db.CoolerTemperatures, "idCoolerTemperature", "description");
            ViewBag.idExposureClimate = new SelectList(db.ExposureClimates, "idExposureClimate", "description");
            ViewBag.idFlowerPerformance = new SelectList(db.FlowerPerfomances, "idFlowerPerformance", "description");
            ViewBag.idOverallFloral = new SelectList(db.OverallFloralExecutions, "idOverallFloral", "nameOverall");
            ViewBag.idPullDates = new SelectList(db.PullDates, "idPullDates", "description");
            ViewBag.idWaterState = new SelectList(db.WaterStates, "idWaterState", "description");
            ViewBag.idWaterTemperature = new SelectList(db.WaterTemperatures, "idWaterTemperature", "description");
            return View();
        }

        // POST: StoreExecutions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idStoreExecution,aditionalOverallComments,idOverallFloral,idFlowerPerformance,idPullDates,idWaterTemperature,idWaterState,idCoolerTemperature,idExposureClimate")] StoreExecution storeExecution)
        {
            if (ModelState.IsValid)
            {
                db.StoreExecutions.Add(storeExecution);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCoolerTemperature = new SelectList(db.CoolerTemperatures, "idCoolerTemperature", "description", storeExecution.idCoolerTemperature);
            ViewBag.idExposureClimate = new SelectList(db.ExposureClimates, "idExposureClimate", "description", storeExecution.idExposureClimate);
            ViewBag.idFlowerPerformance = new SelectList(db.FlowerPerfomances, "idFlowerPerformance", "description", storeExecution.idFlowerPerformance);
            ViewBag.idOverallFloral = new SelectList(db.OverallFloralExecutions, "idOverallFloral", "nameOverall", storeExecution.idOverallFloral);
            ViewBag.idPullDates = new SelectList(db.PullDates, "idPullDates", "description", storeExecution.idPullDates);
            ViewBag.idWaterState = new SelectList(db.WaterStates, "idWaterState", "description", storeExecution.idWaterState);
            ViewBag.idWaterTemperature = new SelectList(db.WaterTemperatures, "idWaterTemperature", "description", storeExecution.idWaterTemperature);
            return View(storeExecution);
        }

        // GET: StoreExecutions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreExecution storeExecution = db.StoreExecutions.Find(id);
            if (storeExecution == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCoolerTemperature = new SelectList(db.CoolerTemperatures, "idCoolerTemperature", "description", storeExecution.idCoolerTemperature);
            ViewBag.idExposureClimate = new SelectList(db.ExposureClimates, "idExposureClimate", "description", storeExecution.idExposureClimate);
            ViewBag.idFlowerPerformance = new SelectList(db.FlowerPerfomances, "idFlowerPerformance", "description", storeExecution.idFlowerPerformance);
            ViewBag.idOverallFloral = new SelectList(db.OverallFloralExecutions, "idOverallFloral", "nameOverall", storeExecution.idOverallFloral);
            ViewBag.idPullDates = new SelectList(db.PullDates, "idPullDates", "description", storeExecution.idPullDates);
            ViewBag.idWaterState = new SelectList(db.WaterStates, "idWaterState", "description", storeExecution.idWaterState);
            ViewBag.idWaterTemperature = new SelectList(db.WaterTemperatures, "idWaterTemperature", "description", storeExecution.idWaterTemperature);
            return View(storeExecution);
        }

        // POST: StoreExecutions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idStoreExecution,aditionalOverallComments,idOverallFloral,idFlowerPerformance,idPullDates,idWaterTemperature,idWaterState,idCoolerTemperature,idExposureClimate")] StoreExecution storeExecution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storeExecution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCoolerTemperature = new SelectList(db.CoolerTemperatures, "idCoolerTemperature", "description", storeExecution.idCoolerTemperature);
            ViewBag.idExposureClimate = new SelectList(db.ExposureClimates, "idExposureClimate", "description", storeExecution.idExposureClimate);
            ViewBag.idFlowerPerformance = new SelectList(db.FlowerPerfomances, "idFlowerPerformance", "description", storeExecution.idFlowerPerformance);
            ViewBag.idOverallFloral = new SelectList(db.OverallFloralExecutions, "idOverallFloral", "nameOverall", storeExecution.idOverallFloral);
            ViewBag.idPullDates = new SelectList(db.PullDates, "idPullDates", "description", storeExecution.idPullDates);
            ViewBag.idWaterState = new SelectList(db.WaterStates, "idWaterState", "description", storeExecution.idWaterState);
            ViewBag.idWaterTemperature = new SelectList(db.WaterTemperatures, "idWaterTemperature", "description", storeExecution.idWaterTemperature);
            return View(storeExecution);
        }

        // GET: StoreExecutions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreExecution storeExecution = db.StoreExecutions.Find(id);
            if (storeExecution == null)
            {
                return HttpNotFound();
            }
            return View(storeExecution);
        }

        // POST: StoreExecutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StoreExecution storeExecution = db.StoreExecutions.Find(id);
            db.StoreExecutions.Remove(storeExecution);
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
