using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class ConsumerBunchType
    {
        [Key]
        public int idConsumerBunchType { get; set; }

        public string nameConsumer { get; set; }

        public virtual ICollection<ConsumerBunchProgram>  consumerBunchProgram { get; set;} 




    }
}