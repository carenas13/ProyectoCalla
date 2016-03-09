using GalleriaDesign.Areas.InspetionSuperMarket.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class StoreInformation
    {
        [Key]
        public int idStoreInformation { get; set; }

        public int idRetailer { get; set; }

        public virtual Retailer retailer { get; set; }
        public string otherRetailer { get; set; }

       [Required]
       public string numberStore { get; set; }

        [Required]
        public DateTime date { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        public string state { get; set; }

        [Required]
        public string inspector { get; set; }


        public int idFloralSetup { get; set; }

        public virtual FloralSetup floralSetup { get; set; }

   


        public int?  fullService { get; set; }

        public int idFloralDisplay { get; set; }
        public virtual FloralDisplay floralDisplay { get; set; }


        public string otherProduct { get; set; }

        public virtual ICollection<ConsumerBunchProgram> consumerBunchProgram { get; set; }

        public virtual ICollection<BouquetProgram> bouquetProgram { get; set; }


        public virtual ICollection<RoseProgram> roseProgram { get; set; }

 

        public virtual ICollection<StoreExecution> storeExecution { get; set; }

        public virtual ICollection<AdditionalComents>  additionalComents { get; set; }

        public virtual ICollection<ImagesStoreInformation> imagesStoreInformation { get; set; }
        
        public virtual ICollection<Store_ProductBreakDown> storeProductBreakDown { get; set; }



    }
}