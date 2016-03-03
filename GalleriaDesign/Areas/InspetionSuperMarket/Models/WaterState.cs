using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class WaterState
    {
        [Key]
        public int idWaterState { get; set; }

        public string  description { get; set; }

        public virtual ICollection<StoreExecution> storeExecution { get; set; }


    }
}