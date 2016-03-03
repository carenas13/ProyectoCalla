using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class StemLength
    {

        [Key]
        public int idStemLength { get; set; }

        public string description { get; set; }

        public virtual ICollection<RoseProgram> roseProgram { get; set; }

    }
}