using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GalleriaDesign.Models
{
    public class problem
    {
        [Key]
        public int problemID { get; set; }
        [Required]
        [StringLength(60)]
        public string descritpionProblem { get; set; }
        [Required]
        public Boolean isActivo { get; set; }

        public int typeProblemID { get; set; }
        public virtual ProblemType problemType { get; set; }

        public ICollection<QualityInspection> qualityInspection { get; set; }
        //      public virtual QualityInspection qualityInspection { get; set; }
        public ICollection<ProblemByReport> problemByReport { get; set; }

    }
}