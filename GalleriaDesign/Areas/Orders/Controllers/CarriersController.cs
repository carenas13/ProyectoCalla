using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Applicative_Order.Models;

namespace Applicative_Order.Controllers
{
    public class CarriersController : Controller
    {
        private Applicative_OrderContext db = new Applicative_OrderContext();

        // GET: Carriers
        public ActionResult Index()
        {
            return View(db.Carriers.ToList());
        }

        // GET: Carriers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrier carrier = db.Carriers.Find(id);
            if (carrier == null)
            {
                return HttpNotFound();
            }
            return View(carrier);
        }

        // GET: Carriers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carriers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCarrier,codCarrier,nameCarrier")] Carrier carrier)
        {
            if (ModelState.IsValid)
            {
                db.Carriers.Add(carrier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carrier);
        }

        // GET: Carriers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrier carrier = db.Carriers.Find(id);
            if (carrier == null)
            {
                return HttpNotFound();
            }
            return View(carrier);
        }

        // POST: Carriers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCarrier,codCarrier,nameCarrier")] Carrier carrier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carrier);
        }

        // GET: Carriers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrier carrier = db.Carriers.Find(id);
            if (carrier == null)
            {
                return HttpNotFound();
            }
            return View(carrier);
        }

        // POST: Carriers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carrier carrier = db.Carriers.Find(id);
            db.Carriers.Remove(carrier);
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
