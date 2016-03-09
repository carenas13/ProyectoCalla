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
    public class ProductCallasController : Controller
    {
        private Applicative_OrderContext db = new Applicative_OrderContext();

        // GET: ProductCallas
        public ActionResult Index()
        {
            return View(db.ProductCallas.ToList());
        }

        // GET: ProductCallas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCalla productCalla = db.ProductCallas.Find(id);
            if (productCalla == null)
            {
                return HttpNotFound();
            }
            return View(productCalla);
        }

        // GET: ProductCallas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductCallas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "productCallaID,nameProduct")] ProductCalla productCalla)
        {
            if (ModelState.IsValid)
            {
                db.ProductCallas.Add(productCalla);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productCalla);
        }

        // GET: ProductCallas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCalla productCalla = db.ProductCallas.Find(id);
            if (productCalla == null)
            {
                return HttpNotFound();
            }
            return View(productCalla);
        }

        // POST: ProductCallas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "productCallaID,nameProduct")] ProductCalla productCalla)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productCalla).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productCalla);
        }

        // GET: ProductCallas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCalla productCalla = db.ProductCallas.Find(id);
            if (productCalla == null)
            {
                return HttpNotFound();
            }
            return View(productCalla);
        }

        // POST: ProductCallas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductCalla productCalla = db.ProductCallas.Find(id);
            db.ProductCallas.Remove(productCalla);
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
