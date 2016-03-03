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
    public class ImagesStoreInformationsController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: InspetionSuperMarket/ImagesStoreInformations
        public ActionResult Index()
        {
            var imagesStoreInformations = db.ImagesStoreInformations.Include(i => i.storeInformation);
            return View(imagesStoreInformations.ToList());
        }

        // GET: InspetionSuperMarket/ImagesStoreInformations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagesStoreInformation imagesStoreInformation = db.ImagesStoreInformations.Find(id);
            if (imagesStoreInformation == null)
            {
                return HttpNotFound();
            }
            return View(imagesStoreInformation);
        }

        // GET: InspetionSuperMarket/ImagesStoreInformations/Create
        public ActionResult Create()
        {
            ViewBag.idStoreInformation = new SelectList(db.StoreInformations, "idStoreInformation", "otherRetailer");
            return View();
        }

        // POST: InspetionSuperMarket/ImagesStoreInformations/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "imageStoreInformationID,image,idStoreInformation")] ImagesStoreInformation imagesStoreInformation)
        {
            if (ModelState.IsValid)
            {
                db.ImagesStoreInformations.Add(imagesStoreInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idStoreInformation = new SelectList(db.StoreInformations, "idStoreInformation", "otherRetailer", imagesStoreInformation.idStoreInformation);
            return View(imagesStoreInformation);
        }

        // GET: InspetionSuperMarket/ImagesStoreInformations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagesStoreInformation imagesStoreInformation = db.ImagesStoreInformations.Find(id);
            if (imagesStoreInformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.idStoreInformation = new SelectList(db.StoreInformations, "idStoreInformation", "otherRetailer", imagesStoreInformation.idStoreInformation);
            return View(imagesStoreInformation);
        }

        // POST: InspetionSuperMarket/ImagesStoreInformations/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "imageStoreInformationID,image,idStoreInformation")] ImagesStoreInformation imagesStoreInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagesStoreInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idStoreInformation = new SelectList(db.StoreInformations, "idStoreInformation", "otherRetailer", imagesStoreInformation.idStoreInformation);
            return View(imagesStoreInformation);
        }

        // GET: InspetionSuperMarket/ImagesStoreInformations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagesStoreInformation imagesStoreInformation = db.ImagesStoreInformations.Find(id);
            if (imagesStoreInformation == null)
            {
                return HttpNotFound();
            }
            return View(imagesStoreInformation);
        }

        // POST: InspetionSuperMarket/ImagesStoreInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImagesStoreInformation imagesStoreInformation = db.ImagesStoreInformations.Find(id);
            db.ImagesStoreInformations.Remove(imagesStoreInformation);
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
