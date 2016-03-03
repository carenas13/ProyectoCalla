using GalleriaDesign.Areas.InspetionSuperMarket.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class ConsumerBunchProgram
    {
        [Key]
        public int idConsumerBunchProgram { get; set; }


        public string descriptionProgram { get; set; }

        public decimal? retailBP { get; set; }

        public int? idConsumerBunchType { get; set; }

        public virtual ConsumerBunchType consumerBunchType { get; set; }
        public string otherBunchType { get; set; }

        public int? stemCountBP { get; set; }


        public int colorEnlancedBP { get; set;}


        public int idSupplier { get; set; }


        public virtual Supplier supplier { get; set; }

        public int sleevetypeBP{ get; set; }

        public Boolean innerWrapBP { get; set; }


        public int idStoreInformation { get; set; }

        public virtual StoreInformation storeInformation { get; set; }

        public ICollection<ImagesBunchProgram> imagesBunchProgram { get; set; }


   


    }
}