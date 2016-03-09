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
    public class OrderTypesController : Controller
    {
        private Applicative_OrderContext db = new Applicative_OrderContext();

        // GET: OrderTypes
        public ActionResult Index()
        {
            return View(db.OrderTypes.ToList());
        }

        // GET: OrderTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderType orderType = db.OrderTypes.Find(id);
            if (orderType == null)
            {
                return HttpNotFound();
            }
            return View(orderType);
        }

        // GET: OrderTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderTypeID,name,description")] OrderType orderType)
        {
            if (ModelState.IsValid)
            {
                db.OrderTypes.Add(orderType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderType);
        }

        // GET: OrderTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderType orderType = db.OrderTypes.Find(id);
            if (orderType == null)
            {
                return HttpNotFound();
            }
            return View(orderType);
        }

        // POST: OrderTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderTypeID,name,description")] OrderType orderType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderType);
        }

        // GET: OrderTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderType orderType = db.OrderTypes.Find(id);
            if (orderType == null)
            {
                return HttpNotFound();
            }
            return View(orderType);
        }

        // POST: OrderTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderType orderType = db.OrderTypes.Find(id);
            db.OrderTypes.Remove(orderType);
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
