using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApplicationProductionsFarms.Model;
using ApplicationProductionsFarms.Models;

namespace GalleriaDesign.Areas.ProductionFarms.Controllers
{
    public class VarietyParametersProductsController : Controller
    {
        private ApplicationProductionsFarmsContext db = new ApplicationProductionsFarmsContext();
        //private object idColor;

        // GET: ProductionFarms/VarietyParametersProducts
        public ActionResult Index()
        {
            var varietyParametersProducts = db.VarietyParametersProducts.Include(v => v.Color).Include(v => v.FlowerSuppliers).Include(v => v.FlowerType).Include(v => v.MarketType).Include(v => v.Products).Include(v => v.program).Include(v => v.variety);
            
            foreach (var varieParam in varietyParametersProducts.ToList()) {
                
                //var codeFloweSup = db.FlowerSuppliers.Find(varieParam.idFlowerSup);
                //string codeParam = codeFloweSup.codFlowerSup;
                //var codeFloweType = db.FlowerTypes.Find(varieParam.idCodFlowerType);
                //var codeProduct = db.Products.Find(varieParam.idProduct);
                //var codeColor = db.Colors.Find(varieParam.idColor);
                //var codeVariety = db.Varieties.Find(varieParam.idVariety);
                //var codeMarketType = db.MarketTypes.Find(varieParam.idMaketType);
                //var codeProgram = db.Programs.Find(varieParam.idProgram);
                //codeParam += codeFloweType.codFlowerType;
                string codeParam1 = string.Concat(varieParam.FlowerSuppliers.codFlowerSup,varieParam.FlowerType.codFlowerType,varieParam.Products.codProduct,varieParam.Color.codColor,varieParam.variety.codVariety,varieParam.MarketType.codMarketType,varieParam.program.codProgram);
                //codeParam = string.Concat(codeFloweSup.codFlowerSup, codeProduct.codProduct, codeFloweType.codFlowerType, codeColor.codColor, codeVariety.codVariety, codeMarketType.codMarketType, codeProgram.codProgram);

                varieParam.codVariety = codeParam1;
                
            }


            return View(varietyParametersProducts.ToList());
        }

        // GET: ProductionFarms/VarietyParametersProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VarietyParametersProducts varietyParametersProducts = db.VarietyParametersProducts.Find(id);

            if (varietyParametersProducts == null)
            {
                return HttpNotFound();
            }
            return View(varietyParametersProducts);
        }

        // GET: ProductionFarms/VarietyParametersProducts/Create
        public ActionResult Create()
        {

            ViewBag.idColor = new SelectList(db.Colors, "idColor", "description");
            ViewBag.idFlowerSup = new SelectList(db.FlowerSuppliers, "idFlowerSup", "description");
            ViewBag.idCodFlowerType = new SelectList(db.FlowerTypes, "idCodFlowerType", "description");
            ViewBag.idMaketType = new SelectList(db.MarketTypes, "idMaketType", "description");
            ViewBag.idProduct = new SelectList(db.Products, "idProduct", "description");
            ViewBag.idProgram = new SelectList(db.Programs, "idProgram", "description");
            ViewBag.idVariety = new SelectList(db.Varieties, "idVariety", "descriptionVariety");
            return View();
        }

        // POST: ProductionFarms/VarietyParametersProducts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVariedad,idFlowerSup,idProduct,idCodFlowerType,idColor,idVariety,idMaketType,idProgram,codVariety,DiasEnConf,DiasLuz,DiaInicioF,ProdxCamaTallos,TallosSiemProd,IndicePerdConf,IndicePerdProd,TallosSiemConf,DiasEnSiemDesboton,DiasEnSiemB91,DiasEnSiemB92,DiasEnSiemB93,DiasCorte1,DiasCorte2,DiasCorte3,DiasCorte4,DiasCorte5,DiasCorte6,DiasCorte7,TalloXBalde,TalloXCaja")] VarietyParametersProducts varietyParametersProducts)
        {
            if (ModelState.IsValid)
            {
                db.VarietyParametersProducts.Add(varietyParametersProducts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idColor = new SelectList(db.Colors, "idColor", "codColor", varietyParametersProducts.idColor);
            ViewBag.idFlowerSup = new SelectList(db.FlowerSuppliers, "idFlowerSup", "codFlowerSup", varietyParametersProducts.idFlowerSup);
            ViewBag.idCodFlowerType = new SelectList(db.FlowerTypes, "idCodFlowerType", "codFlowerType", varietyParametersProducts.idCodFlowerType);
            ViewBag.idMaketType = new SelectList(db.MarketTypes, "idMaketType", "codMarketType", varietyParametersProducts.idMaketType);
            ViewBag.idProduct = new SelectList(db.Products, "idProduct", "codProduct", varietyParametersProducts.idProduct);
            ViewBag.idProgram = new SelectList(db.Programs, "idProgram", "codProgram", varietyParametersProducts.idProgram);
            ViewBag.idVariety = new SelectList(db.Varieties, "idVariety", "codVariety", varietyParametersProducts.idVariety);
            return View(varietyParametersProducts);
        }

        // GET: ProductionFarms/VarietyParametersProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VarietyParametersProducts varietyParametersProducts = db.VarietyParametersProducts.Find(id);
            if (varietyParametersProducts == null)
            {
                return HttpNotFound();
            }
            ViewBag.idColor = new SelectList(db.Colors, "idColor", "codColor", varietyParametersProducts.idColor);
            ViewBag.idFlowerSup = new SelectList(db.FlowerSuppliers, "idFlowerSup", "codFlowerSup", varietyParametersProducts.idFlowerSup);
            ViewBag.idCodFlowerType = new SelectList(db.FlowerTypes, "idCodFlowerType", "codFlowerType", varietyParametersProducts.idCodFlowerType);
            ViewBag.idMaketType = new SelectList(db.MarketTypes, "idMaketType", "codMarketType", varietyParametersProducts.idMaketType);
            ViewBag.idProduct = new SelectList(db.Products, "idProduct", "codProduct", varietyParametersProducts.idProduct);
            ViewBag.idProgram = new SelectList(db.Programs, "idProgram", "codProgram", varietyParametersProducts.idProgram);
            ViewBag.idVariety = new SelectList(db.Varieties, "idVariety", "codVariety", varietyParametersProducts.idVariety);
            return View(varietyParametersProducts);
        }

        // POST: ProductionFarms/VarietyParametersProducts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVariedad,idFlowerSup,idProduct,idCodFlowerType,idColor,idVariety,idMaketType,idProgram,codVariety,DiasEnConf,DiasLuz,DiaInicioF,ProdxCamaTallos,TallosSiemProd,IndicePerdConf,IndicePerdProd,TallosSiemConf,DiasEnSiemDesboton,DiasEnSiemB91,DiasEnSiemB92,DiasEnSiemB93,DiasCorte1,DiasCorte2,DiasCorte3,DiasCorte4,DiasCorte5,DiasCorte6,DiasCorte7,TalloXBalde,TalloXCaja")] VarietyParametersProducts varietyParametersProducts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(varietyParametersProducts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idColor = new SelectList(db.Colors, "idColor", "codColor", varietyParametersProducts.idColor);
            ViewBag.idFlowerSup = new SelectList(db.FlowerSuppliers, "idFlowerSup", "codFlowerSup", varietyParametersProducts.idFlowerSup);
            ViewBag.idCodFlowerType = new SelectList(db.FlowerTypes, "idCodFlowerType", "codFlowerType", varietyParametersProducts.idCodFlowerType);
            ViewBag.idMaketType = new SelectList(db.MarketTypes, "idMaketType", "codMarketType", varietyParametersProducts.idMaketType);
            ViewBag.idProduct = new SelectList(db.Products, "idProduct", "codProduct", varietyParametersProducts.idProduct);
            ViewBag.idProgram = new SelectList(db.Programs, "idProgram", "codProgram", varietyParametersProducts.idProgram);
            ViewBag.idVariety = new SelectList(db.Varieties, "idVariety", "codVariety", varietyParametersProducts.idVariety);
            return View(varietyParametersProducts);
        }

        // GET: ProductionFarms/VarietyParametersProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VarietyParametersProducts varietyParametersProducts = db.VarietyParametersProducts.Find(id);
            if (varietyParametersProducts == null)
            {
                return HttpNotFound();
            }
            return View(varietyParametersProducts);
        }

        // POST: ProductionFarms/VarietyParametersProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VarietyParametersProducts varietyParametersProducts = db.VarietyParametersProducts.Find(id);
            db.VarietyParametersProducts.Remove(varietyParametersProducts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult QRCode()
        {
            ViewBag.idVariedad = new SelectList(db.VarietyParametersProducts.OrderByDescending(m => m.idVariedad), "idVariedad", "codVariety");
            //ViewBag.idBed = new SelectList(db.Dimensions, "idBed", "codeBeds");
            //ViewBag.idFarms = new SelectList(db.Farms, "idFarms", "codeFarms");
            //ViewBag.idBlocks = new SelectList(db.Blocks, "idBlocks", "numBlocks");

            return View();
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
