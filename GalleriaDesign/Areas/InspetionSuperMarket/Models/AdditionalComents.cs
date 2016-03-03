using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GalleriaDesign.Areas.InspetionSuperMarket.Models
{
    public class AdditionalComents
    {
        
        [Key]
        public int idAdditionalComents { get; set; }

        public string comentsAdditional { get; set;}

    

        public int idStoreInformation { get; set; }

        public virtual StoreInformation storeInformation { get; set; }

        public virtual ICollection<ImagesAdditionalComents> imagesAdditionalComents { get; set; }



    }
}