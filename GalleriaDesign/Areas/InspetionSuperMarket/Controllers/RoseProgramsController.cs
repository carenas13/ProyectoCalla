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
    public class RoseProgramsController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: RosePrograms
        public ActionResult Index()
        {
            var rosePrograms = db.RosePrograms.Include(r => r.headSize).Include(r => r.stemLength);
            return View(rosePrograms.ToList());
        }

        // GET: RosePrograms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoseProgram roseProgram = db.RosePrograms.Find(id);
            if (roseProgram == null)
            {
                return HttpNotFound();
            }
            return View(roseProgram);
        }

        // GET: RosePrograms/Create
        public ActionResult Create()
        {
            ViewBag.idHeadSize = new SelectList(db.HeadSizes, "idHeadSize", "description");
            ViewBag.idStemLength = new SelectList(db.StemLengths, "idStemLength", "description");
            return View();
        }

        // POST: RosePrograms/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRoseProgram,programDescription,bunchRetail,stemCount,innerWrap,retailBouquet,totalStem,roseStem,fillerStemCount,otherFiller,greemsStemCount,supplierBouquet,otherGreenType,idStemLength,idHeadSize")] RoseProgram roseProgram)
        {
            if (ModelState.IsValid)
            {
                db.RosePrograms.Add(roseProgram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idHeadSize = new SelectList(db.HeadSizes, "idHeadSize", "description", roseProgram.idHeadSize);
            ViewBag.idStemLength = new SelectList(db.StemLengths, "idStemLength", "description", roseProgram.idStemLength);
            return View(roseProgram);
        }

        // GET: RosePrograms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoseProgram roseProgram = db.RosePrograms.Find(id);
            if (roseProgram == null)
            {
                return HttpNotFound();
            }
            ViewBag.idHeadSize = new SelectList(db.HeadSizes, "idHeadSize", "description", roseProgram.idHeadSize);
            ViewBag.idStemLength = new SelectList(db.StemLengths, "idStemLength", "description", roseProgram.idStemLength);
            return View(roseProgram);
        }

        // POST: RosePrograms/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRoseProgram,programDescription,bunchRetail,stemCount,innerWrap,retailBouquet,totalStem,roseStem,fillerStemCount,otherFiller,greemsStemCount,supplierBouquet,otherGreenType,idStemLength,idHeadSize")] RoseProgram roseProgram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roseProgram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idHeadSize = new SelectList(db.HeadSizes, "idHeadSize", "description", roseProgram.idHeadSize);
            ViewBag.idStemLength = new SelectList(db.StemLengths, "idStemLength", "description", roseProgram.idStemLength);
            return View(roseProgram);
        }

        // GET: RosePrograms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoseProgram roseProgram = db.RosePrograms.Find(id);
            if (roseProgram == null)
            {
                return HttpNotFound();
            }
            return View(roseProgram);
        }

        // POST: RosePrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoseProgram roseProgram = db.RosePrograms.Find(id);
            db.RosePrograms.Remove(roseProgram);
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
