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
    public class problemsController : Controller
    {
       // private DesignGalleriaContext db = new DesignGalleriaContext();
        private GalleriaDesignContext db = new GalleriaDesignContext();
        // GET: problems
        public ActionResult Index()
        {
            var reportTypes = db.ReportTypes;
            var problemByReports = db.ProblemByReports;
            ViewBag.reportTypes = reportTypes.ToList();
            ViewBag.ProblemByReports = problemByReports.ToList();
            return View(db.problems.ToList());
        }

        // GET: problems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            problem problem = db.problems.Find(id);
            if (problem == null)
            {
                return HttpNotFound();
            }
            return View(problem);
        }

        // GET: problems/Create
        public ActionResult Create()
        {
            ViewBag.typeProblemID = new SelectList(db.ProblemTypes, "typeProblemID", "descritpionProblem");
            return View();
        }

        // POST: problems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "problemID,descritpionProblem,isActivo,typeProblemID")] problem problem)
        {
            
            if (ModelState.IsValid)
            {
                db.problems.Add(problem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(problem);
        }

        // GET: problems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            problem problem = db.problems.Find(id);
            if (problem == null)
            {
                return HttpNotFound();
            }
            return View(problem);
        }

        // POST: problems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "problemID,descritpionProblem,isActivo,typeProblemID")] problem problem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(problem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(problem);
        }

        // GET: problems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            problem problem = db.problems.Find(id);
            if (problem == null)
            {
                return HttpNotFound();
            }
            return View(problem);
        }

        // POST: problems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            List<problem> problems = db.problems.Include(p => p.problemByReport).Include(p => p.qualityInspection).Where(p => p.problemID == id).ToList();
            problem problem = problems.Find(p => p.problemID == id);

            if (problem.qualityInspection.Count() == 0 && problem.problemByReport.Count() == 0){

                db.problems.Remove(problem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.message = "No se puede Eliminar porque existen Elementos asosociados al problema";
            return View(problem);
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
