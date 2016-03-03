using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class SleeveType
    {
        [Key]
        public int idSleeveType { get; set; }

        public string nameSleeve { get; set; }

        //public virtual ICollection<InspecctionSupermarket> inspectionSupermarket { get; set; }

        //public virtual ICollection<RoseProgram> roseProgram { get; set; }


        //public virtual ICollection<BouquetProgram> bouquetProgram { get; set; }




    }
}