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
    public class FocalsController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: Focals
        public ActionResult Index()
        {
            return View(db.Focals.ToList());
        }

        // GET: Focals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Focals focals = db.Focals.Find(id);
            if (focals == null)
            {
                return HttpNotFound();
            }
            return View(focals);
        }

        // GET: Focals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Focals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFocals,nameFocal")] Focals focals)
        {
            if (ModelState.IsValid)
            {
                db.Focals.Add(focals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(focals);
        }

        // GET: Focals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Focals focals = db.Focals.Find(id);
            if (focals == null)
            {
                return HttpNotFound();
            }
            return View(focals);
        }

        // POST: Focals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFocals,nameFocal")] Focals focals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(focals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(focals);
        }

        // GET: Focals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Focals focals = db.Focals.Find(id);
            if (focals == null)
            {
                return HttpNotFound();
            }
            return View(focals);
        }

        // POST: Focals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Focals focals = db.Focals.Find(id);
            db.Focals.Remove(focals);
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
