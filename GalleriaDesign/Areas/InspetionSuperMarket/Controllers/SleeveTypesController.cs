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
    public class SleeveTypesController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: SleeveTypes
        public ActionResult Index()
        {
            return View(db.SleeveTypes.ToList());
        }

        // GET: SleeveTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SleeveType sleeveType = db.SleeveTypes.Find(id);
            if (sleeveType == null)
            {
                return HttpNotFound();
            }
            return View(sleeveType);
        }

        // GET: SleeveTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SleeveTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSleeveType,nameSleeve")] SleeveType sleeveType)
        {
            if (ModelState.IsValid)
            {
                db.SleeveTypes.Add(sleeveType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sleeveType);
        }

        // GET: SleeveTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SleeveType sleeveType = db.SleeveTypes.Find(id);
            if (sleeveType == null)
            {
                return HttpNotFound();
            }
            return View(sleeveType);
        }

        // POST: SleeveTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSleeveType,nameSleeve")] SleeveType sleeveType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sleeveType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sleeveType);
        }

        // GET: SleeveTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SleeveType sleeveType = db.SleeveTypes.Find(id);
            if (sleeveType == null)
            {
                return HttpNotFound();
            }
            return View(sleeveType);
        }

        // POST: SleeveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SleeveType sleeveType = db.SleeveTypes.Find(id);
            db.SleeveTypes.Remove(sleeveType);
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
