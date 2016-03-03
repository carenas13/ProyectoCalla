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
    public class StemLengthsController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: StemLengths
        public ActionResult Index()
        {
            return View(db.StemLengths.ToList());
        }

        // GET: StemLengths/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StemLength stemLength = db.StemLengths.Find(id);
            if (stemLength == null)
            {
                return HttpNotFound();
            }
            return View(stemLength);
        }

        // GET: StemLengths/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StemLengths/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idStemLength,description")] StemLength stemLength)
        {
            if (ModelState.IsValid)
            {
                db.StemLengths.Add(stemLength);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stemLength);
        }

        // GET: StemLengths/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StemLength stemLength = db.StemLengths.Find(id);
            if (stemLength == null)
            {
                return HttpNotFound();
            }
            return View(stemLength);
        }

        // POST: StemLengths/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idStemLength,description")] StemLength stemLength)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stemLength).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stemLength);
        }

        // GET: StemLengths/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StemLength stemLength = db.StemLengths.Find(id);
            if (stemLength == null)
            {
                return HttpNotFound();
            }
            return View(stemLength);
        }

        // POST: StemLengths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StemLength stemLength = db.StemLengths.Find(id);
            db.StemLengths.Remove(stemLength);
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
