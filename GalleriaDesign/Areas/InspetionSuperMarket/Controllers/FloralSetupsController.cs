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
    public class FloralSetupsController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: FloralSetups
        public ActionResult Index()
        {
            return View(db.FloralSetups.ToList());
        }

        // GET: FloralSetups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FloralSetup floralSetup = db.FloralSetups.Find(id);
            if (floralSetup == null)
            {
                return HttpNotFound();
            }
            return View(floralSetup);
        }

        // GET: FloralSetups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FloralSetups/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFloralSetup,description")] FloralSetup floralSetup)
        {
            if (ModelState.IsValid)
            {
                db.FloralSetups.Add(floralSetup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(floralSetup);
        }

        // GET: FloralSetups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FloralSetup floralSetup = db.FloralSetups.Find(id);
            if (floralSetup == null)
            {
                return HttpNotFound();
            }
            return View(floralSetup);
        }

        // POST: FloralSetups/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFloralSetup,description")] FloralSetup floralSetup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(floralSetup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(floralSetup);
        }

        // GET: FloralSetups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FloralSetup floralSetup = db.FloralSetups.Find(id);
            if (floralSetup == null)
            {
                return HttpNotFound();
            }
            return View(floralSetup);
        }

        // POST: FloralSetups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FloralSetup floralSetup = db.FloralSetups.Find(id);
            db.FloralSetups.Remove(floralSetup);
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
