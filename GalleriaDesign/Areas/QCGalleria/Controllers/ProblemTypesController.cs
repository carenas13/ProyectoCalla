using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GalleriaDesign.Models;

namespace GalleriaDesign.Areas.QCGalleria.Controllers
{
    [SessionExpire]
    public class ProblemTypesController : Controller
    {
       // private DesignGalleriaContext db = new DesignGalleriaContext();
        private GalleriaDesignContext db = new GalleriaDesignContext();
        // GET: ProblemTypes
        public ActionResult Index()
        {
            var reportTypes = db.ReportTypes;
            ViewBag.reportTypes = reportTypes.ToList();        
            var ProblemTypeByReports = db.ProblemTypeByReports;          
            ViewBag.ProblemTypeByReports = ProblemTypeByReports.ToList();
            return View(db.ProblemTypes.ToList());
        }

        // GET: ProblemTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemType problemType = db.ProblemTypes.Find(id);
            if (problemType == null)
            {
                return HttpNotFound();
            }
            return View(problemType);
        }

        // GET: ProblemTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProblemTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "typeProblemID,descritpionProblem,isActivo")] ProblemType problemType)
        {
            if (ModelState.IsValid)
            {
                db.ProblemTypes.Add(problemType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(problemType);
        }

        // GET: ProblemTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemType problemType = db.ProblemTypes.Find(id);
            if (problemType == null)
            {
                return HttpNotFound();
            }
            return View(problemType);
        }

        // POST: ProblemTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "typeProblemID,descritpionProblem,isActivo")] ProblemType problemType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(problemType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(problemType);
        }

        // GET: ProblemTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemType problemType = db.ProblemTypes.Find(id);
            if (problemType == null)
            {
                return HttpNotFound();
            }
            return View(problemType);
        }

        // POST: ProblemTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List<ProblemType> problemsType = db.ProblemTypes.Include(pt => pt.problemTypeByReport).Include(pt => pt.problems).Include(pt =>pt.images)
                .Where(pt => pt.typeProblemID == id).ToList();
            ProblemType problemType = problemsType.Find(pt => pt.typeProblemID == id);

            if (problemType.problems.Count() == 0 && problemType.problemTypeByReport.Count() == 0 && problemType.images.Count() == 0){

                db.ProblemTypes.Remove(problemType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.message = "No se puede Eliminar porque existen Elementos asosociados al tipo de problema";
            return View(problemType);
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
