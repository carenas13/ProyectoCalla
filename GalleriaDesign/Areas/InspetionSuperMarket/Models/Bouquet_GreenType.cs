using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class Bouquet_GreenType
    {
        [Key]
        public int idBouquetGreenType { get; set; }

        public int idBouquetProgram { get; set; }

        public int idGreenType { get; set; }

        public Boolean checkGreenType { get; set; }

        public virtual BouquetProgram bouquetProgram { get; set; }

        public virtual GreenType greenType { get; set; }




    }
}