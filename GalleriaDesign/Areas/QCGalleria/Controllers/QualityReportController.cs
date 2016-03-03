using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GalleriaDesign.Models;
using System.IO;

namespace GalleriaDesign.Areas.QCGalleria.Controllers
{
    public class QualityReportController : Controller
    {
        //private DesignGalleriaContext db = new DesignGalleriaContext();
        private GalleriaDesignContext db = new GalleriaDesignContext();
        // GET: QualityReport
        public ActionResult Index()
        {
            var problem = db.problems;

            return View(problem.ToList());
        }
        [HttpPost]
        public ActionResult Index(List<HttpPostedFileBase> img)
        {
            foreach (HttpPostedFileBase imagen in img) {

                var data = new byte[imagen.ContentLength];
                imagen.InputStream.Read(data, 0, imagen.ContentLength);                
                var imagenes = db.Images;
                Image im = new Image();
                im.image = data;
                im.typeImage= imagen.ContentType;
                im.qualityReport = db.QualityReports.Find(142);
                im.typeProblemID= 1;
                db.Images.Add(im);
            }
                db.SaveChanges();


            return View();
        }

        public ActionResult cargarImagen(List<ImageByType> img) {




            return View();
        }




        public ActionResult Upload(string image)
        {
            image = image.Substring("data:image/png;base64,".Length);
            var buffer = Convert.FromBase64String(image);
            // TODO: I am saving the image on the hard disk but
            // you could do whatever processing you want with it
            System.IO.File.WriteAllBytes(Server.MapPath("~/app_data/capture.png"), buffer);
            return Json(new { success = true });
        }

    }
}