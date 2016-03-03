using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class SupermarketContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SupermarketContext() : base("name=SupermarketContext")
        {
        }

        public System.Data.Entity.DbSet<Supermarket.Models.Basics> Basics { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.CoolerTemperature> CoolerTemperatures { get; set; }

        

        public System.Data.Entity.DbSet<Supermarket.Models.ExposureClimate> ExposureClimates { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.FillerType> FillerTypes { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.FloralDisplay> FloralDisplays { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.Retailer> Retailers { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.ProductBreackDown> ProductBreackDowns { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.Focals> Focals { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.FloralSetup> FloralSetups { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.StoreInformation> StoreInformations { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.Store_ProductBreakDown> Store_ProductBreakDown { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.WaterTemperature> WaterTemperatures { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.ConsumerBunchType> ConsumerBunchTypes { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.StemLength> StemLengths { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.ConsumerBunchProgram> ConsumerBunchPrograms { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.WaterState> WaterStates { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.PullDates> PullDates { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.BouquetProgram> BouquetPrograms { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.Bouquet_GreenType> Bouquet_GreenType { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.GreenType> GreenTypes { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.Bouquet_Filler> Bouquet_Filler { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.Bouquet_Basics> Bouquet_Basics { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.Bouquet_Focals> Bouquet_Focals { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.FlowerPerfomance> FlowerPerfomances { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.OverallFloralExecution> OverallFloralExecutions { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.RoseProgram> RosePrograms { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.ColorEnhaced> ColorEnhaceds { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.SleeveType> SleeveTypes { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.Supplier> Suppliers { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.HeadSize> HeadSizes { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.Rose_Filler> Rose_Filler { get; set; }

        public System.Data.Entity.DbSet<Supermarket.Models.Rose_GreenType> Rose_GreenType { get; set; }

  

        public System.Data.Entity.DbSet<Supermarket.Models.StoreExecution> StoreExecutions { get; set; }

        public System.Data.Entity.DbSet<GalleriaDesign.Areas.InspetionSuperMarket.Models.AdditionalComents> AdditionalComents { get; set; }

    

        public System.Data.Entity.DbSet<GalleriaDesign.Areas.InspetionSuperMarket.Models.ImagesAdditionalComents> ImagesAdditionalComents { get; set; }

        public System.Data.Entity.DbSet<GalleriaDesign.Areas.InspetionSuperMarket.Models.ImagesBouquetProgram> ImagesBouquetPrograms { get; set; }

        public System.Data.Entity.DbSet<GalleriaDesign.Areas.InspetionSuperMarket.Models.ImagesBunchProgram> ImagesBunchPrograms { get; set; }

        public System.Data.Entity.DbSet<GalleriaDesign.Areas.InspetionSuperMarket.Models.ImagesRoseProgram> ImagesRosePrograms { get; set; }

        public System.Data.Entity.DbSet<GalleriaDesign.Areas.InspetionSuperMarket.Models.ImagesStoreExecution> ImagesStoreExecutions { get; set; }

        public System.Data.Entity.DbSet<GalleriaDesign.Areas.InspetionSuperMarket.Models.ImagesStoreInformation> ImagesStoreInformations { get; set; }
    }
}
