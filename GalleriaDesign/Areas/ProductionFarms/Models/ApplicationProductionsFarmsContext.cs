using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApplicationProductionsFarms.Models
{
    public class ApplicationProductionsFarmsContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ApplicationProductionsFarmsContext() : base("name=ApplicationProductionsFarmsContext")
        {
        }

        public System.Data.Entity.DbSet<ApplicationProductionsFarms.Models.Blocks> Blocks { get; set; }

        public System.Data.Entity.DbSet<ApplicationProductionsFarms.Models.Farms> Farms { get; set; }

        

        public System.Data.Entity.DbSet<ApplicationProductionsFarms.Model.Variety> Varieties { get; set; }

        public System.Data.Entity.DbSet<ApplicationProductionsFarms.Models.Dimensions> Dimensions { get; set; }

        public System.Data.Entity.DbSet<ApplicationProductionsFarms.Model.VarietyParametersProducts> VarietyParametersProducts { get; set; }

        public System.Data.Entity.DbSet<ApplicationProductionsFarms.Models.Color> Colors { get; set; }

        public System.Data.Entity.DbSet<ApplicationProductionsFarms.Models.FlowerSuppliers> FlowerSuppliers { get; set; }

        public System.Data.Entity.DbSet<ApplicationProductionsFarms.Models.FlowerType> FlowerTypes { get; set; }

        public System.Data.Entity.DbSet<ApplicationProductionsFarms.Models.MarketType> MarketTypes { get; set; }

        public System.Data.Entity.DbSet<ApplicationProductionsFarms.Models.Products> Products { get; set; }

        public System.Data.Entity.DbSet<ApplicationProductionsFarms.Models.Program> Programs { get; set; }

        public System.Data.Entity.DbSet<GalleriaDesign.Areas.ProductionFarms.Models.Sowing> Sowings { get; set; }



        // public System.Collections.IEnumerable VarietyParametersProductions { get; set; }






    }
}
