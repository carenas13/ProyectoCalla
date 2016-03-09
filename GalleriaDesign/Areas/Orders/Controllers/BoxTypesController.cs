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
    public class BoxTypesController : Controller
    {
        private Applicative_OrderContext db = new Applicative_OrderContext();

        // GET: BoxTypes
        public ActionResult Index()
        {
            return View(db.BoxTypes.ToList());
        }

        // GET: BoxTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoxType boxType = db.BoxTypes.Find(id);
            if (boxType == null)
            {
                return HttpNotFound();
            }
            return View(boxType);
        }

        // GET: BoxTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BoxTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "boxTypeID,codeBox,high,length,width,description,numMaxBunch")] BoxType boxType)
        {
            if (ModelState.IsValid)
            {
                db.BoxTypes.Add(boxType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boxType);
        }

        // GET: BoxTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoxType boxType = db.BoxTypes.Find(id);
            if (boxType == null)
            {
                return HttpNotFound();
            }
            return View(boxType);
        }

        // POST: BoxTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "boxTypeID,codeBox,high,length,width,description,numMaxBunch")] BoxType boxType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boxType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boxType);
        }

        // GET: BoxTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoxType boxType = db.BoxTypes.Find(id);
            if (boxType == null)
            {
                return HttpNotFound();
            }
            return View(boxType);
        }

        // POST: BoxTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoxType boxType = db.BoxTypes.Find(id);
            db.BoxTypes.Remove(boxType);
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
