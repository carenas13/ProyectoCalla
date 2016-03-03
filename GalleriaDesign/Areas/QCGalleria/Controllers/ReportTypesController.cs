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
    public class ReportTypesController : Controller
    {
      //  private DesignGalleriaContext db = new DesignGalleriaContext();
        private GalleriaDesignContext db = new GalleriaDesignContext();

        // GET: ReportTypes
        public ActionResult Index()
        {
            return View(db.ReportTypes.ToList());
        }

        // GET: ReportTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportType reportType = db.ReportTypes.Find(id);
            if (reportType == null)
            {
                return HttpNotFound();
            }
            return View(reportType);
        }

        // GET: ReportTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReportTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "reportTypeId,nameReportType,descripcionType")] ReportType reportType)
        {
            if (ModelState.IsValid)
            {
                db.ReportTypes.Add(reportType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reportType);
        }

        // GET: ReportTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportType reportType = db.ReportTypes.Find(id);
            if (reportType == null)
            {
                return HttpNotFound();
            }
            return View(reportType);
        }

        // POST: ReportTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "reportTypeId,nameReportType,descripcionType")] ReportType reportType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reportType);
        }

        // GET: ReportTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportType reportType = db.ReportTypes.Find(id);
            if (reportType == null)
            {
                return HttpNotFound();
            }
            return View(reportType);
        }

        // POST: ReportTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // var qualityReport = db.QualityReports.Include(i => i.qualityInspection).Where(r => r.reportTypeId == typeReport).ToList();


          //  var qualityReports = db.QualityReports.Where(r => r.reportTypeId == id).ToList();
            List<ReportType> reportTypes = db.ReportTypes.Include(r =>r.qualityReport).Include(r => r.problemByReport)
                .Include(r =>r.problemTypeByReport).Where(r => r.reportTypeId == id).ToList();
            ReportType reportType = reportTypes.Find(r=>r.reportTypeId==id);

                //Find(id).Include(p => p.block);
            if (reportType.qualityReport.Count()==0 && reportType.problemByReport.Count()==0 && reportType.problemTypeByReport.Count()==0)
            {
                db.ReportTypes.Remove(reportType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.message ="No se puede Eliminar porque existen Elementos asosociados al tipo de reporte";
            return View(reportType);
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
