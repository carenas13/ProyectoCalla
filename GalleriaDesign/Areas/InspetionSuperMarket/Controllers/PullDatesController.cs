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
    public class PullDatesController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: PullDates
        public ActionResult Index()
        {
            return View(db.PullDates.ToList());
        }

        // GET: PullDates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PullDates pullDates = db.PullDates.Find(id);
            if (pullDates == null)
            {
                return HttpNotFound();
            }
            return View(pullDates);
        }

        // GET: PullDates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PullDates/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPullDates,description")] PullDates pullDates)
        {
            if (ModelState.IsValid)
            {
                db.PullDates.Add(pullDates);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pullDates);
        }

        // GET: PullDates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PullDates pullDates = db.PullDates.Find(id);
            if (pullDates == null)
            {
                return HttpNotFound();
            }
            return View(pullDates);
        }

        // POST: PullDates/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPullDates,description")] PullDates pullDates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pullDates).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pullDates);
        }

        // GET: PullDates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PullDates pullDates = db.PullDates.Find(id);
            if (pullDates == null)
            {
                return HttpNotFound();
            }
            return View(pullDates);
        }

        // POST: PullDates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PullDates pullDates = db.PullDates.Find(id);
            db.PullDates.Remove(pullDates);
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
