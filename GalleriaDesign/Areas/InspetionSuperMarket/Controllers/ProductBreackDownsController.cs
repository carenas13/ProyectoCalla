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
    public class ProductBreackDownsController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: ProductBreackDowns
        public ActionResult Index()
        {
            return View(db.ProductBreackDowns.ToList());
        }

        // GET: ProductBreackDowns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBreackDown productBreackDown = db.ProductBreackDowns.Find(id);
            if (productBreackDown == null)
            {
                return HttpNotFound();
            }
            return View(productBreackDown);
        }

        // GET: ProductBreackDowns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductBreackDowns/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProductBD,description")] ProductBreackDown productBreackDown)
        {
            if (ModelState.IsValid)
            {
                db.ProductBreackDowns.Add(productBreackDown);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productBreackDown);
        }

        // GET: ProductBreackDowns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBreackDown productBreackDown = db.ProductBreackDowns.Find(id);
            if (productBreackDown == null)
            {
                return HttpNotFound();
            }
            return View(productBreackDown);
        }

        // POST: ProductBreackDowns/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProductBD,description")] ProductBreackDown productBreackDown)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productBreackDown).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productBreackDown);
        }

        // GET: ProductBreackDowns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBreackDown productBreackDown = db.ProductBreackDowns.Find(id);
            if (productBreackDown == null)
            {
                return HttpNotFound();
            }
            return View(productBreackDown);
        }

        // POST: ProductBreackDowns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductBreackDown productBreackDown = db.ProductBreackDowns.Find(id);
            db.ProductBreackDowns.Remove(productBreackDown);
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
