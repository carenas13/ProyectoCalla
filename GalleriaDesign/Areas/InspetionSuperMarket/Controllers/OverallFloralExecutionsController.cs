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
    public class OverallFloralExecutionsController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: OverallFloralExecutions
        public ActionResult Index()
        {
            return View(db.OverallFloralExecutions.ToList());
        }

        // GET: OverallFloralExecutions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OverallFloralExecution overallFloralExecution = db.OverallFloralExecutions.Find(id);
            if (overallFloralExecution == null)
            {
                return HttpNotFound();
            }
            return View(overallFloralExecution);
        }

        // GET: OverallFloralExecutions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OverallFloralExecutions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idOverallFloral,nameOverall")] OverallFloralExecution overallFloralExecution)
        {
            if (ModelState.IsValid)
            {
                db.OverallFloralExecutions.Add(overallFloralExecution);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(overallFloralExecution);
        }

        // GET: OverallFloralExecutions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OverallFloralExecution overallFloralExecution = db.OverallFloralExecutions.Find(id);
            if (overallFloralExecution == null)
            {
                return HttpNotFound();
            }
            return View(overallFloralExecution);
        }

        // POST: OverallFloralExecutions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idOverallFloral,nameOverall")] OverallFloralExecution overallFloralExecution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(overallFloralExecution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(overallFloralExecution);
        }

        // GET: OverallFloralExecutions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OverallFloralExecution overallFloralExecution = db.OverallFloralExecutions.Find(id);
            if (overallFloralExecution == null)
            {
                return HttpNotFound();
            }
            return View(overallFloralExecution);
        }

        // POST: OverallFloralExecutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OverallFloralExecution overallFloralExecution = db.OverallFloralExecutions.Find(id);
            db.OverallFloralExecutions.Remove(overallFloralExecution);
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
