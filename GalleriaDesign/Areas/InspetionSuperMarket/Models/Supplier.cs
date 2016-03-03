using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class Supplier
    {
        [Key]
        public int idSupplier { get; set; }

        public string nameSupplier { get; set;}

   
        public virtual ICollection<ConsumerBunchProgram> consumerBunchProgram { get; set; }

     

        

    



    }
}