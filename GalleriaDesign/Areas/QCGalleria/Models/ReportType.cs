using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalleriaDesign.Models
{
    public class ReportType
    {

        public int reportTypeId { get; set; }
        public String nameReportType { get; set; }
        public String descripcionType { get; set; }

        public ICollection<ProblemTypeByReport> problemTypeByReport { get; set; }
        public ICollection<QualityReport> qualityReport { get; set; }

        public ICollection<ProblemByReport> problemByReport { get; set; }
    }
}