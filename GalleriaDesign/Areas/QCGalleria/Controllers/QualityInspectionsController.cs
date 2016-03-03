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
    public class QualityInspectionsController : Controller
    {
       // private DesignGalleriaContext db = new DesignGalleriaContext();
        private GalleriaDesignContext db = new GalleriaDesignContext();
        // GET: QualityInspections
        public ActionResult Index()
        {
            var qualityInspections = db.QualityInspections.Include(q => q.problem).Include(q => q.qualityReport);
            return View(qualityInspections.ToList());
        }

        // GET: QualityInspections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QualityInspection qualityInspection = db.QualityInspections.Find(id);
           
            if (qualityInspection == null)
            {
                return HttpNotFound();
            }
            return View(qualityInspection);
        }

        // GET: QualityInspections/Create
        public ActionResult Create()
        {
            ViewBag.problemID = new SelectList(db.problems, "problemID", "descritpionProblem");
            ViewBag.qualityReportID = new SelectList(db.QualityReports, "qualityReportID", "farmReport");
            return View();
        }

        // POST: QualityInspections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "qualityInspectiontID,qualityReportID,problemID,answerInspection")] QualityInspection qualityInspection)
        {
            if (ModelState.IsValid)
            {
                db.QualityInspections.Add(qualityInspection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.problemID = new SelectList(db.problems, "problemID", "descritpionProblem", qualityInspection.problemID);
            ViewBag.qualityReportID = new SelectList(db.QualityReports, "qualityReportID", "farmReport", qualityInspection.qualityReportID);
            return View(qualityInspection);
        }

        // GET: QualityInspections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QualityInspection qualityInspection = db.QualityInspections.Find(id);
            if (qualityInspection == null)
            {
                return HttpNotFound();
            }
            ViewBag.problemID = new SelectList(db.problems, "problemID", "descritpionProblem", qualityInspection.problemID);
            ViewBag.qualityReportID = new SelectList(db.QualityReports, "qualityReportID", "farmReport", qualityInspection.qualityReportID);
            return View(qualityInspection);
        }

        // POST: QualityInspections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "qualityInspectiontID,qualityReportID,problemID,answerInspection")] QualityInspection qualityInspection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qualityInspection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.problemID = new SelectList(db.problems, "problemID", "descritpionProblem", qualityInspection.problemID);
            ViewBag.qualityReportID = new SelectList(db.QualityReports, "qualityReportID", "farmReport", qualityInspection.qualityReportID);
            return View(qualityInspection);
        }

        // GET: QualityInspections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QualityInspection qualityInspection = db.QualityInspections.Find(id);
            if (qualityInspection == null)
            {
                return HttpNotFound();
            }
            return View(qualityInspection);
        }

        // POST: QualityInspections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QualityInspection qualityInspection = db.QualityInspections.Find(id);
            db.QualityInspections.Remove(qualityInspection);
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
