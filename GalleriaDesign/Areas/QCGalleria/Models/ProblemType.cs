using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GalleriaDesign.Models
{
    public class ProblemType
    {
        [Key]
        public int typeProblemID { set; get; }
        [Required]
        [StringLength(60)]
        public string descritpionProblem { set; get; }
        [Required]
        public Boolean isActivo { get; set; }

        public ICollection<ProblemTypeByReport> problemTypeByReport { get; set;}
        public ICollection<problem> problems { get; set; }
        public ICollection<Image> images { get; set; }

    }
}