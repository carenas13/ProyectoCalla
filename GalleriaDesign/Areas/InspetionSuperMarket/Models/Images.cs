using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class Images
    {
        [Key]
        public int idImage { get; set; }


        public int idStoreInformation { get; set; }
        public virtual StoreInformation storeInformation { get; set;}

        public int idConsumerBunchProgram { get; set; }

        public virtual ConsumerBunchProgram consumerBunchProgram { get; set;}

        public int idRoseProgram { get; set; } 
        public virtual RoseProgram roseProgram { get; set; }


        public int idBouquetProgram { get; set; }

        public virtual BouquetProgram bouquetProgram { get; set; }


        public int idStoreExecution { get; set; }

        public virtual StoreExecution storeExecution { get; set; }

       

     







    }
}