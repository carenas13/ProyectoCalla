using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GalleriaDesign.Models;
using Rotativa;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;
using System.Text;// para retornar la vista como string
using System.Web.UI;
using Rotativa;// para retornar la vista como string


namespace GalleriaDesign.Areas.QCGalleria.Controllers
{


    public class QualityReportsController : Controller
    {
     //   private GalleriaContext db = new GalleriaContext();
        private GalleriaDesignContext db = new GalleriaDesignContext();

        // GET: QualityReports
        [SessionExpire]
        [Authorize]
        public ActionResult Index(int? typeReport)
        {
            // QualityReport qualityReport = db.QualityReports.Find(id);
            if (typeReport != null)
            {

                //IEnumerable<QualityReport> qualityReport = from reportList in db.QualityReports
                //                                           where reportList.reportTypeId == typeReport
                //                                           select reportList;
                //eInformations = db.StoreInformations.Include(s => s.floralDisplay).Include(s => s.floralSetup).Include(s => s.retailer);

                var qualityReport = db.QualityReports.Include(i => i.qualityInspection).Where(r => r.reportTypeId == typeReport).ToList();
                // var qcr= repor.Find(r => r.reportTypeId == typeReport);
                ///var user = users.Find(u => u.Id == idUser);
               // List<QualityReport> inspectionReport = qualityReport.ToList();
               // List<QualityReport> inspectionReport = new List<QualityReport>();
                //foreach (QualityReport qcReport in inspectionReport)
                //{
                //    IEnumerable<QualityInspection> qualityInspectionQuery = from inspection in db.QualityInspections
                //                                                            where inspection.qualityReportID == qcReport.qualityReportID
                //                                                            select inspection;
                //    qcReport.qualityInspection = qualityInspectionQuery.ToList();
                //   // inspectionReport.Add(db.QualityReports.Find(qcReport.qualityReportID));
                //}


                //  return View(db.QualityReports.OrderByDescending(x=>x.qualityReportID).ToList());
                ViewBag.reportType = typeReport;

                return View(qualityReport);
            }
            else {

                return RedirectToAction("Index", "Home");
            }

        }
        //public ActionResult IndexTypesReports(int typeReport) {


        //    return View(db.QualityReports.OrderByDescending(x => x.qualityReportID).ToList());
        //}
        // GET: QualityReports/Details/5
        [SessionExpire]
        public ActionResult Details(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QualityReport qualityReport = obtenerQualityReport(id);
            if (qualityReport == null)
            {
                return HttpNotFound();
            }

            List<ProblemType> tiposProblemas = new List<ProblemType>();
            int ant = 0;
            foreach (QualityInspection qualityInspetion in qualityReport.qualityInspection)
            {
                if (ant != qualityInspetion.problem.typeProblemID)
                {
                    tiposProblemas.Add(db.ProblemTypes.Find(qualityInspetion.problem.typeProblemID));
                    ant = qualityInspetion.problem.typeProblemID;
                }
            }
          
            ViewBag.problemTypeList = tiposProblemas;            
            return View(qualityReport);


        }

        // GET: QualityReports/Create
        [SessionExpire]
        [Authorize]
        public ActionResult Create(int? typeReport)
        {

            if (typeReport != null)
            {
                IEnumerable<problem> problems = from probl in db.problems
                                                join problByRepor in db.ProblemByReports on probl.problemID equals problByRepor.problemID
                                                where problByRepor.reportTypeId == typeReport
                                                select probl;

                IEnumerable<ProblemType> problemsType = from proType in db.ProblemTypes
                                                        join problByTypeRepor in db.ProblemTypeByReports on proType.typeProblemID equals problByTypeRepor.typeProblemID
                                                        where problByTypeRepor.reportTypeId == typeReport
                                                        select proType;

                ReportType reportType = db.ReportTypes.Find(typeReport);
                //var problem = db.problems;
                var problem = problems.ToList();
                // var problemType = db.ProblemTypes;
                var problemType = problemsType.ToList();
                ViewBag.problemTypeList = problemType;
                ViewBag.problemList = problem;
                ViewBag.reportType = reportType;

                return View();
            }
            else {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: QualityReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        [SessionExpire]
        public ActionResult Create([Bind(Include = "qualityReportID,dateReport,dateWebPack,farmReport,awbNumber,flower,customer,qty,commentsReport,inspectionPlace,userInspector,bunchBox,totalBunch,bunchInspected,boxesInspected,numOrder,reportTypeId")]
        QualityReport qualityReport, List<QualityInspection> qualityInspection, List<ImageByType> img)
        {
            List<Image> listImages = new List<Image>();
            var emailBody = db.EmailsBodies.FirstOrDefault();
            qualityReport.emailsBody = emailBody;
            if (qualityReport.bunchInspected != null && (qualityReport.totalBunch != null && qualityReport.totalBunch != 0))
            {
                float bunchIns = (float)qualityReport.bunchInspected;

                qualityReport.perCalculated = (bunchIns / qualityReport.totalBunch);

            }
            //foreach (ImageByType imagen in img)
            //{
            //    if (imagen.image != null)
            //    {
            //        Image imageSave = new Image();
            //        var data = new byte[imagen.image.ContentLength];
            //        imagen.image.InputStream.Read(data, 0, imagen.image.ContentLength);
            //        imageSave.image = data;
            //        imageSave.typeImage = imagen.image.ContentType;
            //        imageSave.problemType = db.ProblemTypes.Find(imagen.typeImage);
            //        listImages.Add(imageSave);

            //    }
            //}

            foreach (ImageByType imagen in img)
            {
                if (imagen.image != null)
                {
                    // string pictureNew = imagen.image.Substring("data:image/png;base64,".Length);

                    // string typePro = foto.Substring(foto.Length - 1);
                    // pictureNew = pictureNew.Substring(0, pictureNew.Length - 1);

                    string type = string.Empty;
                    type = "image/jpeg";
                    var buffer = Convert.FromBase64String(imagen.image);

                    Image imageSave = new Image();
                    imageSave.typeImage = type;
                    imageSave.problemType = db.ProblemTypes.Find(imagen.typeImage);
                    //  var buffer = pictureNew.Replace(" ", "+");
                    imageSave.image = buffer;
                    listImages.Add(imageSave);
                }

            }




            qualityReport.images = listImages;
            qualityReport.qualityInspection = qualityInspection;
            qualityReport.dateReport = DateTime.Now;
            qualityReport.dateWebPack= DateTime.Now;
            //line temporal
            // qualityReport.reportType = db.ReportTypes.Find(1);
            //fin linea temporal
            if (ModelState.IsValid)
            {
                db.QualityReports.Add(qualityReport);
                db.SaveChanges();
                //enviarCorreo(int id, string emailFarms)
                int id = qualityReport.qualityReportID;
                createPDF(id);
                generarCorreo(id, "");
              //  return View("Details", qualityReport);
               return RedirectToAction("Details", new { id });
            }

            return View(qualityReport);
        }

        // GET: QualityReports/Edit/5
        [SessionExpire]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QualityReport qualityReport = db.QualityReports.Find(id);
            if (qualityReport == null)
            {
                return HttpNotFound();
            }
            return View(qualityReport);
        }

        // POST: QualityReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [SessionExpire]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "qualityReportID,dateReport,farmReport,awbNumber,flower,customer,qty")] QualityReport qualityReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qualityReport).State = EntityState.Modified;
                int typeReport = qualityReport.reportTypeId;
                db.SaveChanges();
                return RedirectToAction("Index", new { typeReport });
            }
            return View(qualityReport);
        }

        // GET: QualityReports/Delete/5
        public ActionResult editEncabezado(int qualityReportID, DateTime dateReport, string farmReport, string awbNumber, string flower, string customer, int qty, string inspectionPlace)
        {

            QualityReport qualityReport = db.QualityReports.Find(qualityReportID);
            qualityReport.qualityReportID = qualityReportID;
            qualityReport.dateReport = dateReport;
            qualityReport.farmReport = farmReport;
            qualityReport.awbNumber = awbNumber;
            qualityReport.flower = flower;
            qualityReport.customer = customer;
            qualityReport.qty = qty;
            qualityReport.inspectionPlace = inspectionPlace;

            if (ModelState.IsValid)
            {
                db.Entry(qualityReport).State = EntityState.Modified;
                db.SaveChanges();
                // return RedirectToAction("Details", new { id= qualityReportID });
            }

            return Json(new { success = true });

        }

        public ActionResult editProblemType(List<QualityInspection> qualityInspection)
        {



            return Json(new { success = true });
        }
        [SessionExpire]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QualityReport qualityReport = db.QualityReports.Find(id);
            if (qualityReport == null)
            {
                return HttpNotFound();
            }
            return View(qualityReport);
        }

        // POST: QualityReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [SessionExpire]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QualityReport qualityReport = db.QualityReports.Find(id);

            int typeReport = qualityReport.reportTypeId;

            db.QualityReports.Remove(qualityReport);
            db.SaveChanges();
            return RedirectToAction("Index", new { typeReport });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //Metodo para crear pdf
        public ActionResult PDF(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QualityReport qualityReport = obtenerQualityReport(id);
            if (qualityReport == null)
            {
                return HttpNotFound();
            }
            //var problemsType = from proType in db.ProblemTypes
            //                                        join problByTypeRepor in db.ProblemTypeByReports 
            //                                        on proType.typeProblemID equals problByTypeRepor.typeProblemID
            //                                        where problByTypeRepor.reportTypeId == qualityReport.reportTypeId
            //                                        select new { proType.typeProblemID,proType.descritpionProblem };


            //IEnumerable<ProblemType>  problemsType = from proType in db.ProblemTypes
            //                                        join problByTypeRepor in db.ProblemTypeByReports on proType.typeProblemID equals problByTypeRepor.typeProblemID
            //                                        where problByTypeRepor.reportTypeId == qualityReport.reportTypeId
            //                                        select proType;

            //  var typeProbleXReportes = db.ProblemTypeByReports;
            //   var typeProblem = db.ProblemTypes;
            List<ProblemType> tiposProblem = new List<ProblemType>();
            //foreach(var tipoProblema in typeProblem)
            //{

            //    foreach (var tipoProblemaReporte in typeProbleXReportes)
            //    {

            //            if(tipoProblemaReporte.typeProblemID == tipoProblema.typeProblemID) {

            //                if (tipoProblemaReporte.reportTypeId == qualityReport.reportTypeId){
            //                tiposProblem.Add(tipoProblema);
            //             }

            //        }
            //    }
            //}

            int ant = 0;
            foreach (QualityInspection qualityInspetion in qualityReport.qualityInspection)
            {
                if (ant != qualityInspetion.problem.typeProblemID)
                {
                    tiposProblem.Add(db.ProblemTypes.Find(qualityInspetion.problem.typeProblemID));
                    ant = qualityInspetion.problem.typeProblemID;
                }
            }
            // var problemType = db.ProblemTypes;
            ViewBag.problemTypeList = tiposProblem;
            return View(qualityReport);

        }
        [SessionExpire]
        public ActionResult generatePDF(int id)
        {

            return new ActionAsPdf("PDF", new { id });
            // return new ActionAsPdf("Details", new { id });

        }

        private QualityReport obtenerQualityReport(int id)
        {


            QualityReport qualityReport = db.QualityReports.Find(id);
            IEnumerable<QualityInspection> qualityInspectionQuery = from inspection in db.QualityInspections
                                                                    where inspection.qualityReportID == id
                                                                    select inspection;
            IEnumerable<Image> imageQuery = from img in db.Images
                                            where img.qualityReportID == id
                                            select img;

            List<QualityInspection> inspectionReport = new List<QualityInspection>();
            foreach (QualityInspection ins in qualityInspectionQuery)
            {
                inspectionReport.Add(ins);
            }

            List<Image> imageReport = new List<Image>();

            foreach (Image image in imageQuery)
            {
                imageReport.Add(image);
            }

            qualityReport.qualityInspection = inspectionReport;
            qualityReport.images = imageReport;
            return qualityReport;

        }






        public FileContentResult GetImage(int imageID)
        {

            var image = db.Images.FirstOrDefault(i => i.imageID == imageID);
            // var image = db.Images.Find(imageID);
            if (image != null)
            {

                string type = string.Empty;
                if (!string.IsNullOrEmpty(image.typeImage))
                {
                    type = image.typeImage;
                }
                else
                {

                    type = "image/jpeg";
                }

                return File(image.image, type);
            }
            else
            {
                return null;
            }
        }
        public ActionResult generarInformeMasivo(int typeReport)
        {

            IEnumerable<QualityReport> qualityReport = from reportList in db.QualityReports
                                                       where reportList.reportTypeId == typeReport
                                                       select reportList;


            List<QualityReport> inspectionReport = qualityReport.ToList();
            foreach (QualityReport Report in inspectionReport)
            {

                int id = Report.qualityReportID;
                createPDF(id);
                 generarCorreo(id, "");
            }


            return RedirectToAction("Index", new { typeReport });
        }
        [SessionExpire]
        public ActionResult enviarCorreo(int id, string emailFarms)
        {

            createPDF(id);
            //var actionResult = new ActionAsPdf("PDF", new { id });
            //var byteArray = actionResult.BuildPdf(ControllerContext);
            //var fileName = "QualityReport.pdf";
            //var filePath = Path.Combine(Server.MapPath("/"), fileName);
            //var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            //fileStream.Write(byteArray, 0, byteArray.Length);
            //fileStream.Close();
            generarCorreo(id, emailFarms);
            //return RedirectToAction("Details", new { id });
            return Json(new { success = true });
        }
        public void createPDF(int id) {
            var actionResult = new ActionAsPdf("PDF", new { id });
            var byteArray = actionResult.BuildPdf(ControllerContext);
            var fileName = "QualityReport.pdf";
            var filePath = Path.Combine(Server.MapPath("/"), fileName);
            var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            fileStream.Write(byteArray, 0, byteArray.Length);
            fileStream.Close();

        }
     
        //enviar correo con adjunto
        public void generarCorreo(int id, string emailFarms)
        {

            QualityReport qualityReport = db.QualityReports.Find(id);
            EmailsBody emailBody = qualityReport.emailsBody;
            // ICollection<Emails> emails = emailBody.emails;
            IEnumerable<Emails> emailsQuery = from emails in db.Emails
                                              where emails.emailBodyID == emailBody.emailBodyID
                                              select emails;
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direcciones de correo electronico a la que queremos enviar el mensaje
            foreach (Emails email in emailsQuery)
            {
                if (email.userIsActive)
                {
                    mmsg.To.Add(email.addressEmail);
                }
            }
            if (emailFarms != null && emailFarms != "")
            {
                mmsg.To.Add(emailFarms);
            }
            // mmsg.To.Add("carenas@callafarms.com");

            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto'
            mmsg.Subject = emailBody.subject + " " + qualityReport.inspectionPlace + " FARM: " + qualityReport.farmReport + " " + " AWB NUMBER: " + qualityReport.awbNumber;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            //mmsg.Bcc.Add("cristianmg13@hotmail.com"); //Opcional
            //Cuerpo del Mensaje
            //mmsg.Body = "Texto del contenio del mensaje de correo";
            mmsg.Body = emailBody.emailContent;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = false;
            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress(emailBody.emailFrom);
            var fileName = "QualityReport.pdf";
            var filePath = Path.Combine(Server.MapPath("/"), fileName);


            mmsg.Attachments.Add(new Attachment(GetStreamFile(filePath), Path.GetFileName(filePath), "application/pdf"));




            //mmsg.Attachments.Add(new Attachment(filePath));
            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            //cliente.Credentials = new System.Net.NetworkCredential("carenas@callafarms.com", "Gal123");
            cliente.Credentials = new System.Net.NetworkCredential(emailBody.emailFrom, emailBody.passwordEmailFrom);

            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail

            /* cliente.Port = 587;
             cliente.EnableSsl = true;*/


            // cliente.Host = "smtp.live.com"; //Para Gmail "smtp.gmail.com";
            cliente.Host = "mail.callafarms.com";


            /*-------------------------ENVIO DE CORREO----------------------*/

            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {

                //Aquí gestionamos los errores al intentar enviar el correo
            }
        }


        public Stream GetStreamFile(string filePath)
        {

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                MemoryStream memStream = new MemoryStream();
                memStream.SetLength(fileStream.Length);
                fileStream.Read(memStream.GetBuffer(), 0, (int)fileStream.Length);

                return memStream;
            }
        }

        public ActionResult getSearch(String filtro)
        {

            IEnumerable<QualityReport> qualityReportsResult = from QRResult in db.QualityReports
                                                              where QRResult.farmReport.Contains(filtro) ||
                                                                    QRResult.customer.Contains(filtro) ||
                                                                    QRResult.flower.Contains(filtro) ||
                                                                    QRResult.userInspector.Contains(filtro)
                                                              select QRResult;
            //qualityReportID,dateReport,farmReport,awbNumber,flower,customer,qty,commentsReport,inspectionPlace,userInspector
            return PartialView("ResultSearch", qualityReportsResult);

            //  return Json(new { success = true });
        }
        public ActionResult editComments(int qualityReportID,string commentsReport)
        {
            QualityReport qualityReport = db.QualityReports.Find(qualityReportID);
            qualityReport.commentsReport = commentsReport;
            if (ModelState.IsValid)
            {
                db.Entry(qualityReport).State = EntityState.Modified;
                db.SaveChanges();
                // return RedirectToAction("Details", new { id= qualityReportID });
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

    }
}
