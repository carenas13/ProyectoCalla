using GalleriaDesign.Areas.ProductionFarms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicationProductionsFarms.Models
{
    public class Dimensions
    {
        [Key]
        public int idBed { get; set; }
        public string numBed { get; set; }
        [Required]
        public string codeBeds { get; set; }        
        public float length { get; set; }
        public float width { get; set; }

        public int idBlocks { get; set; }
        public virtual Blocks block { get; set; }
    




    }
}