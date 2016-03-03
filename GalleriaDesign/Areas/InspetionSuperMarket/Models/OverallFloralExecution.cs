using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class OverallFloralExecution
    {

        [Key]
        public int idOverallFloral { get; set; }

        public string nameOverall { get; set; }

        public virtual ICollection<StoreExecution> storeExecution { get; set; }

    }
}