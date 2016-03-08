using ApplicationProductionsFarms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GalleriaDesign.Areas.ProductionFarms.Models
{
    public class Sowing
    {
        [Key]
        public int idSowing { get; set; }
        public string NumSowing { get; set; }
        public DateTime fecSowing { get; set; }
        public int month { get; set; }
        public int weekSowing { get; set; }
        public string fusionCode { get; set; }
        public int metersavailable { get; set; }
        public int stemsxMeters { get; set; }

        public int idFarms { get; set; }              // Relación muchos con Farms
        public virtual Farms Farms { get; set; }      //


    }
}