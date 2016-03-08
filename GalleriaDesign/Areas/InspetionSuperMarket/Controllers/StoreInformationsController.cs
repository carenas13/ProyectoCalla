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

            ViewBag.productBreakList = db.ProductBreackDowns.ToList();

           // ViewData["fecha"] = DateTime.Now.ToString();

            return View();
        }

        // POST: StoreInformations/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StoreInformation storeInformation , ConsumerBunchProgram consumerBunch,
            RoseProgram roseProgram, BouquetProgram bouquetProgram,StoreExecution storeExecution, AdditionalComents additionalComents, 
            List<ImageTypeStoreInformation> imagetypeStoreInformation, List<ImageTypeBunchProgram> imagetypeBunchProgram,
            List<ImageTypeRoseProgram> imageTypeRoseProgram, List<ImagesTypeBouquetProgram> imageTypeBouquetProgram,
            List<ImageTypeStoreExecutions> imageTypeStoreExecution, List<ImageTypeAdditionalComents> imageTypeAdditionalComments,
            List<Store_ProductBreakDown> storeProductBreakDown)
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
            List<ImagesRoseProgram> listImageRoseProgram = new List<ImagesRoseProgram>();
            List<ImagesBouquetProgram> listImageBouquetProgram = new List<ImagesBouquetProgram>();
            List<ImagesStoreExecution> listImageStoreExecution = new List<ImagesStoreExecution>();
            List<ImagesAdditionalComents> listImageAdditional = new List<ImagesAdditionalComents>();


            foreach (ImageTypeStoreInformation imagen in imagetypeStoreInformation)
            {
                if (imagen.foto != null)
                {
                    string type = string.Empty;
                    type = "image/jpeg";
                    var buffer = Convert.FromBase64String(imagen.foto);
                    ImagesStoreInformation imageSave = new ImagesStoreInformation();
                    imageSave.image = buffer;
                    listImageStoreInformation.Add(imageSave);
                }
            }

            foreach (ImageTypeBunchProgram imagen in imagetypeBunchProgram)
            {
                if (imagen.fotoTypeBunchProgram != null)
                {
                    string type = string.Empty;
                    type = "image/jpeg";
                    var buffer = Convert.FromBase64String(imagen.fotoTypeBunchProgram);
                    ImagesBunchProgram imageSave = new ImagesBunchProgram();
                    imageSave.image = buffer;
                    listImageBunchProgram.Add(imageSave);

                }
            }

            foreach (ImageTypeRoseProgram imagen in imageTypeRoseProgram)
            {
                if (imagen.fotoTypeRoseProgram != null)
                {
                    string type = string.Empty;
                    type = "image/jpeg";
                    var buffer = Convert.FromBase64String(imagen.fotoTypeRoseProgram);
                    ImagesRoseProgram imageSave = new ImagesRoseProgram();
                    imageSave.image = buffer;
                    listImageRoseProgram.Add(imageSave);

                }
            }

            foreach (ImagesTypeBouquetProgram imagen in imageTypeBouquetProgram)
            {
                if (imagen.fotoTypeBouquetProgram != null)
                {
                    string type = string.Empty;
                    type = "image/jpeg";
                    var buffer = Convert.FromBase64String(imagen.fotoTypeBouquetProgram);
                    ImagesBouquetProgram imageSave = new ImagesBouquetProgram();
                    imageSave.image = buffer;
                    listImageBouquetProgram.Add(imageSave);

                }
            }

            foreach (ImageTypeStoreExecutions imagen in imageTypeStoreExecution)
            {
                if (imagen.fotoTypeStoreExecutions != null)
                {
                    string type = string.Empty;
                    type = "image/jpeg";
                    var buffer = Convert.FromBase64String(imagen.fotoTypeStoreExecutions);
                    ImagesStoreExecution imageSave = new ImagesStoreExecution();
                    imageSave.image = buffer;
                    listImageStoreExecution.Add(imageSave);

                }
            }

            foreach (ImageTypeAdditionalComents imagen in imageTypeAdditionalComments)
            {
                if (imagen.fotoTypeAdditionalComments != null)
                {
                    string type = string.Empty;
                    type = "image/jpeg";
                    var buffer = Convert.FromBase64String(imagen.fotoTypeAdditionalComments);
                    ImagesAdditionalComents imageSave = new ImagesAdditionalComents();
                    imageSave.image = buffer;
                    listImageAdditional.Add(imageSave);

                }
            }


         

            storeInformation.storeProductBreakDown = storeProductBreakDown;
            storeInformation.imagesStoreInformation = listImageStoreInformation;


            // Se agrega lista de imagenes a Buch Program
            consumerBunch.imagesBunchProgram = listImageBunchProgram;
            List<ConsumerBunchProgram> consumerBunches = new List<ConsumerBunchProgram>();
            consumerBunches.Add(consumerBunch);
            storeInformation.consumerBunchProgram = consumerBunches;

            // Se agrega lista de imagenes a Rose Program
            roseProgram.imagesRoseProgam = listImageRoseProgram;
            List<RoseProgram> rosePrograms = new List<RoseProgram>();
            rosePrograms.Add(roseProgram);
            storeInformation.roseProgram = rosePrograms;

            //Se agrega lista de imagenes a Bouque Program
            bouquetProgram.imagesBouquetProgam = listImageBouquetProgram;
            List<BouquetProgram> bouquetPrograms = new List<BouquetProgram>();
            bouquetPrograms.Add(bouquetProgram);
            storeInformation.bouquetProgram = bouquetPrograms;

            //  Se agrega lista de imagenes a Executions Program

            storeExecution.imagesStoreExecution = listImageStoreExecution;
            List<StoreExecution> storeExecutions = new List<StoreExecution>();
            storeExecutions.Add(storeExecution);
            storeInformation.storeExecution = storeExecutions;

            //Se agrega lista de imagenes a AdditionalComments Program
            additionalComents.imagesAdditionalComents = listImageAdditional;
            List<AdditionalComents> additionalsComents = new List<AdditionalComents>();
            additionalsComents.Add(additionalComents);
            storeInformation.additionalComents = additionalsComents;


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
