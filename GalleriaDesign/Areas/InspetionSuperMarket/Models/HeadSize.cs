using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class HeadSize
    {
        [Key]
        public int idHeadSize { get; set; }

        public string description { get; set; }

        public virtual ICollection<RoseProgram> roseProgram { get; set; }


    }
}