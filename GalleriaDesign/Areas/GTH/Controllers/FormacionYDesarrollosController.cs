using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GalleriaDesign.Areas.GTH.Models;
using GalleriaDesign.Models;

namespace GalleriaDesign.Areas.GTH.Controllers
{
    public class FormacionYDesarrollosController : Controller
    {
        private GTHContext db = new GTHContext();

        // GET: GTH/FormacionYDesarrollos
        public ActionResult Index()
        {
            return View(db.FormacionYDesarrolloes.ToList());
        }

        // GET: GTH/FormacionYDesarrollos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormacionYDesarrollo formacionYDesarrollo = db.FormacionYDesarrolloes.Find(id);
            formacionYDesarrollo.archivoAdjunto = db.ArchivoAdjuntoes.Where(ad => ad.idFormacionYDesarrollo == id).ToList();
            formacionYDesarrollo.participante = db.Participantes.Where(p => p.idFormacionYDesarrollo == id).ToList();


            if (formacionYDesarrollo == null)
            {
                return HttpNotFound();
            }
            return View(formacionYDesarrollo);
        }

        // GET: GTH/FormacionYDesarrollos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GTH/FormacionYDesarrollos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormacionYDesarrollo formacionYDesarrollo, List<string> archivos, List<Participante> participantes)
        {
            List<ArchivoAdjunto> archivosAdjuntos = new List<ArchivoAdjunto>();
            if (archivos!=null) {
                foreach(string foto in archivos)
                {

                    string type = string.Empty;
                    type = "image/jpeg";
                    var buffer = Convert.FromBase64String(foto);
                    ArchivoAdjunto imageSave = new ArchivoAdjunto();
                    imageSave.image = buffer;
                    archivosAdjuntos.Add(imageSave);

                }
            }
            formacionYDesarrollo.participante = participantes;
            formacionYDesarrollo.archivoAdjunto = archivosAdjuntos;

            if (ModelState.IsValid)
            {
                db.FormacionYDesarrolloes.Add(formacionYDesarrollo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formacionYDesarrollo);
        }

        // GET: GTH/FormacionYDesarrollos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormacionYDesarrollo formacionYDesarrollo = db.FormacionYDesarrolloes.Find(id);
            if (formacionYDesarrollo == null)
            {
                return HttpNotFound();
            }
            return View(formacionYDesarrollo);
        }

        // POST: GTH/FormacionYDesarrollos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFormacionYDesarrollo,nombreTema,fecha,duracion,capacitacionProgramada,objetivoCapactiacion,contenido")] FormacionYDesarrollo formacionYDesarrollo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formacionYDesarrollo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formacionYDesarrollo);
        }

        // GET: GTH/FormacionYDesarrollos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormacionYDesarrollo formacionYDesarrollo = db.FormacionYDesarrolloes.Find(id);
            if (formacionYDesarrollo == null)
            {
                return HttpNotFound();
            }
            return View(formacionYDesarrollo);
        }

        // POST: GTH/FormacionYDesarrollos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormacionYDesarrollo formacionYDesarrollo = db.FormacionYDesarrolloes.Find(id);
            db.FormacionYDesarrolloes.Remove(formacionYDesarrollo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// obtener las imagenes de la formacion 
        /// </summary>
        /// <param name="imageID"></param>
        /// <returns></returns>
        public FileContentResult GetImage(int idArchivoAdjunto)
        {

            var image = db.ArchivoAdjuntoes.FirstOrDefault(i => i.idArchivoAdjunto == idArchivoAdjunto);
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
