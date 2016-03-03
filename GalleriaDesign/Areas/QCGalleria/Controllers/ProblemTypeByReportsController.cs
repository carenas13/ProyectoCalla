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
    public class ProblemTypeByReportsController : Controller
    {
       // private DesignGalleriaContext db = new DesignGalleriaContext();
        private GalleriaDesignContext db = new GalleriaDesignContext();
        // GET: ProblemTypeByReports
        public ActionResult Index()
        {
            var problemTypeByReports = db.ProblemTypeByReports.Include(p => p.problemType).Include(p => p.reportType);
            return View(problemTypeByReports.ToList());
        }

        // GET: ProblemTypeByReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemTypeByReport problemTypeByReport = db.ProblemTypeByReports.Find(id);
            if (problemTypeByReport == null)
            {
                return HttpNotFound();
            }
            return View(problemTypeByReport);
        }

        // GET: ProblemTypeByReports/Create
        public ActionResult Create()
        {
            ViewBag.typeProblemID = new SelectList(db.ProblemTypes, "typeProblemID", "descritpionProblem");
            ViewBag.reportTypeId = new SelectList(db.ReportTypes, "reportTypeId", "nameReportType");
            return View();
        }

        // POST: ProblemTypeByReports/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
     //   [ValidateAntiForgeryToken]
        public ActionResult Create( ProblemTypeByReport problemTypeByReport)
        {
            if (ModelState.IsValid)
            {
                db.ProblemTypeByReports.Add(problemTypeByReport);
                db.SaveChanges();
               // return RedirectToAction("Index");

                return Json(new { success = true, idProblemReport = problemTypeByReport.problemTypeByReportID });
            }

            ViewBag.typeProblemID = new SelectList(db.ProblemTypes, "typeProblemID", "descritpionProblem", problemTypeByReport.typeProblemID);
            ViewBag.reportTypeId = new SelectList(db.ReportTypes, "reportTypeId", "nameReportType", problemTypeByReport.reportTypeId);
            return View(problemTypeByReport);
        }

        // GET: ProblemTypeByReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemTypeByReport problemTypeByReport = db.ProblemTypeByReports.Find(id);
            if (problemTypeByReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.typeProblemID = new SelectList(db.ProblemTypes, "typeProblemID", "descritpionProblem", problemTypeByReport.typeProblemID);
            ViewBag.reportTypeId = new SelectList(db.ReportTypes, "reportTypeId", "nameReportType", problemTypeByReport.reportTypeId);
            return View(problemTypeByReport);
        }

        // POST: ProblemTypeByReports/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "problemTypeByReportID,reportTypeId,typeProblemID")] ProblemTypeByReport problemTypeByReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(problemTypeByReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.typeProblemID = new SelectList(db.ProblemTypes, "typeProblemID", "descritpionProblem", problemTypeByReport.typeProblemID);
            ViewBag.reportTypeId = new SelectList(db.ReportTypes, "reportTypeId", "nameReportType", problemTypeByReport.reportTypeId);
            return View(problemTypeByReport);
        }

        // GET: ProblemTypeByReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemTypeByReport problemTypeByReport = db.ProblemTypeByReports.Find(id);
            if (problemTypeByReport == null)
            {
                return HttpNotFound();
            }
            return View(problemTypeByReport);
        }

        // POST: ProblemTypeByReports/Delete/5
        [HttpPost, ActionName("Delete")]
       // [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProblemTypeByReport problemTypeByReport = db.ProblemTypeByReports.Find(id);
            db.ProblemTypeByReports.Remove(problemTypeByReport);
            db.SaveChanges();
            return Json(new { success = true });
            //return RedirectToAction("Index");
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
