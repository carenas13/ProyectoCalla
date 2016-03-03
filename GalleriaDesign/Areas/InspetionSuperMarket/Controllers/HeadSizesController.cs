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
    public class HeadSizesController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: HeadSizes
        public ActionResult Index()
        {
            return View(db.HeadSizes.ToList());
        }

        // GET: HeadSizes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeadSize headSize = db.HeadSizes.Find(id);
            if (headSize == null)
            {
                return HttpNotFound();
            }
            return View(headSize);
        }

        // GET: HeadSizes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HeadSizes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idHeadSize,description")] HeadSize headSize)
        {
            if (ModelState.IsValid)
            {
                db.HeadSizes.Add(headSize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(headSize);
        }

        // GET: HeadSizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeadSize headSize = db.HeadSizes.Find(id);
            if (headSize == null)
            {
                return HttpNotFound();
            }
            return View(headSize);
        }

        // POST: HeadSizes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idHeadSize,description")] HeadSize headSize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(headSize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(headSize);
        }

        // GET: HeadSizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeadSize headSize = db.HeadSizes.Find(id);
            if (headSize == null)
            {
                return HttpNotFound();
            }
            return View(headSize);
        }

        // POST: HeadSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HeadSize headSize = db.HeadSizes.Find(id);
            db.HeadSizes.Remove(headSize);
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
