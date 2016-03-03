using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GalleriaDesign.Models
{
    public class ImageTem
    {
        [Key]
        public int imageTemID { get; set; }
        //tipo de imagen
        public String description { get; set; }
        //imagen representada commo arreglo
        [Column(TypeName = "image")]
        public byte[] image { get; set; }
       
        


    }
}