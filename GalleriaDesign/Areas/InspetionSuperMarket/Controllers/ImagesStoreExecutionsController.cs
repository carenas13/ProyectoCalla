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
    public class ImagesStoreExecutionsController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: InspetionSuperMarket/ImagesStoreExecutions
        public ActionResult Index()
        {
            var imagesStoreExecutions = db.ImagesStoreExecutions.Include(i => i.storeExecution);
            return View(imagesStoreExecutions.ToList());
        }

        // GET: InspetionSuperMarket/ImagesStoreExecutions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagesStoreExecution imagesStoreExecution = db.ImagesStoreExecutions.Find(id);
            if (imagesStoreExecution == null)
            {
                return HttpNotFound();
            }
            return View(imagesStoreExecution);
        }

        // GET: InspetionSuperMarket/ImagesStoreExecutions/Create
        public ActionResult Create()
        {
            ViewBag.idStoreExecution = new SelectList(db.StoreExecutions, "idStoreExecution", "otherCommentsExecution");
            return View();
        }

        // POST: InspetionSuperMarket/ImagesStoreExecutions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "imageStoreExecutionID,image,idStoreExecution")] ImagesStoreExecution imagesStoreExecution)
        {
            if (ModelState.IsValid)
            {
                db.ImagesStoreExecutions.Add(imagesStoreExecution);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idStoreExecution = new SelectList(db.StoreExecutions, "idStoreExecution", "otherCommentsExecution", imagesStoreExecution.idStoreExecution);
            return View(imagesStoreExecution);
        }

        // GET: InspetionSuperMarket/ImagesStoreExecutions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagesStoreExecution imagesStoreExecution = db.ImagesStoreExecutions.Find(id);
            if (imagesStoreExecution == null)
            {
                return HttpNotFound();
            }
            ViewBag.idStoreExecution = new SelectList(db.StoreExecutions, "idStoreExecution", "otherCommentsExecution", imagesStoreExecution.idStoreExecution);
            return View(imagesStoreExecution);
        }

        // POST: InspetionSuperMarket/ImagesStoreExecutions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "imageStoreExecutionID,image,idStoreExecution")] ImagesStoreExecution imagesStoreExecution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagesStoreExecution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idStoreExecution = new SelectList(db.StoreExecutions, "idStoreExecution", "otherCommentsExecution", imagesStoreExecution.idStoreExecution);
            return View(imagesStoreExecution);
        }

        // GET: InspetionSuperMarket/ImagesStoreExecutions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagesStoreExecution imagesStoreExecution = db.ImagesStoreExecutions.Find(id);
            if (imagesStoreExecution == null)
            {
                return HttpNotFound();
            }
            return View(imagesStoreExecution);
        }

        // POST: InspetionSuperMarket/ImagesStoreExecutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImagesStoreExecution imagesStoreExecution = db.ImagesStoreExecutions.Find(id);
            db.ImagesStoreExecutions.Remove(imagesStoreExecution);
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
