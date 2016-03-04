using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApplicationProductionsFarms.Models;

namespace GalleriaDesign.Areas.ProductionFarms.Controllers
{
    public class FarmsController : Controller
    {
        private ApplicationProductionsFarmsContext db = new ApplicationProductionsFarmsContext();

        // GET: ProductionFarms/Farms
        public ActionResult Index()
        {
            return View(db.Farms.ToList());
        }

        // GET: ProductionFarms/Farms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farms farms = db.Farms.Find(id);
            if (farms == null)
            {
                return HttpNotFound();
            }
            return View(farms);
        }

        // GET: ProductionFarms/Farms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductionFarms/Farms/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFarms,codeFarms,description")] Farms farms)
        {
            if (ModelState.IsValid)
            {
                db.Farms.Add(farms);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(farms);
        }

        // GET: ProductionFarms/Farms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farms farms = db.Farms.Find(id);
            if (farms == null)
            {
                return HttpNotFound();
            }
            return View(farms);
        }

        // POST: ProductionFarms/Farms/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFarms,codeFarms,description")] Farms farms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(farms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(farms);
        }

        // GET: ProductionFarms/Farms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farms farms = db.Farms.Find(id);
            if (farms == null)
            {
                return HttpNotFound();
            }
            return View(farms);
        }

        // POST: ProductionFarms/Farms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List<Farms> farms = db.Farms.Include(r => r.blocks).ToList();
            Farms farm = farms.Find(r => r.idFarms == id);

            //Find(id).Include(p => p.block);
            if (farm.blocks.Count() == 0)
            {
                db.Farms.Remove(farm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.message = "No se puede Eliminar porque existen Elementos asosociados al tipo de reporte";
            return View(farm);
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
