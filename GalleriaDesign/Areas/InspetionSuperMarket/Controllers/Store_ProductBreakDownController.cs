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
    public class Store_ProductBreakDownController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: Store_ProductBreakDown
        public ActionResult Index()
        {
            var store_ProductBreakDown = db.Store_ProductBreakDown.Include(s => s.productBreackDown).Include(s => s.storeInformation);
            return View(store_ProductBreakDown.ToList());
        }

        // GET: Store_ProductBreakDown/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store_ProductBreakDown store_ProductBreakDown = db.Store_ProductBreakDown.Find(id);
            if (store_ProductBreakDown == null)
            {
                return HttpNotFound();
            }
            return View(store_ProductBreakDown);
        }

        // GET: Store_ProductBreakDown/Create
        public ActionResult Create()
        {
            ViewBag.idProductBD = new SelectList(db.ProductBreackDowns, "idProductBD", "description");
            ViewBag.idStoreInformation = new SelectList(db.StoreInformations, "idStoreInformation", "otherRetailer");
            return View();
        }

        // POST: Store_ProductBreakDown/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idStoreProductBreakDown,idStoreInformation,idProductBD,percent")] Store_ProductBreakDown store_ProductBreakDown)
        {
            if (ModelState.IsValid)
            {
                db.Store_ProductBreakDown.Add(store_ProductBreakDown);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProductBD = new SelectList(db.ProductBreackDowns, "idProductBD", "description", store_ProductBreakDown.idProductBD);
            ViewBag.idStoreInformation = new SelectList(db.StoreInformations, "idStoreInformation", "otherRetailer", store_ProductBreakDown.idStoreInformation);
            return View(store_ProductBreakDown);
        }

        // GET: Store_ProductBreakDown/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store_ProductBreakDown store_ProductBreakDown = db.Store_ProductBreakDown.Find(id);
            if (store_ProductBreakDown == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProductBD = new SelectList(db.ProductBreackDowns, "idProductBD", "description", store_ProductBreakDown.idProductBD);
            ViewBag.idStoreInformation = new SelectList(db.StoreInformations, "idStoreInformation", "otherRetailer", store_ProductBreakDown.idStoreInformation);
            return View(store_ProductBreakDown);
        }

        // POST: Store_ProductBreakDown/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idStoreProductBreakDown,idStoreInformation,idProductBD,percent")] Store_ProductBreakDown store_ProductBreakDown)
        {
            if (ModelState.IsValid)
            {
                db.Entry(store_ProductBreakDown).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProductBD = new SelectList(db.ProductBreackDowns, "idProductBD", "description", store_ProductBreakDown.idProductBD);
            ViewBag.idStoreInformation = new SelectList(db.StoreInformations, "idStoreInformation", "otherRetailer", store_ProductBreakDown.idStoreInformation);
            return View(store_ProductBreakDown);
        }

        // GET: Store_ProductBreakDown/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store_ProductBreakDown store_ProductBreakDown = db.Store_ProductBreakDown.Find(id);
            if (store_ProductBreakDown == null)
            {
                return HttpNotFound();
            }
            return View(store_ProductBreakDown);
        }

        // POST: Store_ProductBreakDown/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Store_ProductBreakDown store_ProductBreakDown = db.Store_ProductBreakDown.Find(id);
            db.Store_ProductBreakDown.Remove(store_ProductBreakDown);
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
