using GalleriaDesign.Areas.InspetionSuperMarket.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class RoseProgram
    {

        [Key]
        public int idRoseProgram { get; set; }

        public string programDescription { get; set; }

        public decimal? bunchRetail { get; set; }

        public int? stemCountRP { get; set; }


        public int idStemLength { get; set; }

        public virtual StemLength stemLength { get; set; }



        public int idHeadSize { get; set; }

        public virtual HeadSize headSize { get; set; }
         
        public int supplierRP { get; set; }

        public int sleeveRP { get; set; }

        public Boolean innerWrapRP { get; set; }


        public decimal? retailBouquet { get; set; }

       public int? totalStem { get; set; }

        public int? roseStem { get; set;}


        public int roseColorEnhanced { get; set; }


        public int? fillerStemCount { get; set; }

       

        public string otherFiller { get; set; }


        public int FillerColorEnhanced { get; set; }


        public int? greemsStemCount { get; set; }    


        public string otherGreenType { get; set; }
		
		public int greenColorEnhaced{get;set;}
      
        public int supplierRetail { get; set; }


        public int sleeveRetail { get; set; }

        public Boolean  innerWrapRetail { get; set; }


        public int idStoreInformation { get; set; }

        public virtual StoreInformation storeInformation { get; set; }

      
  public virtual ICollection<ImagesRoseProgram> imagesRoseProgam { get; set; }



        //public int idColorEnhaced { get; set; }

        //public virtual ColorEnhaced colorEnhacedRose { get; set; }


        //public int idSleeveType { get; set; }

        //public virtual SleeveType sleeveTypeRose { get; set; }

        //public int idSupplier { get; set; }

        //public virtual Supplier supplierRose { get; set; }











    }
}