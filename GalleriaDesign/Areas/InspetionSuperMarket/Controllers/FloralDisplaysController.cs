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
    public class FloralDisplaysController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: FloralDisplays
        public ActionResult Index()
        {
            return View(db.FloralDisplays.ToList());
        }

        // GET: FloralDisplays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FloralDisplay floralDisplay = db.FloralDisplays.Find(id);
            if (floralDisplay == null)
            {
                return HttpNotFound();
            }
            return View(floralDisplay);
        }

        // GET: FloralDisplays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FloralDisplays/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFloralDisplay,description")] FloralDisplay floralDisplay)
        {
            if (ModelState.IsValid)
            {
                db.FloralDisplays.Add(floralDisplay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(floralDisplay);
        }

        // GET: FloralDisplays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FloralDisplay floralDisplay = db.FloralDisplays.Find(id);
            if (floralDisplay == null)
            {
                return HttpNotFound();
            }
            return View(floralDisplay);
        }

        // POST: FloralDisplays/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFloralDisplay,description")] FloralDisplay floralDisplay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(floralDisplay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(floralDisplay);
        }

        // GET: FloralDisplays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FloralDisplay floralDisplay = db.FloralDisplays.Find(id);
            if (floralDisplay == null)
            {
                return HttpNotFound();
            }
            return View(floralDisplay);
        }

        // POST: FloralDisplays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FloralDisplay floralDisplay = db.FloralDisplays.Find(id);
            db.FloralDisplays.Remove(floralDisplay);
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
