using ApplicationProductionsFarms.Model;
using GalleriaDesign.Areas.ProductionFarms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicationProductionsFarms.Models
{
    public class Farms
    {
        [Key]
        public int idFarms { get; set; }    
        public string codeFarms { get; set; }
        [Required]
        public string description { get; set; }
        public virtual ICollection<Blocks> blocks { get; set; } //Relación con Blocks   
        public virtual ICollection<FarmVariety> farmvariety { get; set; } //Relación con VarietyParameters
        
       

    }
}