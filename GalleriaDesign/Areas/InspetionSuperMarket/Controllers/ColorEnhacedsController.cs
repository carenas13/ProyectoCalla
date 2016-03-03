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
    public class ColorEnhacedsController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: ColorEnhaceds
        public ActionResult Index()
        {
            return View(db.ColorEnhaceds.ToList());
        }

        // GET: ColorEnhaceds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorEnhaced colorEnhaced = db.ColorEnhaceds.Find(id);
            if (colorEnhaced == null)
            {
                return HttpNotFound();
            }
            return View(colorEnhaced);
        }

        // GET: ColorEnhaceds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColorEnhaceds/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idColorEnhaced,nameColor")] ColorEnhaced colorEnhaced)
        {
            if (ModelState.IsValid)
            {
                db.ColorEnhaceds.Add(colorEnhaced);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(colorEnhaced);
        }

        // GET: ColorEnhaceds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorEnhaced colorEnhaced = db.ColorEnhaceds.Find(id);
            if (colorEnhaced == null)
            {
                return HttpNotFound();
            }
            return View(colorEnhaced);
        }

        // POST: ColorEnhaceds/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idColorEnhaced,nameColor")] ColorEnhaced colorEnhaced)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colorEnhaced).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colorEnhaced);
        }

        // GET: ColorEnhaceds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorEnhaced colorEnhaced = db.ColorEnhaceds.Find(id);
            if (colorEnhaced == null)
            {
                return HttpNotFound();
            }
            return View(colorEnhaced);
        }

        // POST: ColorEnhaceds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ColorEnhaced colorEnhaced = db.ColorEnhaceds.Find(id);
            db.ColorEnhaceds.Remove(colorEnhaced);
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
