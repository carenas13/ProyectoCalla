using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GalleriaDesign.Models;

namespace GalleriaDesign.Areas.QCGalleria.Controllers
{
    [SessionExpire]
    public class EmailsController : Controller
    {
        private GalleriaDesignContext db = new GalleriaDesignContext();

        // GET: Emails
        public ActionResult Index()
        {
            var emails = db.Emails.Include(e => e.emailsBody);
            return View(emails.ToList());
        }

        // GET: Emails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emails emails = db.Emails.Find(id);
            if (emails == null)
            {
                return HttpNotFound();
            }
            return View(emails);
        }

        // GET: Emails/Create
        public ActionResult Create()
        {
            ViewBag.emailBodyID = new SelectList(db.EmailsBodies, "emailBodyID", "emailFrom");
            return View();
        }

        // POST: Emails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "emailID,userName,userIsActive,addressEmail,emailBodyID")] Emails emails)
        {
            if (ModelState.IsValid)
            {
                db.Emails.Add(emails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.emailBodyID = new SelectList(db.EmailsBodies, "emailBodyID", "emailFrom", emails.emailBodyID);
            return View(emails);
        }

        // GET: Emails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emails emails = db.Emails.Find(id);
            if (emails == null)
            {
                return HttpNotFound();
            }
            ViewBag.emailBodyID = new SelectList(db.EmailsBodies, "emailBodyID", "emailFrom", emails.emailBodyID);
            return View(emails);
        }

        // POST: Emails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "emailID,userName,userIsActive,addressEmail,emailBodyID")] Emails emails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.emailBodyID = new SelectList(db.EmailsBodies, "emailBodyID", "emailFrom", emails.emailBodyID);
            return View(emails);
        }

        // GET: Emails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emails emails = db.Emails.Find(id);
            if (emails == null)
            {
                return HttpNotFound();
            }
            return View(emails);
        }

        // POST: Emails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emails emails = db.Emails.Find(id);
            db.Emails.Remove(emails);
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
