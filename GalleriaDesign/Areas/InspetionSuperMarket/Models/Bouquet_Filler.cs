using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class Bouquet_Filler
    {
        [Key]
        public int idBouquet { get; set; }

        public int idBouquetProgram { get; set; }

        public int idFillerType { get; set; }

        public Boolean checkFiller { get; set; }

        public virtual BouquetProgram bouquetProgram { get; set; }

        public virtual FillerType fillerType { get; set; }







    }
}