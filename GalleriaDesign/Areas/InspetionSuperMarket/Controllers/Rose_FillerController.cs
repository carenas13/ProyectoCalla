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
    public class Rose_FillerController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: Rose_Filler
        public ActionResult Index()
        {
            return View(db.Rose_Filler.ToList());
        }

        // GET: Rose_Filler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rose_Filler rose_Filler = db.Rose_Filler.Find(id);
            if (rose_Filler == null)
            {
                return HttpNotFound();
            }
            return View(rose_Filler);
        }

        // GET: Rose_Filler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rose_Filler/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRoseFiller,idRoseProgram,idFillerType,checkFiller")] Rose_Filler rose_Filler)
        {
            if (ModelState.IsValid)
            {
                db.Rose_Filler.Add(rose_Filler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rose_Filler);
        }

        // GET: Rose_Filler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rose_Filler rose_Filler = db.Rose_Filler.Find(id);
            if (rose_Filler == null)
            {
                return HttpNotFound();
            }
            return View(rose_Filler);
        }

        // POST: Rose_Filler/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRoseFiller,idRoseProgram,idFillerType,checkFiller")] Rose_Filler rose_Filler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rose_Filler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rose_Filler);
        }

        // GET: Rose_Filler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rose_Filler rose_Filler = db.Rose_Filler.Find(id);
            if (rose_Filler == null)
            {
                return HttpNotFound();
            }
            return View(rose_Filler);
        }

        // POST: Rose_Filler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rose_Filler rose_Filler = db.Rose_Filler.Find(id);
            db.Rose_Filler.Remove(rose_Filler);
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
