using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class Bouquet_Basics
    {

        [Key]
        public int idBBasics { get; set;}

        public int idBouquetProgram { get; set; }

        public int idBasics { get; set; }

        public  int countPerType { get; set; }


        public virtual BouquetProgram bouquetProgram { get; set; }

        public virtual Basics basics { get; set; }






    }
}