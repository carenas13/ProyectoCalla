using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class Focals
    {
        [Key]
        public int idFocals { get; set; }

        public string nameFocal {get; set;}


    }
}