using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class Basics
    {
        [Key]
        public int idBasics { get; set; }

        public string name { get; set; }

    }
}