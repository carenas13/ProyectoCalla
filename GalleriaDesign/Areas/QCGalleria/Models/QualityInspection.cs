using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GalleriaDesign.Models
{
    public class QualityInspection
    {
        [Key]
        public int qualityInspectiontID { get; set; }
        public int qualityReportID { get; set; }
        public int problemID { get; set; }
        public Boolean answerInspection { get; set; }
        public virtual problem problem { get; set; }
        public virtual QualityReport qualityReport { get; set; }

        
    }
}