using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class FloralDisplay
    {
        [Key]
        public int idFloralDisplay { get; set; }

        [Required]
        public string description { get; set; }

        public virtual ICollection<StoreInformation> storeInformation { get; set; }

    }
}