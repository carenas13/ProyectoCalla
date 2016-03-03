using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GalleriaDesign.Areas.InspetionSuperMarket.Models;
using Supermarket.Models;

namespace GalleriaDesign.Areas.InspetionSuperMarket.Controllers
{
    public class ImagesBunchProgramsController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: InspetionSuperMarket/ImagesBunchPrograms
        public ActionResult Index()
        {
            var imagesBunchPrograms = db.ImagesBunchPrograms.Include(i => i.consumerBunchProgram);
            return View(imagesBunchPrograms.ToList());
        }

        // GET: InspetionSuperMarket/ImagesBunchPrograms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagesBunchProgram imagesBunchProgram = db.ImagesBunchPrograms.Find(id);
            if (imagesBunchProgram == null)
            {
                return HttpNotFound();
            }
            return View(imagesBunchProgram);
        }

        // GET: InspetionSuperMarket/ImagesBunchPrograms/Create
        public ActionResult Create()
        {
            ViewBag.idConsumerBunchProgram = new SelectList(db.ConsumerBunchPrograms, "idConsumerBunchProgram", "descriptionProgram");
            return View();
        }

        // POST: InspetionSuperMarket/ImagesBunchPrograms/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "imageBunchProgramID,image,idConsumerBunchProgram")] ImagesBunchProgram imagesBunchProgram)
        {
            if (ModelState.IsValid)
            {
                db.ImagesBunchPrograms.Add(imagesBunchProgram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idConsumerBunchProgram = new SelectList(db.ConsumerBunchPrograms, "idConsumerBunchProgram", "descriptionProgram", imagesBunchProgram.idConsumerBunchProgram);
            return View(imagesBunchProgram);
        }

        // GET: InspetionSuperMarket/ImagesBunchPrograms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagesBunchProgram imagesBunchProgram = db.ImagesBunchPrograms.Find(id);
            if (imagesBunchProgram == null)
            {
                return HttpNotFound();
            }
            ViewBag.idConsumerBunchProgram = new SelectList(db.ConsumerBunchPrograms, "idConsumerBunchProgram", "descriptionProgram", imagesBunchProgram.idConsumerBunchProgram);
            return View(imagesBunchProgram);
        }

        // POST: InspetionSuperMarket/ImagesBunchPrograms/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "imageBunchProgramID,image,idConsumerBunchProgram")] ImagesBunchProgram imagesBunchProgram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagesBunchProgram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idConsumerBunchProgram = new SelectList(db.ConsumerBunchPrograms, "idConsumerBunchProgram", "descriptionProgram", imagesBunchProgram.idConsumerBunchProgram);
            return View(imagesBunchProgram);
        }

        // GET: InspetionSuperMarket/ImagesBunchPrograms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagesBunchProgram imagesBunchProgram = db.ImagesBunchPrograms.Find(id);
            if (imagesBunchProgram == null)
            {
                return HttpNotFound();
            }
            return View(imagesBunchProgram);
        }

        // POST: InspetionSuperMarket/ImagesBunchPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImagesBunchProgram imagesBunchProgram = db.ImagesBunchPrograms.Find(id);
            db.ImagesBunchPrograms.Remove(imagesBunchProgram);
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
