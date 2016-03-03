using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GalleriaDesign.Areas.InspetionSuperMarket.Models
{
    public class ImagesRoseProgram
    {

        [Key]
        public int imageRoseID { get; set; }

        //imagen representada commo arreglo
        [Column(TypeName = "image")]
        public byte[] image { get; set; }
        public int idRoseProgram { get; set; }

        public virtual RoseProgram roseProgram { get; set; }





    }
}