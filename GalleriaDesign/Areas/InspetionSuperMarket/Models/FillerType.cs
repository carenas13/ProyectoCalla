using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class FillerType
    {
        [Key]
        public int idFillerType { get; set; }

        public string nameFiller { get; set; } 
         

    }
}