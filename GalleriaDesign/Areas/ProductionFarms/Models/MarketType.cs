using ApplicationProductionsFarms.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicationProductionsFarms.Models
{
    public class MarketType
    {
        [Key]
        public int idMaketType { get; set; }
        public string codMarketType { get; set; }
        [Required]
        public string description { get; set; }

        public virtual ICollection<VarietyParametersProducts> varietyparametersproducts { get; set; } //Relación con VarietyParameters  
    }
}