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
    public class GreenTypesController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: GreenTypes
        public ActionResult Index()
        {
            return View(db.GreenTypes.ToList());
        }

        // GET: GreenTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GreenType greenType = db.GreenTypes.Find(id);
            if (greenType == null)
            {
                return HttpNotFound();
            }
            return View(greenType);
        }

        // GET: GreenTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GreenTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idGreenType,description")] GreenType greenType)
        {
            if (ModelState.IsValid)
            {
                db.GreenTypes.Add(greenType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(greenType);
        }

        // GET: GreenTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GreenType greenType = db.GreenTypes.Find(id);
            if (greenType == null)
            {
                return HttpNotFound();
            }
            return View(greenType);
        }

        // POST: GreenTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idGreenType,description")] GreenType greenType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(greenType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(greenType);
        }

        // GET: GreenTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GreenType greenType = db.GreenTypes.Find(id);
            if (greenType == null)
            {
                return HttpNotFound();
            }
            return View(greenType);
        }

        // POST: GreenTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GreenType greenType = db.GreenTypes.Find(id);
            db.GreenTypes.Remove(greenType);
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
