using GalleriaDesign.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GalleriaDesign.Areas.QCGalleria.Controllers
{
    public class HomeQCGalleriaController : Controller
    {
        private GalleriaDesignContext db = new GalleriaDesignContext();
        // GET: QCGalleria/HomeQCGalleria
        public ActionResult Index()
        {
            var reportTypes = db.ReportTypes;
            ViewBag.reportTypes = reportTypes.ToList();
            return View();
        }
        public ActionResult _Layout()
        {
            var reportTypes = db.ReportTypes;
            ViewBag.reportTypes = reportTypes.ToList();
            return View();
        }
    }
}