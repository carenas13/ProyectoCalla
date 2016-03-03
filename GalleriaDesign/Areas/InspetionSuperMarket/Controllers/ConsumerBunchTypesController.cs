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
    public class ConsumerBunchTypesController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: ConsumerBunchTypes
        public ActionResult Index()
        {
            return View(db.ConsumerBunchTypes.ToList());
        }

        // GET: ConsumerBunchTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsumerBunchType consumerBunchType = db.ConsumerBunchTypes.Find(id);
            if (consumerBunchType == null)
            {
                return HttpNotFound();
            }
            return View(consumerBunchType);
        }

        // GET: ConsumerBunchTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConsumerBunchTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idConsumerBunchType,nameConsumer")] ConsumerBunchType consumerBunchType)
        {
            if (ModelState.IsValid)
            {
                db.ConsumerBunchTypes.Add(consumerBunchType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(consumerBunchType);
        }

        // GET: ConsumerBunchTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsumerBunchType consumerBunchType = db.ConsumerBunchTypes.Find(id);
            if (consumerBunchType == null)
            {
                return HttpNotFound();
            }
            return View(consumerBunchType);
        }

        // POST: ConsumerBunchTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idConsumerBunchType,nameConsumer")] ConsumerBunchType consumerBunchType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consumerBunchType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consumerBunchType);
        }

        // GET: ConsumerBunchTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsumerBunchType consumerBunchType = db.ConsumerBunchTypes.Find(id);
            if (consumerBunchType == null)
            {
                return HttpNotFound();
            }
            return View(consumerBunchType);
        }

        // POST: ConsumerBunchTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConsumerBunchType consumerBunchType = db.ConsumerBunchTypes.Find(id);
            db.ConsumerBunchTypes.Remove(consumerBunchType);
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
