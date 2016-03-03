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
    public class ProblemByReportsController : Controller
    {
      //  private DesignGalleriaContext db = new DesignGalleriaContext();
        private GalleriaDesignContext db = new GalleriaDesignContext();
        // GET: ProblemByReports
        public ActionResult Index()
        {
            var problemByReports = db.ProblemByReports.Include(p => p.problem).Include(p => p.reportType);
            return View(problemByReports.ToList());
        }

        // GET: ProblemByReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemByReport problemByReport = db.ProblemByReports.Find(id);
            if (problemByReport == null)
            {
                return HttpNotFound();
            }
            return View(problemByReport);
        }

        // GET: ProblemByReports/Create
        public ActionResult Create()
        {
            ViewBag.problemID = new SelectList(db.problems, "problemID", "descritpionProblem");
            ViewBag.reportTypeId = new SelectList(db.ReportTypes, "reportTypeId", "nameReportType");
            return View();
        }

        // POST: ProblemByReports/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
     //   [ValidateAntiForgeryToken]
        public ActionResult Create(ProblemByReport problemByReport)
        {
            if (ModelState.IsValid)
            {
                db.ProblemByReports.Add(problemByReport);
                db.SaveChanges();
                // return RedirectToAction("Index");
                return Json(new { success = true ,idProblemReport= problemByReport.problemByReport});
            }

            ViewBag.problemID = new SelectList(db.problems, "problemID", "descritpionProblem", problemByReport.problemID);
            ViewBag.reportTypeId = new SelectList(db.ReportTypes, "reportTypeId", "nameReportType", problemByReport.reportTypeId);
           // return Json(new { success = true });
           return View(problemByReport);
        }

        // GET: ProblemByReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemByReport problemByReport = db.ProblemByReports.Find(id);
            if (problemByReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.problemID = new SelectList(db.problems, "problemID", "descritpionProblem", problemByReport.problemID);
            ViewBag.reportTypeId = new SelectList(db.ReportTypes, "reportTypeId", "nameReportType", problemByReport.reportTypeId);
            return View(problemByReport);
        }

        // POST: ProblemByReports/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "problemByReport,reportTypeId,problemID")] ProblemByReport problemByReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(problemByReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.problemID = new SelectList(db.problems, "problemID", "descritpionProblem", problemByReport.problemID);
            ViewBag.reportTypeId = new SelectList(db.ReportTypes, "reportTypeId", "nameReportType", problemByReport.reportTypeId);
            return View(problemByReport);
        }

        // GET: ProblemByReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemByReport problemByReport = db.ProblemByReports.Find(id);
            if (problemByReport == null)
            {
                return HttpNotFound();
            }
            return View(problemByReport);
        }

        // POST: ProblemByReports/Delete/5
        [HttpPost, ActionName("Delete")]
       // [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProblemByReport problemByReport = db.ProblemByReports.Find(id);
            db.ProblemByReports.Remove(problemByReport);
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
