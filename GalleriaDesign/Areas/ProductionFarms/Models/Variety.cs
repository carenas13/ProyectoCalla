using ApplicationProductionsFarms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicationProductionsFarms.Model
{
    public class Variety
    {
        [Key]
        public int idVariety { get; set; }
        public string codVariety { get; set; }
        [Required]
        public string descriptionVariety { get; set; }
        //public virtual ICollection<VarietyParametersProducts> varietyparameters { get; set; } //Relación con VarietyParameters  
        public virtual ICollection<VarietyParametersProducts> varietyparametersproducts { get; set; } //Relación con VarietyParameters  
       


    }
}