using ApplicationProductionsFarms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicationProductionsFarms.Model
{
    public class FarmVariety
    {
        [Key]
        public int idFarmVariety { get; set; }
        public int idFarms { get; set; }      // Relación con Farms
        public virtual Farms Farms { get; set; }      //   

        public int idVariety { get; set; }      // Relación con Variety
        public virtual Variety Variety { get; set; }      //   

    }
}