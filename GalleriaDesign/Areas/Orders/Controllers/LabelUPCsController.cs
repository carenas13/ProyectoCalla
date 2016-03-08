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
    public class LabelUPCsController : Controller
    {
        private Applicative_OrderContext db = new Applicative_OrderContext();

        // GET: LabelUPCs
        public ActionResult Index()
        {
            return View(db.LabelUPCs.ToList());
        }

        // GET: LabelUPCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabelUPC labelUPC = db.LabelUPCs.Find(id);
            if (labelUPC == null)
            {
                return HttpNotFound();
            }
            return View(labelUPC);
        }

        // GET: LabelUPCs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LabelUPCs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "labelUPCID,nameUPC,barcodeNumber,date,productCountry")] LabelUPC labelUPC)
        {
            if (ModelState.IsValid)
            {
                db.LabelUPCs.Add(labelUPC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(labelUPC);
        }

        // GET: LabelUPCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabelUPC labelUPC = db.LabelUPCs.Find(id);
            if (labelUPC == null)
            {
                return HttpNotFound();
            }
            return View(labelUPC);
        }

        // POST: LabelUPCs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "labelUPCID,nameUPC,barcodeNumber,date,productCountry")] LabelUPC labelUPC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(labelUPC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(labelUPC);
        }

        // GET: LabelUPCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabelUPC labelUPC = db.LabelUPCs.Find(id);
            if (labelUPC == null)
            {
                return HttpNotFound();
            }
            return View(labelUPC);
        }

        // POST: LabelUPCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LabelUPC labelUPC = db.LabelUPCs.Find(id);
            db.LabelUPCs.Remove(labelUPC);
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
