using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApplicationProductionsFarms.Models;
using System.Web.Helpers;
using Newtonsoft.Json;

namespace GalleriaDesign.Areas.ProductionFarms.Controllers
{
    public class DimensionsController : Controller
    {
        private ApplicationProductionsFarmsContext db = new ApplicationProductionsFarmsContext();

        // GET: ProductionFarms/Dimensions
        public ActionResult Index()
        {
            var dimensions = db.Dimensions.Include(d => d.block);

            foreach (var dimen in dimensions.ToList())
            {               
                string dimens1 = string.Concat(dimen.block.numBlocks,dimen.numBed);                

                dimen.codeBeds = dimens1;

            }
            return View(dimensions.ToList());
        }

        // GET: ProductionFarms/Dimensions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dimensions dimensions = db.Dimensions.Find(id);
            if (dimensions == null)
            {
                return HttpNotFound();
            }
            return View(dimensions);
        }

        // GET: ProductionFarms/Dimensions/Create
        public ActionResult Create()
        {
            ViewBag.idFarms = new SelectList(db.Farms, "idFarms", "codeFarms");
            ViewBag.idBlocks = new SelectList(db.Blocks, "idBlocks", "numBlocks");
            return View();
        }

        public JsonResult DropdownCascading(int id)
        {
            IEnumerable<Blocks> bloques = db.Blocks.ToList().Where(b => b.idFarms == id);
            List<Blocks> blqs = bloques.ToList();
            var codigos = new List<object>();
            foreach (var blq in blqs)
            {
                codigos.Add(new { codigoBloque = blq.numBlocks.ToString() });

            }
           
            return Json(codigos, JsonRequestBehavior.AllowGet);
        }


        // POST: ProductionFarms/Dimensions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBed,numBed,codeBeds,length,width,idBlocks")] Dimensions dimensions)
        {
            var bloque = db.Blocks.Find(dimensions.idBlocks).idFarms;

            if (ModelState.IsValid)
            {
                db.Dimensions.Add(dimensions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idBlocks = new SelectList(db.Blocks, "idBlocks", "numBlocks", dimensions.idBlocks);
            return View(dimensions);
        }

        // GET: ProductionFarms/Dimensions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dimensions dimensions = db.Dimensions.Find(id);
            if (dimensions == null)
            {
                return HttpNotFound();
            }
            ViewBag.idBlocks = new SelectList(db.Blocks, "idBlocks", "numBlocks", dimensions.idBlocks);
            return View(dimensions);
        }

        // POST: ProductionFarms/Dimensions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBed,numBed,codeBeds,length,width,idBlocks")] Dimensions dimensions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dimensions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBlocks = new SelectList(db.Blocks, "idBlocks", "numBlocks", dimensions.idBlocks);
            return View(dimensions);
        }

        // GET: ProductionFarms/Dimensions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dimensions dimensions = db.Dimensions.Find(id);
            if (dimensions == null)
            {
                return HttpNotFound();
            }
            return View(dimensions);
        }

        // POST: ProductionFarms/Dimensions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dimensions dimensions = db.Dimensions.Find(id);
            db.Dimensions.Remove(dimensions);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult QRCode()
        {
            ViewBag.idBed = new SelectList(db.Dimensions.OrderByDescending(m => m.idBed), "idBed", "codeBeds");
            //ViewBag.idBed = new SelectList(db.Dimensions, "idBed", "codeBeds");
            //ViewBag.idFarms = new SelectList(db.Farms, "idFarms", "codeFarms");
            //ViewBag.idBlocks = new SelectList(db.Blocks, "idBlocks", "numBlocks");

            return View();
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
