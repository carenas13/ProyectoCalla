using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class Retailer
    {
        [Key]
        public int idRetailer { get; set; }

        [Required]
        public string nameRetailer { get; set; }

        public virtual ICollection<StoreInformation> storeInformation { get; set; }
    }
}