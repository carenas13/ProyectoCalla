using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class Bouquet_Focals
    {
        [Key]
        public int idBouquetFocals { get; set; }
        public int idBouquetProgram { get; set; }

        public int idFocals { get; set; }
        public int countPerType { get; set;}

        public virtual   BouquetProgram bouquetProgram { get; set; }

        public virtual Focals focals { get; set; }







    }
}