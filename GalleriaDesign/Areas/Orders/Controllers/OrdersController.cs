using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Applicative_Order.Models;

namespace GalleriaDesign.Areas.Orders.Controllers { 
    public class OrdersController : Controller
    {
        private Applicative_OrderContext db = new Applicative_OrderContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.customer).Include(o => o.orderType).Include(o => o.productGalleria);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {

            ViewBag.customerID = new SelectList(db.Customers, "customerID", "company");
            ViewBag.orderTypeID = new SelectList(db.OrderTypes, "orderTypeID", "name");
            ViewBag.productGalleriaID = new SelectList(db.ProductGallerias, "productGalleriaID", "code");
            ViewBag.idCarrier = new SelectList(db.Carriers, "idCarrier", "nameCarrier");

            return View();
        }

        // POST: Orders/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderID,numberOrder,idCarrier,numberStems,typeDescription,measures,BoxType,BoxNumer,AWB,protocol,prize,total,ShipDateMiami,orderTypeID,customerID,productGalleriaID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customerID = new SelectList(db.Customers, "customerID", "nitCustomer", order.customerID);
            ViewBag.orderTypeID = new SelectList(db.OrderTypes, "orderTypeID", "name", order.orderTypeID);
            ViewBag.productGalleriaID = new SelectList(db.ProductGallerias, "productGalleriaID", "code", order.productGalleriaID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.customerID = new SelectList(db.Customers, "customerID", "nitCustomer", order.customerID);
            ViewBag.orderTypeID = new SelectList(db.OrderTypes, "orderTypeID", "name", order.orderTypeID);
            ViewBag.productGalleriaID = new SelectList(db.ProductGallerias, "productGalleriaID", "code", order.productGalleriaID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderID,numberOrder,idCarrier,numberStems,typeDescription,measures,BoxType,BoxNumer,AWB,protocol,prize,total,ShipDateMiami,orderTypeID,customerID,productGalleriaID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customerID = new SelectList(db.Customers, "customerID", "nitCustomer", order.customerID);
            ViewBag.orderTypeID = new SelectList(db.OrderTypes, "orderTypeID", "name", order.orderTypeID);
            ViewBag.productGalleriaID = new SelectList(db.ProductGallerias, "productGalleriaID", "code", order.productGalleriaID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
