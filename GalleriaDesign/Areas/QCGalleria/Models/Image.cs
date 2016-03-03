using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GalleriaDesign.Models
{
    public class Image
    {
        [Key]
        public int imageID { get; set; }
        public string descriptionImage { get; set; }
        //tipo de imagen
        public String typeImage { get; set; }

        //imagen representada commo arreglo
        [Column(TypeName = "image")]
        public byte[] image { get; set; }
        public int qualityReportID { get; set; }
        public int typeProblemID { get; set; }
        public virtual QualityReport qualityReport { get; set; }
        public virtual ProblemType problemType { get; set; }
    }
}