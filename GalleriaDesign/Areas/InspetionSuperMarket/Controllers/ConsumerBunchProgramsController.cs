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
    public class ConsumerBunchProgramsController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: ConsumerBunchPrograms
        public ActionResult Index()
        {
            var consumerBunchPrograms = db.ConsumerBunchPrograms.Include(c => c.consumerBunchType);
            return View(consumerBunchPrograms.ToList());
        }

        // GET: ConsumerBunchPrograms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsumerBunchProgram consumerBunchProgram = db.ConsumerBunchPrograms.Find(id);
            if (consumerBunchProgram == null)
            {
                return HttpNotFound();
            }
            return View(consumerBunchProgram);
        }

        // GET: ConsumerBunchPrograms/Create
        public ActionResult Create()
        {
            ViewBag.idConsumerBunchType = new SelectList(db.ConsumerBunchTypes, "idConsumerBunchType", "nameConsumer");
            return View();
        }

        // POST: ConsumerBunchPrograms/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idConsumerBunchProgram,descriptionProgram,retail,idConsumerBunchType,otherBunchType,stemCount,innerWrap")] ConsumerBunchProgram consumerBunchProgram)
        {
            if (ModelState.IsValid)
            {
                db.ConsumerBunchPrograms.Add(consumerBunchProgram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idConsumerBunchType = new SelectList(db.ConsumerBunchTypes, "idConsumerBunchType", "nameConsumer", consumerBunchProgram.idConsumerBunchType);
            return View(consumerBunchProgram);
        }

        // GET: ConsumerBunchPrograms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsumerBunchProgram consumerBunchProgram = db.ConsumerBunchPrograms.Find(id);
            if (consumerBunchProgram == null)
            {
                return HttpNotFound();
            }
            ViewBag.idConsumerBunchType = new SelectList(db.ConsumerBunchTypes, "idConsumerBunchType", "nameConsumer", consumerBunchProgram.idConsumerBunchType);
            return View(consumerBunchProgram);
        }

        // POST: ConsumerBunchPrograms/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idConsumerBunchProgram,descriptionProgram,retail,idConsumerBunchType,otherBunchType,stemCount,innerWrap")] ConsumerBunchProgram consumerBunchProgram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consumerBunchProgram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idConsumerBunchType = new SelectList(db.ConsumerBunchTypes, "idConsumerBunchType", "nameConsumer", consumerBunchProgram.idConsumerBunchType);
            return View(consumerBunchProgram);
        }

        // GET: ConsumerBunchPrograms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsumerBunchProgram consumerBunchProgram = db.ConsumerBunchPrograms.Find(id);
            if (consumerBunchProgram == null)
            {
                return HttpNotFound();
            }
            return View(consumerBunchProgram);
        }

        // POST: ConsumerBunchPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConsumerBunchProgram consumerBunchProgram = db.ConsumerBunchPrograms.Find(id);
            db.ConsumerBunchPrograms.Remove(consumerBunchProgram);
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
