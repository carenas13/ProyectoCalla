using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class GreenType
    {
        [Key]
        public int idGreenType { get; set; }

        public string description { get; set; }



    }
}