using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GalleriaDesign.Models
{
    public class ProblemTypeByReport
    {
        [Key]
        public int problemTypeByReportID { get; set; }
        public int reportTypeId { get; set; }
        public int typeProblemID { get; set; }


        public virtual ReportType reportType { get; set; }

        public virtual ProblemType problemType { get; set; }



    }
}