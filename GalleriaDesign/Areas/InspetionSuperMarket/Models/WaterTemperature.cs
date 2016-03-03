using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class WaterTemperature
    {
        [Key]
        public int idWaterTemperature { get; set; }

        public string description { get; set;}

        public virtual ICollection<StoreExecution> storeExecution { get; set; }



    }
}