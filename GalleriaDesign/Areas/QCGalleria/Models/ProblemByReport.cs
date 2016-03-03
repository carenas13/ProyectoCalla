using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GalleriaDesign.Models
{
    public class ProblemByReport
    {
        [Key]
        public int problemByReport { get; set; }
        public int reportTypeId { get; set; }
        public int problemID { get; set; }


        public virtual ReportType reportType { get; set; }

        public virtual problem problem { get; set; }

    }
}