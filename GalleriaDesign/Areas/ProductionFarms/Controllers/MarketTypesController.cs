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
    public class MarketTypesController : Controller
    {
        private ApplicationProductionsFarmsContext db = new ApplicationProductionsFarmsContext();

        // GET: ProductionFarms/MarketTypes
        public ActionResult Index()
        {
            return View(db.MarketTypes.ToList());
        }

        // GET: ProductionFarms/MarketTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarketType marketType = db.MarketTypes.Find(id);
            if (marketType == null)
            {
                return HttpNotFound();
            }
            return View(marketType);
        }

        // GET: ProductionFarms/MarketTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductionFarms/MarketTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMaketType,codMarketType,description")] MarketType marketType)
        {
            if (ModelState.IsValid)
            {
                db.MarketTypes.Add(marketType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(marketType);
        }

        // GET: ProductionFarms/MarketTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarketType marketType = db.MarketTypes.Find(id);
            if (marketType == null)
            {
                return HttpNotFound();
            }
            return View(marketType);
        }

        // POST: ProductionFarms/MarketTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMaketType,codMarketType,description")] MarketType marketType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marketType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marketType);
        }

        // GET: ProductionFarms/MarketTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarketType marketType = db.MarketTypes.Find(id);
            if (marketType == null)
            {
                return HttpNotFound();
            }
            return View(marketType);
        }

        // POST: ProductionFarms/MarketTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List<MarketType> markettype = db.MarketTypes.Include(r => r.varietyparametersproducts).ToList();
            MarketType markett = markettype.Find(r => r.idMaketType == id);

            //Find(id).Include(p => p.block);
            if (markett.varietyparametersproducts.Count() == 0)
            {
                db.MarketTypes.Remove(markett);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.message = "No se puede Eliminar porque existen Elementos asosociados al tipo de reporte";
            return View(markett);
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
