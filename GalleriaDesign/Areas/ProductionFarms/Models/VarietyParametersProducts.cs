using ApplicationProductionsFarms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApplicationProductionsFarms.Model
{
    public class VarietyParametersProducts
    {
        [Key]
        public int idVariedad { get; set; }

        /// <summary>
        /// Campo de relaciones para Crear el Codigo de Variedad de Producto
        /// </summary>
        /// 

        public int idFlowerSup { get; set; }              // Relación muchos con Farms        
        public virtual FlowerSuppliers FlowerSuppliers { get; set; }      //  
   
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

        /// <summary>
        /// Campo para crear los parametros pertenecientes al codigo de la variedad del producto
        /// </summary
        public string codVariety { get; set; }
        public float? DiasEnConf { get; set; }
        public float? DiasLuz { get; set; }
        public float? DiaInicioF { get; set; }
        public float? ProdxCamaTallos { get; set; }
        public float? TallosSiemProd { get; set; }
        public float? IndicePerdConf { get; set; }
        public float? IndicePerdProd { get; set; }
        public float? TallosSiemConf { get; set; }
        public float? DiasEnSiemDesboton { get; set; }
        public float? DiasEnSiemB91 { get; set; }
        public float? DiasEnSiemB92 { get; set; }
        public float? DiasEnSiemB93 { get; set; }
        public float? DiasCorte1 { get; set; }
        public float? DiasCorte2 { get; set; }
        public float? DiasCorte3 { get; set; }
        public float? DiasCorte4 { get; set; }
        public float? DiasCorte5 { get; set; }
        public float? DiasCorte6 { get; set; }
        public float? DiasCorte7 { get; set; }
        public int? TalloXBalde { get; set; }
        public int? TalloXCaja { get; set; }

        //public int idVariety { get; set; }             // Relación con Variety
        //public virtual Variety Variety { get; set; }   //        

        //public virtual ICollection<VarietyProductCode> varietyproductcodes { get; set; } // Relacion uno a muchos VarietyProductCode
        //public virtual VarietyProductCode VarietyProductCode { get; set; }
    }
}