using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Supermarket.Models;
using GalleriaDesign.Areas.InspetionSuperMarket.Models;

namespace GalleriaDesign.Areas.InspetionSuperMarket.Controllers
{
    public class StoreInformationsController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        public object Datetime { get; private set; }

        // GET: StoreInformations
        public ActionResult Index()
        {
            var storeInformations = db.StoreInformations.Include(s => s.floralDisplay).Include(s => s.floralSetup).Include(s => s.retailer);
            return View(storeInformations.ToList());
        }

        // GET: StoreInformations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreInformation storeInformation = db.StoreInformations.Find(id);
            if (storeInformation == null)
            {
                return HttpNotFound();
            }
            return View(storeInformation);
        }

        // GET: StoreInformations/Create
        public ActionResult Create()
        {

            // store Information
            ViewBag.idFloralDisplay = new SelectList(db.FloralDisplays, "idFloralDisplay", "description");
            ViewBag.idFloralSetup = new SelectList(db.FloralSetups, "idFloralSetup", "description");
            ViewBag.idRetailer = new SelectList(db.Retailers, "idRetailer", "nameRetailer");


            // Consumer Bunch Program
            ViewBag.idConsumerBunchType = new SelectList(db.ConsumerBunchTypes, "idConsumerBunchType", "nameConsumer");
            ViewBag.colorEnlancedBP = new SelectList(db.ColorEnhaceds, "idColorEnhaced", "nameColor");
            ViewBag.idSupplier = new SelectList(db.Suppliers, "idSupplier", "nameSupplier");
            ViewBag.sleevetypeBP = new SelectList(db.SleeveTypes, "idSleeveType", "nameSleeve");



            //Rose program

            ViewBag.idStemLength = new SelectList(db.StemLengths, "idStemLength", "description");
            ViewBag.idHeadSize = new SelectList(db.HeadSizes, "idHeadSize", "description");
            ViewBag.sleeveRP = new SelectList(db.SleeveTypes, "idSleeveType", "nameSleeve");
            ViewBag.supplierRP = new SelectList(db.Suppliers, "idSupplier", "nameSupplier");
            ViewBag.roseColorEnhanced = new SelectList(db.ColorEnhaceds, "idColorEnhaced", "nameColor");
            ViewBag.FillerColorEnhanced = new SelectList(db.ColorEnhaceds, "idColorEnhaced", "nameColor");
            ViewBag.greenColorEnhaced = new SelectList(db.ColorEnhaceds, "idColorEnhaced", "nameColor");
            ViewBag.supplierRetail = new SelectList(db.Suppliers, "idSupplier", "nameSupplier");
            ViewBag.sleeveRetail = new SelectList(db.SleeveTypes, "idSleeveType", "nameSleeve");

            //Bouquet Program

            ViewBag.colorEnhacedFocal = new SelectList(db.ColorEnhaceds, "idColorEnhaced", "nameColor");
            ViewBag.colorenhacedBasic = new SelectList(db.ColorEnhaceds, "idColorEnhaced", "nameColor");
            ViewBag.colorEnhacedFiller = new SelectList(db.ColorEnhaceds, "idColorEnhaced", "nameColor");
            ViewBag.colorEnhacedGreen = new SelectList(db.ColorEnhaceds, "idColorEnhaced", "nameColor");
            ViewBag.supplierBPR = new SelectList(db.Suppliers, "idSupplier", "nameSupplier");
            ViewBag.sleeveBPR = new SelectList(db.SleeveTypes, "idSleeveType", "nameSleeve");
            



            //Store executions

            ViewBag.idOverallFloral = new SelectList(db.OverallFloralExecutions, "idOverallFloral", "nameOverall");
            ViewBag.idFlowerPerformance = new SelectList(db.FlowerPerfomances, "idFlowerPerformance", "description");
            ViewBag.idPullDates = new SelectList(db.PullDates, "idPullDates", "description");
            ViewBag.idWaterTemperature = new SelectList(db.WaterTemperatures, "idWaterTemperature", "description");
            ViewBag.idWaterState = new SelectList(db.WaterStates, "idWaterState", "description");
            ViewBag.idCoolerTemperature = new SelectList(db.CoolerTemperatures, "idCoolerTemperature", "description");
            ViewBag.idExposureClimate = new SelectList(db.ExposureClimates, "idExposureClimate", "description");
            ViewBag.exposureDraft = new SelectList(db.ExposureClimates, "idExposureClimate", "description");

            ViewData["fecha"] = DateTime.Now.ToString();

            return View();
        }

        // POST: StoreInformations/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StoreInformation storeInformation , ConsumerBunchProgram consumerBunch,
            RoseProgram roseProgram, BouquetProgram bouquetProgram, StoreExecution storeExecution, AdditionalComents additionalComents, List<ImageTypeStoreInformation> imagetypeStoreInformation, List<ImageTypeBunchProgram> imagetypeBunchProgram,List<ImageTypeRoseProgram> imageTypeRoseProgram, List<ImagesTypeBouquetProgram> imageTypeBouquetProgram,List<ImageTypeStoreExecutions> imageTypeStoreExecution, List<ImageTypeAdditionalComents> imageTypeAdditionalComments)
        {

            //Cbp:ConsumerBunchProgram  //Rp: RoseProgram //Bp: BouquetProgra //Se: Store Execution //Ac: Additional Comentarios
   

            List<ConsumerBunchProgram> cbp= new List<ConsumerBunchProgram>();
            cbp.Add(consumerBunch);
            storeInformation.consumerBunchProgram = cbp;

            List<RoseProgram> rp = new List<RoseProgram>();
            rp.Add(roseProgram);
            storeInformation.roseProgram = rp;


            List<BouquetProgram> bp = new List<BouquetProgram>();
            bp.Add(bouquetProgram);
            storeInformation.bouquetProgram=bp;

            List<StoreExecution> se = new List<StoreExecution>();
            se.Add(storeExecution);
            storeInformation.storeExecution = se;

            List<AdditionalComents> ac = new List<AdditionalComents>();
            ac.Add(additionalComents);
            storeInformation.additionalComents = ac;

            List<ImagesStoreInformation> listImageStoreInformation = new List<ImagesStoreInformation>();
            List<ImagesBunchProgram> listImageBunchProgram = new List<ImagesBunchProgram>();

            foreach (ImageTypeStoreInformation imagen in imagetypeStoreInformation)
            {
                if (imagen.foto != null)
                {
                    // string pictureNew = imagen.image.Substring("data:image/png;base64,".Length);

                    // string typePro = foto.Substring(foto.Length - 1);
                    // pictureNew = pictureNew.Substring(0, pictureNew.Length - 1);

                    string type = string.Empty;
                    type = "image/jpeg";
                    var buffer = Convert.FromBase64String(imagen.foto);

                    ImagesStoreInformation imageSave = new ImagesStoreInformation();

                    //imageSave.problemType = db.ProblemTypes.Find(imagen.typeImage);
                    //  var buffer = pictureNew.Replace(" ", "+");
                    imageSave.image = buffer;
                    listImageStoreInformation.Add(imageSave);
                }


            }


            storeInformation.imagesStoreInformation = listImageStoreInformation;

            if (ModelState.IsValid)
            {
                db.StoreInformations.Add(storeInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFloralDisplay = new SelectList(db.FloralDisplays, "idFloralDisplay", "description", storeInformation.idFloralDisplay);
            ViewBag.idFloralSetup = new SelectList(db.FloralSetups, "idFloralSetup", "description", storeInformation.idFloralSetup);
            ViewBag.idRetailer = new SelectList(db.Retailers, "idRetailer", "nameRetailer", storeInformation.idRetailer);


            return View(storeInformation);
        }

        // GET: StoreInformations/Edit/5


        public FileContentResult GetImage(int imageID)
        {

            var image = db.ImagesStoreInformations.FirstOrDefault(i => i.imageStoreInformationID == imageID);
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

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreInformation storeInformation = db.StoreInformations.Find(id);
            if (storeInformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFloralDisplay = new SelectList(db.FloralDisplays, "idFloralDisplay", "description", storeInformation.idFloralDisplay);
            ViewBag.idFloralSetup = new SelectList(db.FloralSetups, "idFloralSetup", "description", storeInformation.idFloralSetup);
            ViewBag.idRetailer = new SelectList(db.Retailers, "idRetailer", "nameRetailer", storeInformation.idRetailer);
            return View(storeInformation);
        }

        // POST: StoreInformations/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idStoreInformation,idRetailer,otherRetailer,store,date,city,state,inspector,idFloralSetup,fullService,idFloralDisplay,otherProduct")] StoreInformation storeInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storeInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFloralDisplay = new SelectList(db.FloralDisplays, "idFloralDisplay", "description", storeInformation.idFloralDisplay);
            ViewBag.idFloralSetup = new SelectList(db.FloralSetups, "idFloralSetup", "description", storeInformation.idFloralSetup);
            ViewBag.idRetailer = new SelectList(db.Retailers, "idRetailer", "nameRetailer", storeInformation.idRetailer);
            return View(storeInformation);
        }

        // GET: StoreInformations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreInformation storeInformation = db.StoreInformations.Find(id);
            if (storeInformation == null)
            {
                return HttpNotFound();
            }
            return View(storeInformation);
        }

        // POST: StoreInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StoreInformation storeInformation = db.StoreInformations.Find(id);
            db.StoreInformations.Remove(storeInformation);
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
