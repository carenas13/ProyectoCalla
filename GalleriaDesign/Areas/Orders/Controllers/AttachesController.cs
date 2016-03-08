using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AplicativoPedido.Models;
using Applicative_Order.Models;

namespace Applicative_Order.Controllers
{
    public class AttachesController : Controller
    {
        private Applicative_OrderContext db = new Applicative_OrderContext();

        // GET: Attaches
        public ActionResult Index()
        {
            var attaches = db.Attaches.Include(a => a.labelUPC);
            return View(attaches.ToList());
        }

        // GET: Attaches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attach attach = db.Attaches.Find(id);
            if (attach == null)
            {
                return HttpNotFound();
            }
            return View(attach);
        }

        // GET: Attaches/Create
        public ActionResult Create()
        {
            ViewBag.labelUPCID = new SelectList(db.LabelUPCs, "labelUPCID", "nameUPC");
            return View();
        }

        // POST: Attaches/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "attachID,labelUPCID")] Attach attach)
        {
            if (ModelState.IsValid)
            {
                db.Attaches.Add(attach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.labelUPCID = new SelectList(db.LabelUPCs, "labelUPCID", "nameUPC", attach.labelUPCID);
            return View(attach);
        }

        // GET: Attaches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attach attach = db.Attaches.Find(id);
            if (attach == null)
            {
                return HttpNotFound();
            }
            ViewBag.labelUPCID = new SelectList(db.LabelUPCs, "labelUPCID", "nameUPC", attach.labelUPCID);
            return View(attach);
        }

        // POST: Attaches/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "attachID,labelUPCID")] Attach attach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.labelUPCID = new SelectList(db.LabelUPCs, "labelUPCID", "nameUPC", attach.labelUPCID);
            return View(attach);
        }

        // GET: Attaches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attach attach = db.Attaches.Find(id);
            if (attach == null)
            {
                return HttpNotFound();
            }
            return View(attach);
        }

        // POST: Attaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attach attach = db.Attaches.Find(id);
            db.Attaches.Remove(attach);
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
