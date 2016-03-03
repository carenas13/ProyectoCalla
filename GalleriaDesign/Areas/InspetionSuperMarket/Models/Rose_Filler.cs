using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class Rose_Filler
    {
        [Key]
        public int idRoseFiller { get; set; }

        public int idRoseProgram { get; set; }

        public int idFillerType { get; set; }

        public Boolean checkFiller { get; set; }

        public virtual RoseProgram roseProgram { get; set; }

        public virtual FillerType fillerType { get; set; }


    }
}