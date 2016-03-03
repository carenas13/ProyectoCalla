using ApplicationProductionsFarms.Model;
using GalleriaDesign.Areas.ProductionFarms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicationProductionsFarms.Models
{
    public class Blocks
    {
        [Key]
        public int idBlocks { get; set; }
        public string numBlocks { get; set; }
        [Required]
        public float numBeds { get; set; }
        public int idFarms { get; set; }              // Relación muchos con Farms
        public virtual Farms Farms { get; set; }      //   
        public virtual ICollection<Dimensions> dimensions { get; set; } //Relaciion uno con PlaneBlocks
        
      




    }
}