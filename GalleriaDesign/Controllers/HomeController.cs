using GalleriaDesign.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GalleriaDesign.Controllers
{
    public class HomeController : Controller
    {
       // private DesignGalleriaContext db = new DesignGalleriaContext();
        private GalleriaDesignContext db = new GalleriaDesignContext();
        [Authorize]
        public ActionResult Index()
        {
            var reportTypes = db.ReportTypes;
            ViewBag.reportTypes = reportTypes.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult _Layout()
        {
            var reportTypes = db.ReportTypes;
            ViewBag.reportTypes = reportTypes.ToList();
            return View();
        }
        public ActionResult Preview(string file)
        {
             file = "logoGalleria.png";
            var path = ControllerContext.HttpContext.Server.MapPath("/Content/Img");
            if (file != null)
            {
                if (System.IO.File.Exists(Path.Combine(path, file)))
                {
                    return File(Path.Combine(path, file), "image/jpeg");
                }
            }
            return new HttpNotFoundResult();
        }
        public ActionResult SubirFoto()
        {


            return View();

        }
      /// <summary>
      /// Metodo para subir la foto o el logo de la compañia al home de la aplicacion 
      /// </summary>
      /// <param name="fotoLogo"></param>
      /// <returns></returns>
        [HttpPost]
        public ActionResult SubirFoto(string fotoLogo)
        {

            string type = string.Empty;
            type = "image/jpeg";
            var buffer = Convert.FromBase64String(fotoLogo);

            ImageTem imageSave = new ImageTem();
            imageSave.description = "logo calla";
           
            //  var buffer = pictureNew.Replace(" ", "+");
            imageSave.image = buffer;
            if (ModelState.IsValid)
            {
                db.ImageTems.Add(imageSave);
                db.SaveChanges();
            }
            return View();

        }
        public FileContentResult GetImage(int imageID)
        {

            var image = db.ImageTems.FirstOrDefault(i => i.imageTemID == imageID);
            // var image = db.Images.Find(imageID);
            if (image != null)
            {

                string type = string.Empty;
              

                    type = "image/jpeg";
              

                return File(image.image, type);
            }
            else
            {
                return null;
            }
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