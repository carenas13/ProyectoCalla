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
    public class ProtocolsController : Controller
    {
        private Applicative_OrderContext db = new Applicative_OrderContext();

        // GET: Protocols
        public ActionResult Index()
        {
            var protocols = db.Protocols.Include(p => p.bunchSpecification).Include(p => p.packingSpecifications).Include(p => p.recipe);
            return View(protocols.ToList());
        }

        // GET: Protocols/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protocol protocol = db.Protocols.Find(id);
            if (protocol == null)
            {
                return HttpNotFound();
            }
            return View(protocol);
        }

        // GET: Protocols/Create
        public ActionResult Create()
        {
            ViewBag.bunchSpecificationID = new SelectList(db.BunchSpecifications, "bunchSpecificationID", "length");
            ViewBag.packSpecID = new SelectList(db.PackingSpecifications, "packSpecID", "slizeSleeve");
            ViewBag.recipeID = new SelectList(db.Recipes, "recipeID", "nameRecipe");
            return View();
        }

        // POST: Protocols/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "protocolID,recipeID,packSpecID,bunchSpecificationID")] Protocol protocol)
        {
            if (ModelState.IsValid)
            {
                db.Protocols.Add(protocol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bunchSpecificationID = new SelectList(db.BunchSpecifications, "bunchSpecificationID", "length", protocol.bunchSpecificationID);
            ViewBag.packSpecID = new SelectList(db.PackingSpecifications, "packSpecID", "slizeSleeve", protocol.packSpecID);
            ViewBag.recipeID = new SelectList(db.Recipes, "recipeID", "nameRecipe", protocol.recipeID);
            return View(protocol);
        }

        // GET: Protocols/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protocol protocol = db.Protocols.Find(id);
            if (protocol == null)
            {
                return HttpNotFound();
            }
            ViewBag.bunchSpecificationID = new SelectList(db.BunchSpecifications, "bunchSpecificationID", "length", protocol.bunchSpecificationID);
            ViewBag.packSpecID = new SelectList(db.PackingSpecifications, "packSpecID", "slizeSleeve", protocol.packSpecID);
            ViewBag.recipeID = new SelectList(db.Recipes, "recipeID", "nameRecipe", protocol.recipeID);
            return View(protocol);
        }

        // POST: Protocols/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "protocolID,recipeID,packSpecID,bunchSpecificationID")] Protocol protocol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(protocol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bunchSpecificationID = new SelectList(db.BunchSpecifications, "bunchSpecificationID", "length", protocol.bunchSpecificationID);
            ViewBag.packSpecID = new SelectList(db.PackingSpecifications, "packSpecID", "slizeSleeve", protocol.packSpecID);
            ViewBag.recipeID = new SelectList(db.Recipes, "recipeID", "nameRecipe", protocol.recipeID);
            return View(protocol);
        }

        // GET: Protocols/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protocol protocol = db.Protocols.Find(id);
            if (protocol == null)
            {
                return HttpNotFound();
            }
            return View(protocol);
        }

        // POST: Protocols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Protocol protocol = db.Protocols.Find(id);
            db.Protocols.Remove(protocol);
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
