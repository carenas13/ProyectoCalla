using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class Store_ProductBreakDown
    {
        [Key]
        public int idStoreProductBreakDown { get; set; }
        public int idStoreInformation { get; set; }

        public int idProductBD { get; set; }

        public int percent { get; set; }

        public virtual StoreInformation storeInformation { get; set; }

        public virtual ProductBreackDown productBreackDown { get; set;}





    }
}