using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Applicative_Order.Models;

namespace Applicative_Order.Controllers
{
    public class ProductGalleriasController : Controller
    {
        private Applicative_OrderContext db = new Applicative_OrderContext();

        // GET: ProductGallerias
        public ActionResult Index()
        {
            return View(db.ProductGallerias.ToList());
        }

        // GET: ProductGallerias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductGalleria productGalleria = db.ProductGallerias.Find(id);
            if (productGalleria == null)
            {
                return HttpNotFound();
            }
            return View(productGalleria);
        }

        // GET: ProductGallerias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductGallerias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "productGalleriaID,code,name")] ProductGalleria productGalleria)
        {
            if (ModelState.IsValid)
            {
                db.ProductGallerias.Add(productGalleria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productGalleria);
        }

        // GET: ProductGallerias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductGalleria productGalleria = db.ProductGallerias.Find(id);
            if (productGalleria == null)
            {
                return HttpNotFound();
            }
            return View(productGalleria);
        }

        // POST: ProductGallerias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "productGalleriaID,code,name")] ProductGalleria productGalleria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productGalleria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productGalleria);
        }

        // GET: ProductGallerias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductGalleria productGalleria = db.ProductGallerias.Find(id);
            if (productGalleria == null)
            {
                return HttpNotFound();
            }
            return View(productGalleria);
        }

        // POST: ProductGallerias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductGalleria productGalleria = db.ProductGallerias.Find(id);
            db.ProductGallerias.Remove(productGalleria);
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
