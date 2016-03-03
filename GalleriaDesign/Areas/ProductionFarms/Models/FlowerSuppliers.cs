using ApplicationProductionsFarms.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicationProductionsFarms.Models
{
    public class FlowerSuppliers
    {
        [Key]
        public int idFlowerSup { get; set; }
        public string codFlowerSup { get; set; }
        [Required]
        public string description { get; set; }
        public virtual ICollection<VarietyParametersProducts> varietyparametersproducts { get; set; } //Relación con VarietyParameters  
    }
}