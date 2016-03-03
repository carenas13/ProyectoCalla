using ApplicationProductionsFarms.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicationProductionsFarms.Models
{
    public class VarietyProductCode
    {
        [Key]
        public int varietyCode { get; set; }
        public string Farm { get; set; }
        [Required]
        public string Product { get; set; }
        [Required]
        public string TypeFlower { get; set; }
        [Required]
        public string Colors { get; set; }
        [Required]
        public string Varieties { get; set; }
        [Required]
        public string TypeMarket { get; set; }
        [Required]
        public string Programas { get; set; }
        [Required]

        public int idFarms { get; set; }              // Relación muchos con Farms
        public virtual Farms Farms { get; set; }      //   

        public int idProduct { get; set; }              // Relación muchos con Productos
        public virtual Products Products { get; set; }      //   

        public int idCodFlowerType { get; set; }              // Relación muchos con FlowerType
        public virtual FlowerType FlowerType { get; set; }      // 

        public int idColor { get; set; }              // Relación muchos con Color
        public virtual Color Color { get; set; }      // 
        
        public int idVariety { get; set; }              // Relación muchos con Variety
        public virtual Variety variety { get; set; }      // 

        public int idMaketType { get; set; }              // Relación muchos con MarketType
        public virtual MarketType MarketType { get; set; }      // 

        public int idProgram { get; set; }              // Relación muchos con Program
        public virtual Program program { get; set; }      // 

        [Required]
        public virtual VarietyProductCode varietyproductcode { get; set; }
        
    }
}