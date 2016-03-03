using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class Rose_GreenType
    {
        [Key]
        public int idRoseGreenType { get; set; }
   
        public int idRoseProgram { get; set; }

        public int idGreenType { get; set; }

        public Boolean checkFiller { get; set; }

        public virtual RoseProgram roseProgram { get; set; }

        public virtual GreenType greenType { get; set; }


    }
}