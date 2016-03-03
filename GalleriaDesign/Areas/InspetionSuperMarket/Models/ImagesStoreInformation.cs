using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GalleriaDesign.Areas.InspetionSuperMarket.Models
{
    public class ImagesStoreInformation
    {


        [Key]
        public int imageStoreInformationID { get; set; }

        //imagen representada commo arreglo
        [Column(TypeName = "image")]
        public byte[] image { get; set; }

        public int idStoreInformation { get; set; }
        public virtual StoreInformation storeInformation { get; set; }



    }
}