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
    public class WaterStatesController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: WaterStates
        public ActionResult Index()
        {
            return View(db.WaterStates.ToList());
        }

        // GET: WaterStates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterState waterState = db.WaterStates.Find(id);
            if (waterState == null)
            {
                return HttpNotFound();
            }
            return View(waterState);
        }

        // GET: WaterStates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WaterStates/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idWaterState,description")] WaterState waterState)
        {
            if (ModelState.IsValid)
            {
                db.WaterStates.Add(waterState);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(waterState);
        }

        // GET: WaterStates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterState waterState = db.WaterStates.Find(id);
            if (waterState == null)
            {
                return HttpNotFound();
            }
            return View(waterState);
        }

        // POST: WaterStates/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idWaterState,description")] WaterState waterState)
        {
            if (ModelState.IsValid)
            {
                db.Entry(waterState).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(waterState);
        }

        // GET: WaterStates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterState waterState = db.WaterStates.Find(id);
            if (waterState == null)
            {
                return HttpNotFound();
            }
            return View(waterState);
        }

        // POST: WaterStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WaterState waterState = db.WaterStates.Find(id);
            db.WaterStates.Remove(waterState);
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
