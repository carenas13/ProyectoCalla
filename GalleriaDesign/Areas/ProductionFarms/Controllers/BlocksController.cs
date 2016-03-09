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
    public class BlocksController : Controller
    {
        private ApplicationProductionsFarmsContext db = new ApplicationProductionsFarmsContext();

        // GET: ProductionFarms/Blocks
        public ActionResult Index()
        {
            var blocks = db.Blocks.Include(b => b.Farms);
            return View(blocks.ToList());
        }

        // GET: ProductionFarms/Blocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blocks blocks = db.Blocks.Find(id);
            if (blocks == null)
            {
                return HttpNotFound();
            }
            return View(blocks);
        }

        // GET: ProductionFarms/Blocks/Create
        public ActionResult Create()
        {
            ViewBag.idFarms = new SelectList(db.Farms, "idFarms", "codeFarms");
            return View();
        }

        // POST: ProductionFarms/Blocks/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBlocks,numBlocks,numBeds,idFarms")] Blocks blocks)
        {
            if (ModelState.IsValid)
            {
                db.Blocks.Add(blocks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFarms = new SelectList(db.Farms, "idFarms", "codeFarms", blocks.idFarms);
            return View(blocks);
        }

        // GET: ProductionFarms/Blocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blocks blocks = db.Blocks.Find(id);
            if (blocks == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFarms = new SelectList(db.Farms, "idFarms", "codeFarms", blocks.idFarms);
            return View(blocks);
        }

        // POST: ProductionFarms/Blocks/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBlocks,numBlocks,numBeds,idFarms")] Blocks blocks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blocks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFarms = new SelectList(db.Farms, "idFarms", "codeFarms", blocks.idFarms);
            return View(blocks);
        }

        // GET: ProductionFarms/Blocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blocks blocks = db.Blocks.Find(id);
            if (blocks == null)
            {
                return HttpNotFound();
            }
            return View(blocks);
        }

        // POST: ProductionFarms/Blocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List<Blocks> blocks = db.Blocks.Include(r => r.dimensions).ToList();
            Blocks block = blocks.Find(r => r.idBlocks == id);

            //Find(id).Include(p => p.block);
            if (block.dimensions.Count() == 0)
            {
                db.Blocks.Remove(block);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.message = "No se puede Eliminar porque existen Elementos asosociados al tipo de reporte";
            return View(block);
           
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
