using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GalleriaDesign.Models
{
    public class QualityReport
    {
        [Key]
        public int qualityReportID { get; set; }
        [Required]
        public DateTime dateReport { get; set; }
        public Nullable<System.DateTime> dateWebPack { get; set; }
        public int? numOrder { get; set; }
        [Required]
        public string farmReport { get; set; }
        public string awbNumber { get; set; }
        [Required]
        public string flower { get; set; }
        [Required]
        public string customer { get; set; }
        public System.Nullable<int> qty { get; set; }
        public string inspectionPlace { get; set; }
        public string commentsReport { get; set; }
        public string userInspector { get; set; }
        public int emailBodyID { get; set; }
        public float? perCalculated { get; set; }
        public int? boxesInspected { get; set; }
        public System.Nullable<int> bunchBox { get; set; }
        public System.Nullable<int> totalBunch { get; set; }
        public System.Nullable<int> bunchInspected { get; set; }
        public int reportTypeId { get; set; }



        public virtual ReportType reportType { get; set; }
        public virtual EmailsBody emailsBody { get; set; }
        public ICollection<QualityInspection> qualityInspection { get; set; }
        public ICollection<Image> images { get; set; }




    }
}