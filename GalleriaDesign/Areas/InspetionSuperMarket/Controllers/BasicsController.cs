using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GalleriaDesign.Areas.InspetionSuperMarket.Models
{
    public class BasicsController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: Basics
        public ActionResult Index()
        {
            return View(db.Basics.ToList());
        }

        // GET: Basics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basics basics = db.Basics.Find(id);
            if (basics == null)
            {
                return HttpNotFound();
            }
            return View(basics);
        }

        // GET: Basics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Basics/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBasics,name")] Basics basics)
        {
            if (ModelState.IsValid)
            {
                db.Basics.Add(basics);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(basics);
        }

        // GET: Basics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basics basics = db.Basics.Find(id);
            if (basics == null)
            {
                return HttpNotFound();
            }
            return View(basics);
        }

        // POST: Basics/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBasics,name")] Basics basics)
        {
            if (ModelState.IsValid)
            {
                db.Entry(basics).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(basics);
        }

        // GET: Basics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Basics basics = db.Basics.Find(id);
            if (basics == null)
            {
                return HttpNotFound();
            }
            return View(basics);
        }

        // POST: Basics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Basics basics = db.Basics.Find(id);
            db.Basics.Remove(basics);
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
