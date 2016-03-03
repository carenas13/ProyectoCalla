using ApplicationProductionsFarms.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicationProductionsFarms.Models
{
    public class Color
    {
        [Key]
        public int idColor { get; set; }
        public string codColor { get; set; }
        [Required]
        public string description { get; set; }
        public virtual ICollection<VarietyParametersProducts> varietyparametersproducts { get; set; } //Relación con VarietyParameters  

        internal static string Find(object idColor)
        {
            throw new NotImplementedException();
        }
    }
}