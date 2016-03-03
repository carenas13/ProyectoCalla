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
    public class BouquetProgramsController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: BouquetPrograms
        public ActionResult Index()
        {
            return View(db.BouquetPrograms.ToList());
        }

        // GET: BouquetPrograms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BouquetProgram bouquetProgram = db.BouquetPrograms.Find(id);
            if (bouquetProgram == null)
            {
                return HttpNotFound();
            }
            return View(bouquetProgram);
        }

        // GET: BouquetPrograms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BouquetPrograms/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBouquetProgram,descriptionProgramBP,retailBP,nameBP,totalstemCountBP,focalCountBP,otherFocals,colorEnhacedFocal,basicStemCount,otherBasic,colorenhacedBasic,fillerStemCount,otherFillerBP,colorEnhacedFiller,greensStemCount,otherGreenType,colorEnhacedGreen,pick,supplierBP,sleeveBP,innerWrapBP")] BouquetProgram bouquetProgram)
        {
            if (ModelState.IsValid)
            {
                db.BouquetPrograms.Add(bouquetProgram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bouquetProgram);
        }

        // GET: BouquetPrograms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BouquetProgram bouquetProgram = db.BouquetPrograms.Find(id);
            if (bouquetProgram == null)
            {
                return HttpNotFound();
            }
            return View(bouquetProgram);
        }

        // POST: BouquetPrograms/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBouquetProgram,descriptionProgramBP,retailBP,nameBP,totalstemCountBP,focalCountBP,otherFocals,colorEnhacedFocal,basicStemCount,otherBasic,colorenhacedBasic,fillerStemCount,otherFillerBP,colorEnhacedFiller,greensStemCount,otherGreenType,colorEnhacedGreen,pick,supplierBP,sleeveBP,innerWrapBP")] BouquetProgram bouquetProgram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bouquetProgram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bouquetProgram);
        }

        // GET: BouquetPrograms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BouquetProgram bouquetProgram = db.BouquetPrograms.Find(id);
            if (bouquetProgram == null)
            {
                return HttpNotFound();
            }
            return View(bouquetProgram);
        }

        // POST: BouquetPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BouquetProgram bouquetProgram = db.BouquetPrograms.Find(id);
            db.BouquetPrograms.Remove(bouquetProgram);
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
