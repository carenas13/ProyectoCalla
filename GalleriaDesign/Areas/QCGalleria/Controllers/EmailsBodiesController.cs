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
    public class EmailsBodiesController : Controller
    {
        private GalleriaDesignContext db = new GalleriaDesignContext();

        // GET: EmailsBodies
        public ActionResult Index()
        {
            return View(db.EmailsBodies.ToList());
        }

        // GET: EmailsBodies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailsBody emailsBody = db.EmailsBodies.Find(id);
            if (emailsBody == null)
            {
                return HttpNotFound();
            }
            return View(emailsBody);
        }

        // GET: EmailsBodies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmailsBodies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "emailBodyID,emailFrom,passwordEmailFrom,subject,emailContent,signatureEmail")] EmailsBody emailsBody)
        {
            if (ModelState.IsValid)
            {
                db.EmailsBodies.Add(emailsBody);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emailsBody);
        }

        // GET: EmailsBodies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailsBody emailsBody = db.EmailsBodies.Find(id);
            if (emailsBody == null)
            {
                return HttpNotFound();
            }
            return View(emailsBody);
        }

        // POST: EmailsBodies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "emailBodyID,emailFrom,passwordEmailFrom,subject,emailContent,signatureEmail")] EmailsBody emailsBody)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emailsBody).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emailsBody);
        }

        // GET: EmailsBodies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailsBody emailsBody = db.EmailsBodies.Find(id);
            if (emailsBody == null)
            {
                return HttpNotFound();
            }
            return View(emailsBody);
        }

        // POST: EmailsBodies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List<EmailsBody> emailsBody = db.EmailsBodies.Include(eb => eb.emails).Include(eb => eb.qualityReport).Where(eb => eb.emailBodyID == id).ToList();
            EmailsBody emailBody = emailsBody.Find(eb =>eb.emailBodyID==id);
            if (emailBody.emails.Count() == 0 && emailBody.qualityReport.Count() ==0){
                db.EmailsBodies.Remove(emailBody);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.message = "No se puede Eliminar porque existen Elementos asosociados al Email Body";
            return View(emailBody);
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
