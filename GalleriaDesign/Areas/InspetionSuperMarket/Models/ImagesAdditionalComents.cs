using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GalleriaDesign.Areas.InspetionSuperMarket.Models
{
    public class ImagesAdditionalComents
    {

        [Key]
        public int imageBouquetID { get; set; }

        //imagen representada commo arreglo
        [Column(TypeName = "image")]
        public byte[] image { get; set; }

        public int idAdditionalComents { get; set; }
        public virtual AdditionalComents additionalComments { get; set; }


    }
}