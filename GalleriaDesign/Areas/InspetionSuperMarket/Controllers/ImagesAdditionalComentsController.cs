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
    public class ImagesAdditionalComentsController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: InspetionSuperMarket/ImagesAdditionalComents
        public ActionResult Index()
        {
            var imagesAdditionalComents = db.ImagesAdditionalComents.Include(i => i.additionalComments);
            return View(imagesAdditionalComents.ToList());
        }

        // GET: InspetionSuperMarket/ImagesAdditionalComents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagesAdditionalComents imagesAdditionalComents = db.ImagesAdditionalComents.Find(id);
            if (imagesAdditionalComents == null)
            {
                return HttpNotFound();
            }
            return View(imagesAdditionalComents);
        }

        // GET: InspetionSuperMarket/ImagesAdditionalComents/Create
        public ActionResult Create()
        {
            ViewBag.idAdditionalComents = new SelectList(db.AdditionalComents, "idAdditionalComents", "comentsAdditional");
            return View();
        }

        // POST: InspetionSuperMarket/ImagesAdditionalComents/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "imageBouquetID,image,idAdditionalComents")] ImagesAdditionalComents imagesAdditionalComents)
        {
            if (ModelState.IsValid)
            {
                db.ImagesAdditionalComents.Add(imagesAdditionalComents);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAdditionalComents = new SelectList(db.AdditionalComents, "idAdditionalComents", "comentsAdditional", imagesAdditionalComents.idAdditionalComents);
            return View(imagesAdditionalComents);
        }

        // GET: InspetionSuperMarket/ImagesAdditionalComents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagesAdditionalComents imagesAdditionalComents = db.ImagesAdditionalComents.Find(id);
            if (imagesAdditionalComents == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAdditionalComents = new SelectList(db.AdditionalComents, "idAdditionalComents", "comentsAdditional", imagesAdditionalComents.idAdditionalComents);
            return View(imagesAdditionalComents);
        }

        // POST: InspetionSuperMarket/ImagesAdditionalComents/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "imageBouquetID,image,idAdditionalComents")] ImagesAdditionalComents imagesAdditionalComents)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagesAdditionalComents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAdditionalComents = new SelectList(db.AdditionalComents, "idAdditionalComents", "comentsAdditional", imagesAdditionalComents.idAdditionalComents);
            return View(imagesAdditionalComents);
        }

        // GET: InspetionSuperMarket/ImagesAdditionalComents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagesAdditionalComents imagesAdditionalComents = db.ImagesAdditionalComents.Find(id);
            if (imagesAdditionalComents == null)
            {
                return HttpNotFound();
            }
            return View(imagesAdditionalComents);
        }

        // POST: InspetionSuperMarket/ImagesAdditionalComents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImagesAdditionalComents imagesAdditionalComents = db.ImagesAdditionalComents.Find(id);
            db.ImagesAdditionalComents.Remove(imagesAdditionalComents);
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
