using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GalleriaDesign.Areas.InspetionSuperMarket.Models;
using Supermarket.Models;

namespace GalleriaDesign.Areas.InspetionSuperMarket.Controllers
{
    public class AdditionalComentsController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: InspetionSuperMarket/AdditionalComents
        public ActionResult Index()
        {
            return View(db.AdditionalComents.ToList());
        }

        // GET: InspetionSuperMarket/AdditionalComents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdditionalComents additionalComents = db.AdditionalComents.Find(id);
            if (additionalComents == null)
            {
                return HttpNotFound();
            }
            return View(additionalComents);
        }

        // GET: InspetionSuperMarket/AdditionalComents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InspetionSuperMarket/AdditionalComents/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAdditionalComents,additionalComents")] AdditionalComents additionalComents)
        {
            if (ModelState.IsValid)
            {
                db.AdditionalComents.Add(additionalComents);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(additionalComents);
        }

        // GET: InspetionSuperMarket/AdditionalComents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdditionalComents additionalComents = db.AdditionalComents.Find(id);
            if (additionalComents == null)
            {
                return HttpNotFound();
            }
            return View(additionalComents);
        }

        // POST: InspetionSuperMarket/AdditionalComents/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAdditionalComents,additionalComents")] AdditionalComents additionalComents)
        {
            if (ModelState.IsValid)
            {
                db.Entry(additionalComents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(additionalComents);
        }

        // GET: InspetionSuperMarket/AdditionalComents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdditionalComents additionalComents = db.AdditionalComents.Find(id);
            if (additionalComents == null)
            {
                return HttpNotFound();
            }
            return View(additionalComents);
        }

        // POST: InspetionSuperMarket/AdditionalComents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdditionalComents additionalComents = db.AdditionalComents.Find(id);
            db.AdditionalComents.Remove(additionalComents);
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
