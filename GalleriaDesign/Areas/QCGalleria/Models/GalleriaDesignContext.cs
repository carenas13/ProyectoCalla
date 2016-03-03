using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GalleriaDesign.Models
{
    public class GalleriaDesignContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public GalleriaDesignContext()
            : base("name=DesignGalleriaContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();


        }


        public System.Data.Entity.DbSet<GalleriaDesign.Models.ProblemType> ProblemTypes { get; set; }

        public System.Data.Entity.DbSet<GalleriaDesign.Models.problem> problems { get; set; }

        public System.Data.Entity.DbSet<GalleriaDesign.Models.QualityReport> QualityReports { get; set; }

        public System.Data.Entity.DbSet<GalleriaDesign.Models.QualityInspection> QualityInspections { get; set; }

        public System.Data.Entity.DbSet<GalleriaDesign.Models.Image> Images { get; set; }

        public System.Data.Entity.DbSet<GalleriaDesign.Models.ImageTem> ImageTems { get; set; }

        public System.Data.Entity.DbSet<GalleriaDesign.Models.EmailsBody> EmailsBodies { get; set; }

        public System.Data.Entity.DbSet<GalleriaDesign.Models.Emails> Emails { get; set; }

        public System.Data.Entity.DbSet<GalleriaDesign.Models.ReportType> ReportTypes { get; set; }

        public System.Data.Entity.DbSet<GalleriaDesign.Models.ProblemTypeByReport> ProblemTypeByReports { get; set; }

        public System.Data.Entity.DbSet<GalleriaDesign.Models.ProblemByReport> ProblemByReports { get; set; }

     

    }
}
