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
    public class BunchSpecificationsController : Controller
    {
        private Applicative_OrderContext db = new Applicative_OrderContext();

        // GET: BunchSpecifications
        public ActionResult Index()
        {
            return View(db.BunchSpecifications.ToList());
        }

        // GET: BunchSpecifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BunchSpecification bunchSpecification = db.BunchSpecifications.Find(id);
            if (bunchSpecification == null)
            {
                return HttpNotFound();
            }
            return View(bunchSpecification);
        }

        // GET: BunchSpecifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BunchSpecifications/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bunchSpecificationID,length,thickness,cut,defoliation,foliage")] BunchSpecification bunchSpecification)
        {
            if (ModelState.IsValid)
            {
                db.BunchSpecifications.Add(bunchSpecification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bunchSpecification);
        }

        // GET: BunchSpecifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BunchSpecification bunchSpecification = db.BunchSpecifications.Find(id);
            if (bunchSpecification == null)
            {
                return HttpNotFound();
            }
            return View(bunchSpecification);
        }

        // POST: BunchSpecifications/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bunchSpecificationID,length,thickness,cut,defoliation,foliage")] BunchSpecification bunchSpecification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bunchSpecification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bunchSpecification);
        }

        // GET: BunchSpecifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BunchSpecification bunchSpecification = db.BunchSpecifications.Find(id);
            if (bunchSpecification == null)
            {
                return HttpNotFound();
            }
            return View(bunchSpecification);
        }

        // POST: BunchSpecifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BunchSpecification bunchSpecification = db.BunchSpecifications.Find(id);
            db.BunchSpecifications.Remove(bunchSpecification);
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
