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
    public class FillerTypesController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: FillerTypes
        public ActionResult Index()
        {
            return View(db.FillerTypes.ToList());
        }

        // GET: FillerTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FillerType fillerType = db.FillerTypes.Find(id);
            if (fillerType == null)
            {
                return HttpNotFound();
            }
            return View(fillerType);
        }

        // GET: FillerTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FillerTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFillerType,nameFiller")] FillerType fillerType)
        {
            if (ModelState.IsValid)
            {
                db.FillerTypes.Add(fillerType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fillerType);
        }

        // GET: FillerTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FillerType fillerType = db.FillerTypes.Find(id);
            if (fillerType == null)
            {
                return HttpNotFound();
            }
            return View(fillerType);
        }

        // POST: FillerTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFillerType,nameFiller")] FillerType fillerType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fillerType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fillerType);
        }

        // GET: FillerTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FillerType fillerType = db.FillerTypes.Find(id);
            if (fillerType == null)
            {
                return HttpNotFound();
            }
            return View(fillerType);
        }

        // POST: FillerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FillerType fillerType = db.FillerTypes.Find(id);
            db.FillerTypes.Remove(fillerType);
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
